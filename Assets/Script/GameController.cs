using UnityEngine;
using System;
using System.Collections;

public class GameController : MonoBehaviour {
    // GUIボタン等の設定を保持するObject
    public GUISkin style;
    public GUIStyle style_for_status;
    public GUIStyle style_for_button;

    /* ---------------------
    GameStatus
     - user_touchable : 0
     - ball_moving : 1
     - clear_check : 2
    ----------------------*/
    public static int game_status = 0;

    //ボールの定位置
    public static Vector3 ball_start_position;
    public static float ball_panel_distance;

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
        animation = false;
        //panel情報の獲得
        total_panel_num = Config.panel_config[Config.stage_id].Length;
        panel_remaining_num = Config.panel_config[Config.stage_id].Length;
        panels = new Panel[total_panel_num];
        for (int i = 0; i < total_panel_num; i++) {
            GameObject tmp = PanelManager.make_panel_object(0,i);
            panels[i] = tmp.GetComponent<Panel>();
        }
        ball_start_position = GameObject.Find("SoccerBall").transform.position;
        ball_panel_distance = 12.5f - ball_start_position.z;
        panel_choice();
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	    //フリック開始判定
        if (Input.GetMouseButtonDown(0) && game_status == 0) {
            start_time = DateTime.Now;
            Vector3 point = get_touch_point();
            flick_start_position = point;
        }
        //フリック開始終了
        else if (Input.GetMouseButtonUp(0) && game_status == 0) {
            end_time = DateTime.Now;
            TimeSpan time = end_time-start_time;
            Vector3 point = get_touch_point();
            flick_end_position = point;
            //ボールObjectを取得してボールを発射する
            GameObject ball = GameObject.Find("SoccerBall");
            Ball ball_script = ball.GetComponent<Ball>();
            ball_script.shoot(
                flick_start_position,
                flick_end_position,
                (float)time.TotalMilliseconds
            );
            game_status = 1;
            total_ball_num--;
        }
        //ドラッグ中
        else if (Input.GetMouseButton(0) && game_status == 0) {
            Vector3 point = get_touch_point();
        }
        //ゲーム終了条件の判定もここで行う
        if (game_status == 2) {
            if (does_target_hit) {
                DateTime targetTime = DateTime.Now;
               if (target_unix_time == 0) {
                   //animationの計測開始
                   target_unix_time = GetUnixTime(targetTime);
                   animation = true;
               }
               else if (GetUnixTime(targetTime) - target_unix_time < 3){
                   //3秒以内なら特に何もしない
               }
               else {
                    target_unix_time = 0;
                    animation = false;
                    does_target_hit = false;
               }
            } else {
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
            if (!hit.collider.gameObject) {
                //衝突したオブジェクトがなければ暫定的に原点を返す
                Debug.Log("Ray doesn\'t hit the object!!");
                return Vector3.zero;
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
        GUI.skin = style;
        style_for_status.fontSize = (int)(36 * Config.s_height/1080);
        style_for_button.fontSize = (int)(40 * Config.s_height/1080);
        Rect rect = new Rect(10,10,(float)Config.s_width*0.9f,(float)Config.s_height*0.06f);
        string score = "スコア : " + total_score.ToString() + "点";
        GUI.Label(rect,score, style_for_status);
        Rect rect2 = new Rect(10,(float)Config.s_height*0.06f,(float)Config.s_width*0.9f,(float)Config.s_height*0.06f);
        string ball_num = "残りボール数 : " + total_ball_num.ToString() + "個";
        GUI.Label(rect2,ball_num,style_for_status);
        Rect rect3 = new Rect(10,(float)Config.s_height*0.82f,(float)Config.s_width*0.9f,(float)Config.s_height*0.06f);
        string power = "パワー : " + ((int)Ball.power).ToString();
        GUI.Label(rect3,power,style_for_status);
    }
    private static DateTime UNIX_EPOCH = new DateTime(1970,1,1,0,0,0,0);
    public static int GetUnixTime(DateTime targetTime){
        targetTime = targetTime.ToUniversalTime();
        TimeSpan elapsedTime = targetTime - UNIX_EPOCH;
        return (int)elapsedTime.TotalSeconds;
    }
}
