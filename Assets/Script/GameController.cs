using UnityEngine;
using System;
using System.Collections;

public class GameController : MonoBehaviour {
    public GUISkin style;
    //TODO : enumにしてわかりやすい変数の持ち方にする
    //GameStatus
    //user_touchable : 0
    //ball_moving : 1
    //clear_check : 2
    public static int game_status = 0;
    public GameObject PanelPrefab;
    //ボールの定位置
    public static Vector3 ball_start_position;
    //ボールとパネルのz座標の距離
    public static float ball_panel_distance;
    public static float max_height = 20.0f;
    public static DateTime start_time;
    public static DateTime end_time;
    public Panel[,] panels;
    public static int panel_num = 9;
    public static int total_score = 0;
    public static int total_ball_num = 15;
    //乱数のseed
    public static int seed;
    System.Random rnd;
    public static bool is_cleared = true;
    //ボタンが押されたかを保持する
    public static bool kick_button_touched = false;
    public static int gauge_status;
    //ボールを蹴るごとににぬいた枚数
    public static int panel_num_per_action = 0;
    //ボールを蹴るごとにに獲得したbaseの点数
    public static int score_per_action = 0;
    public AudioClip success;
    //ホイッスル
    AudioSource audioSource;
	// Use this for initialization
	void Start () {
        seed = Environment.TickCount;
        rnd = new System.Random(seed);
        audioSource = this.GetComponent<AudioSource>();
        gauge_status = 1;
        //game_statusをuser_touchableにする
	    game_status = 0;
        total_score = 0;
        total_ball_num = 15;
        panel_num = 9;
        is_cleared = true;
        kick_button_touched = false;
        panels = new Panel[Config.panel_width_num,Config.panel_height_num[Config.stage_id]];
        //実際にpanelをinitiate
        GameObject tmp = GameObject.Instantiate(this.PanelPrefab,
            new Vector3(
                (float)0.27f,
                (float)0.93f,
                (float)11.0f
            ),
            Quaternion.identity
        ) as GameObject;
        panels[0,0] = tmp.GetComponent<Panel>();
        panels[0,0].set_texture(8);
        int panel_index = 0;
        for (int i = 0; i < Config.panel_width_num; i++) {
            for (int j = Config.panel_height_num[Config.stage_id]-1; j > 0;j--) {
                GameObject temp = GameObject.Instantiate(this.PanelPrefab,
                    new Vector3(
                        (float)(-6.15f + 4.5f * i),
                        (float)(0.93f + 2.0f * j),
                        (float)11.0f
                    ),
                    Quaternion.identity
                ) as GameObject;
                panels[i,j] = temp.GetComponent<Panel>();
                panels[i,j].set_texture(Config.panel_width_num * (Config.panel_height_num[Config.stage_id] - j - 1) + i);
            }
        }
        ball_start_position = GameObject.Find("SoccerBall").transform.position;
        ball_panel_distance = 12.5f - ball_start_position.z;
        panel_choice();
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) && kick_button_touched) {
            GameObject ball = GameObject.Find("SoccerBall");
            Ball ball_script = ball.GetComponent<Ball>();
            ball_script.shoot();
            game_status = 1;
            total_ball_num--;
            kick_button_touched = false;
        }
        else if (Input.GetMouseButton(0) && kick_button_touched) {
            //Debug.Log(Ball.power);
            if (gauge_status == 1) {
                Ball.power += 4.0f;
            } else {
                Ball.power -=4.0f;
            }
            if (Ball.power >= 100) {
                gauge_status = 2;
            } else if (Ball.power <= 0){
                gauge_status = 1;
            }
        }
	    //フリック開始判定
        else if (Input.GetMouseButtonDown(0) && game_status == 0) {
            get_touch_point();
        }
        //フリック開始終了
        else if (Input.GetMouseButtonUp(0) && game_status == 0) {
            get_touch_point();
        }
        //ドラッグ中
        else if (Input.GetMouseButton(0) && game_status == 0) {
            get_touch_point();
        }
        //ゲーム終了条件の判定もここで行う
        if (game_status == 2) {
            //パネルを1枚でも当てられた場合は歓声を流す
            if (panel_num_per_action > 0) {
                audioSource.clip = success;
                audioSource.Play();
            }
            bool ok = true;
            if (!panels[0,0].clear_flag) {
                ok = false;
            }
            for(int i=0;i<Config.panel_width_num;i++) {
               for(int j = 1;j < Config.panel_height_num[Config.stage_id];j++) {
                    if (!panels[i,j].clear_flag) {
                        ok = false;
                        break;
                    }
               }
            }
            if (ok) {
                Application.LoadLevel("ResultPage");
            } else if (total_ball_num == 0) {
                is_cleared = false;
                Application.LoadLevel("ResultPage");
            } else  {
                game_status = 0;
                panel_num_per_action = 0;
                panels[0,0].setDefault();
                for (int i = 0;i<Config.panel_width_num;i++){
                    for (int j=1;j<Config.panel_height_num[Config.stage_id];j++) {
                        panels[i,j].setDefault();
                    }
                }
                panel_choice();
            }
        }
	}

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
            //回転・高さの調節をしたい場合
            if (hit.collider.gameObject.tag=="pointer" ||
                    hit.collider.gameObject.tag=="ball_cylinder") {
                //pointerオブジェクトを探索する
                GameObject pointer_obj = GameObject.Find("Pointer");
                //pointerをタッチされた座標に更新する
                Pointer pointer = pointer_obj.GetComponent<Pointer>();
                pointer.change_position(hit.point);
            }
            else if (hit.collider.gameObject.tag=="r_button") {
                DrawLine.ball_direction = new Vector3(
                    DrawLine.ball_direction.x + 0.1f,
                    DrawLine.ball_direction.y,
                    DrawLine.ball_direction.z
                );
                //Debug.Log(DrawLine.ball_direction);
            }
            else if (hit.collider.gameObject.tag=="l_button") {
                DrawLine.ball_direction = new Vector3(
                    DrawLine.ball_direction.x - 0.1f,
                    DrawLine.ball_direction.y,
                    DrawLine.ball_direction.z
                );
            }
            //それ以外に衝突した場合(方向調整)
            else {
                if (hit_point.z > ball_start_position.z + 2) {
                    Vector3 temp = new Vector3(hit_point.x,ball_start_position.y,hit_point.z);
                    temp = temp - ball_start_position;
                    temp = temp * ball_panel_distance / temp.z;
                    DrawLine.ball_direction = ball_start_position + temp;
                }
            }
            return hit_point;
        }
        Debug.Log("fatal error about ray cast!!");
        return Vector3.zero;
    }

    //ランダムにスコア2倍のパネルを選択する
    void panel_choice() {
        int index = rnd.Next(panel_num);
        index++;
        int count = 0;
        int ok = 0;
        if (!panels[0,0].clear_flag) {
            count++;
        }
        if (count == index) {
            panels[0,0].make_target(2);
            return;
        }
        for (int i = 0;i<Config.panel_width_num;i++) {
            for (int j = 1;j<Config.panel_height_num[Config.stage_id];j++) {
                if (!panels[i,j].clear_flag) {
                    count ++;
                }
                if (count == index) {
                    panels[i,j].make_target(2);
                    ok = 1;
                    break;
                }
            }
            if (ok==1) {
                break;
            }
        }
    }

    //スコア + ボール所持数の表示
    void OnGUI () {
        GUI.skin = style;
        Rect rect = new Rect(10,10,600,60);
        string score = "スコア : " + total_score.ToString() + "点";
        GUI.Label(rect,score);
        Rect rect2 = new Rect(10,60,600,60);
        string ball_num = "残りボール数 : " + total_ball_num.ToString() + "個";
        GUI.Label(rect2,ball_num);
        Rect rect3 = new Rect(10,890,600,60);
        string power = "パワー : " + ((int)Ball.power).ToString();
        GUI.Label(rect3,power);
        //Powerボタンの設置
        if (GUI.RepeatButton (new Rect (10, 990, 400, 130), "Charge & Shoot!!") && game_status == 0 && !kick_button_touched) {
            Ball.power = 0;
            kick_button_touched = true;
            //Debug.Log(kick_button_touched);
        }
    }
}
