 using UnityEngine;
using System;
using System.Collections;

public class GameController : MonoBehaviour {
    // GUIボタン等の設定を保持するObject
    public GUIStyle style_for_status;
    public GUIStyle style_for_button;

    /* ---------------------
    GameStatus
     - user_touchable : 0
     - ball_moving : 1
     - clear_check : 2
     - curve_fix : 3
    ----------------------*/
    public static int game_status = 0;

    //ボールの定位置
    public static Vector3 ball_start_position;
    public static float ball_panel_distance;
    public static bool is_flick_start;

    /* ---------------------
     ユーザのフリック情報
     start_time : ユーザがフリックした時間
     end_time : ユーザがフリックを終えた時間
     flick_start_position : ユーザがフリックを開始した3次元座標
     flick_end_position : ユーザがフリックを終了した3次元座標
     ---------------------*/
    public static DateTime start_time;
    public static DateTime end_time;
    public static Vector3 flick_start_position;
    public static Vector3 flick_end_position;

    /* -------------------
    パネルに関する情報
     - panels : 実際のpanelインスタンスの集合
     - total_panel_num : ステージに出現するパネルの枚数
     - panel_remaining_num : ステージ上に残っているパネルの枚数
     -
    --------------------- */
    public Panel[] panels;
    public static int total_panel_num;
    public static int panel_remaining_num;
    public static int total_score = 0;
    public static int total_ball_num;
    //乱数のseed
    public static int seed;
    System.Random rnd;
    public static bool is_cleared = true;
    /* --------------------
    ゲーム画面の状態を保存しておく変数
    0 : ユーザ調整画面
    1 : ボールの運動中画面
    2 : パネルhit等更新画面
    -------------------*/
    public static int gauge_status;
    //ボールを蹴るごとににぬいた枚数
    public static int panel_num_per_action = 0;
    //ボールを蹴るごとにに獲得したbaseの点数
    public static int score_per_action = 0;
    public AudioClip success;
    //ホイッスル
    AudioSource audioSource;
    public static bool does_target_hit = false;
    public int target_unix_time = 0;
    public static bool animation = false;
	// Use this for initialization
	void Start () {
        seed = Environment.TickCount;
        rnd = new System.Random(seed);
        audioSource = this.GetComponent<AudioSource>();
        gauge_status = 1;
        does_target_hit = false;
        //game_statusをuser_touchableにする
	    game_status = 0;
        total_score = 0;
        total_ball_num = Config.ball_num[Config.stage_id];
        panel_num_per_action = 0;
        score_per_action = 0;
        is_cleared = true;
        is_flick_start = false;
        animation = false;
        //panel情報の獲得
        total_panel_num = Config.panel_config[Config.stage_id].Length;
        panel_remaining_num = Config.panel_config[Config.stage_id].Length;
        panels = new Panel[total_panel_num];
        for (int i = 0; i < total_panel_num; i++) {
            GameObject tmp = PanelManager.make_panel_object(Config.stage_id,i);
            panels[i] = tmp.GetComponent<Panel>();
        }
        //障害物の情報
        int total_obstacle_num = Config.obstacle_config[Config.stage_id].Length;
        for (int i = 0; i < total_obstacle_num; i++) {
            //障害物のインスタンスの生成
            ObstacleManager.make_obstacle_object (Config.stage_id, i);
        }
        ball_start_position = GameObject.Find("SoccerBall").transform.position;
        ball_panel_distance = 12.5f - ball_start_position.z;
        flick_start_position = Vector3.zero;
        panel_choice();
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log (is_flick_start);
        //Debug.Log(PopupManager.select_done);
        //フリック開始判定及び球種調整
        if (Input.GetMouseButtonDown(0) && !is_flick_start) {
            start_time = DateTime.Now;
            if (PopupManager.select_done) {
                get_touch_point ();
                //Debug.Log (is_flick_start);
                if (is_flick_start) {
                    Ball.power = 0;
                    flick_start_position = ball_start_position;
                }
            }
        }
        //フリック開始終了
        else if (is_flick_start && Input.GetMouseButtonUp(0) && game_status == 0 && flick_start_position != Vector3.zero) {
            is_flick_start = false;
            end_time = DateTime.Now;
            TimeSpan time = end_time-start_time;
            int tms = (int)time.TotalMilliseconds;
            //1秒以内かつフリックの距離が規定値を超えていないと発射しない
            if (tms < 1000) {
                Vector3 point = get_touch_point ();
                //距離の判定はここで行う
                //Debug.Log ((point - flick_start_position).magnitude);
                if ((point - flick_start_position).magnitude >= 5) {
                    flick_end_position = point;
                    //ボールObjectを取得してボールを発射する
                    GameObject ball = GameObject.Find ("SoccerBall");
                    Ball ball_script = ball.GetComponent<Ball> ();
                    ball_script.shoot (
                        flick_start_position,
                        flick_end_position,
                        tms
                    );
                    game_status = 1;
                    total_ball_num--;
                }
            } else {
                //特に何もしない
            }
        }
        //ドラッグ中(パワー決め or 方向決定中)
        else if (Input.GetMouseButton(0) && game_status == 3) {
            Vector3 point = get_touch_point();
        }
        //ゲーム終了条件の判定もここで行う
        if (game_status == 2) {
            //パネルを1枚でも当てられた場合は歓声を流す
            //さらにここで計算も行う
            if (panel_num_per_action > 0) {
                audioSource.clip = success;
                audioSource.Play();
                total_score += score_per_action * panel_num_per_action;
                //スコアを計算したので、actionあたりの抜いた枚数や点数をreset
                score_per_action = 0;
                panel_num_per_action = 0;
            }
            bool ok = true;
            for(int i=0;i<total_panel_num;i++) {
               if (!panels[i].clear_flag) {
                    ok = false;
                    break;
               }
            }
            if (ok) {
                int tmp = 0;
                if (PlayerPrefs.HasKey("user_stage")) {
                    tmp = PlayerPrefs.GetInt("user_stage");
                }
                if (tmp < (Config.stage_id + 1)) {
                    PlayerPrefs.SetInt("user_stage",(Config.stage_id + 1));
                }
                Application.LoadLevel("ResultPage");
            } else if (total_ball_num == 0) {
                is_cleared = false;
                Application.LoadLevel("ResultPage");
            } else  {
                game_status = 0;
                panel_num_per_action = 0;
                for (int i = 0;i<total_panel_num;i++){
                    panels[i].setDefault();
                }
                panel_choice();
            }
        }
	}

    /* ---------------------
    get_touch_point
    2次元座標からUnityの座標へ変換して返す
    -----------------------*/
    Vector3 get_touch_point() {
        //マウスカーソルからのRay発射
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            //オブジェクトに全く衝突しなかった場合
            Debug.Log (hit.collider.gameObject);
            GameObject ball = GameObject.Find("SoccerBall");
            if (!hit.collider.gameObject) {
                //衝突したオブジェクトがなければ暫定的に原点を返す
                Debug.Log ("Ray doesn\'t hit the object!!");
                return Vector3.zero;
            } else if (hit.collider.gameObject == ball) {
                is_flick_start = true;
            }
            //回転・高さの調節をしたい場合
            else if (hit.collider.gameObject.tag == "pointer" ||
                     hit.collider.gameObject.tag == "ball_cylinder") {
                if (game_status == 3) {
                    //pointerオブジェクトを探索する
                    GameObject pointer_obj = GameObject.Find ("Pointer");
                    //pointerをタッチされた座標に更新する
                    Pointer pointer = pointer_obj.GetComponent<Pointer> ();
                    pointer.change_position (hit.point);
                } else if (game_status == 0) {
                    game_status = 3;
                    GameObject indicator = GameObject.Find ("BallIndicator");
                    GameObject pointer = GameObject.Find ("Pointer");
                    indicator.transform.position = new Vector3 (0.3045821f,1.506949f,-15.50411f);
                    indicator.transform.localScale = new Vector3 (2.0f, 0.1f, 2.0f);
                    pointer.GetComponent<Pointer> ().update_change_array();
                }
            }
            //メニューボタンをタッチしたい場合
            else if (hit.collider.gameObject.tag == "MenuButton") {
               if (game_status == 4 || game_status == 0) {
                    GameObject modal_obj = GameObject.Find("Modal");
                    Modal modal = modal_obj.GetComponent<Modal>();
                    if (game_status == 4) {
                        modal.close_window();
                        game_status = 0;
                    } else {
                        modal.open_window();
                        game_status = 4;
                    }
               }
            }
            //モーダルボタンをタッチした場合
            else if (hit.collider.gameObject.tag == "ModalButton") {
                ModalButton modal_button = hit.collider.gameObject.GetComponent<ModalButton>();
                modal_button.activate_event_by_button_type();
                game_status = 0;
            }
            //衝突したオブジェクトがある場合はその地点の座標を取得
            Vector3 hit_point = hit.point;
            return hit.point;
        }
        Debug.Log("fatal error about ray cast!!");
        return Vector3.zero;
    }

    //ランダムにスコア2倍のパネルを選択する
    void panel_choice() {
        int index = rnd.Next(panel_remaining_num);
        index++;
        int count = 0;
        int ok = 0;
        for (int i = 0;i<total_panel_num;i++) {
            if (!panels[i].clear_flag) {
                count ++;
            }
            if (count == index) {
                panels[i].make_target(2);
                break;
            }
        }
    }

    //スコア + ボール所持数の表示
    void OnGUI () {
        style_for_status.fontSize = (int)(36 * Config.s_height/1080);
        style_for_button.fontSize = (int)(36 * Config.s_height/1080);
		Rect rect = new Rect((float)Config.s_width*0.05f, (float)Config.s_height*0.065f,(float)Config.s_width*0.45f,(float)Config.s_height*0.06f);
		string score = "スコア : ";
		GUI.Label(rect,score, style_for_status);
		Rect rect2 = new Rect ((float)Config.s_width*0.55f, (float)Config.s_height*0.065f, (float)Config.s_width * 0.45f, (float)Config.s_height * 0.06f);
		string point = total_score.ToString() + "点";
		GUI.Label(rect2, point, style_for_status);
		Rect rect3 = new Rect((float)Config.s_width*0.05f,(float)Config.s_height*0.14f,(float)Config.s_width*0.9f,(float)Config.s_height*0.06f);
        string rest_ball = "残りボール数 : ";
        GUI.Label(rect3,rest_ball,style_for_status);
		Rect rect4 = new Rect((float)Config.s_width*0.55f,(float)Config.s_height*0.14f,(float)Config.s_width*0.9f,(float)Config.s_height*0.06f);
		string ball_num = total_ball_num.ToString() + "個";
		GUI.Label(rect4,ball_num,style_for_status);  
        Rect rect5 = new Rect(10,(float)Config.s_height*0.70f,(float)Config.s_width*0.80f,(float)Config.s_height*0.06f);
        string power = "パワー : " + ((int)Ball.power).ToString();
        //TODO : ここはなんとかしないと後で大変そう
        if (game_status != 4) {
            GUI.Label(rect5,power,style_for_status);
        }
        //調整ボタン
        if (game_status == 3 && GUI.Button (new Rect ((float)Config.s_width * 0.25f, (float)Config.s_height * 0.875f, (float)Config.s_width * 0.5f, (float)Config.s_height * 0.10f), "これで蹴る!!", style_for_button)) {
            GameObject indicator = GameObject.Find ("BallIndicator");
            GameObject pointer = GameObject.Find ("Pointer");
                game_status = 0;
                indicator.transform.position = new Vector3 (1.603648f,0.5504193f,-15.49023f);
                indicator.transform.localScale = new Vector3 (0.4f, 0.01f, 0.4f);
                pointer.GetComponent<Pointer> ().update_change_array();
        }
    }
    private static DateTime UNIX_EPOCH = new DateTime(1970,1,1,0,0,0,0);
    public static int GetUnixTime(DateTime targetTime){
        targetTime = targetTime.ToUniversalTime();
        TimeSpan elapsedTime = targetTime - UNIX_EPOCH;
        return (int)elapsedTime.TotalSeconds;
    }
}
