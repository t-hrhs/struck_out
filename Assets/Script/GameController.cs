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
    //発射の為にボールに既に触れているかのフラグ(flick_start)
    public static bool ball_touch = false;
    //発射開始の座標を取得したか(flick_end)
    public static bool touch_for_flick = true;
    Vector3 flick_end = Vector3.zero;
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
	// Use this for initialization
	void Start () {
        seed = Environment.TickCount;
        rnd = new System.Random(seed);
        //game_statusをuser_touchableにする
	    game_status = 0;
        total_score = 0;
        total_ball_num = 15;
        panel_num = 9;
        is_cleared = true;
        panels = new Panel[Config.panel_width_num,Config.panel_height_num[Config.stage_id]];
        //実際にpanelをinitiate
        for (int i = 0; i < Config.panel_width_num; i++) {
            for (int j = 0; j < Config.panel_height_num[Config.stage_id];j++) {
                GameObject temp = GameObject.Instantiate(this.PanelPrefab,
                        new Vector3(
                                (float)(-5.2f + 5.25f * i),
                                (float)(1.25f + 2.75f * j),
                                (float)12.5f
                        ),
                        Quaternion.identity
                ) as GameObject;
                panels[i,j] = temp.GetComponent<Panel>();
            }
        }
        ball_start_position = GameObject.Find("Ball").transform.position;
        ball_panel_distance = 12.5f - ball_start_position.z;
        panel_choice();
	}
	
	// Update is called once per frame
	void Update () {
	    //フリック開始判定
        if (Input.GetMouseButtonDown(0) && game_status == 0) {
            get_touch_point();
        }
        //フリック開始終了
        else if (Input.GetMouseButtonUp(0) && game_status == 0) {
            flick_end = get_touch_point();
            //ボールに既に触れていて調節に触れていない時
            if (ball_touch && touch_for_flick) {
                GameObject ball = GameObject.Find("Ball");
                Ball ball_script = ball.GetComponent<Ball>();
                game_status = 1;
                end_time = DateTime.Now;
                ball_script.shoot(ball_start_position, flick_end, end_time-start_time);
                total_ball_num--;
                flick_end = Vector3.zero;
            }
            ball_touch = false;
            touch_for_flick = true;
        }
        //ドラッグ中
        else if (Input.GetMouseButton(0) && game_status == 0) {
            get_touch_point();
        }
        //ゲーム終了条件の判定もここで行う
        if (game_status == 2) {
            bool ok = true;
            for(int i=0;i<Config.panel_width_num;i++) {
               for(int j = 0;j < Config.panel_height_num[Config.stage_id];j++) {
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
                for (int i = 0;i<Config.panel_width_num;i++){
                    for (int j=0;j<Config.panel_height_num[Config.stage_id];j++) {
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
            //ボールに衝突した場合
            if (hit.collider.gameObject.tag=="my_ball") {
                ball_touch = true;
                start_time = DateTime.Now;
                return Vector3.zero;
            }
            //回転・高さの調節をしたい場合
            else if (hit.collider.gameObject.tag=="pointer" ||
                    hit.collider.gameObject.tag=="ball_cylinder") {
                //この場合はボール発射ではないことを明記
                touch_for_flick = false;
                //pointerオブジェクトを探索する
                GameObject pointer_obj = GameObject.Find("Pointer");
                //pointerをタッチされた座標に更新する
                Pointer pointer = pointer_obj.GetComponent<Pointer>();
                pointer.change_position(hit.point);
            }
            //それ以外に衝突した場合(方向調整)
            else {
                if (!ball_touch && touch_for_flick && hit_point.z > ball_start_position.z + 4) {
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
        for (int i = 0;i<Config.panel_width_num;i++) {
            for (int j = 0;j<Config.panel_height_num[Config.stage_id];j++) {
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
        Rect rect3 = new Rect(10,1050,600,60);
        string power = "パワー : " + ((int)Ball.power).ToString();
        GUI.Label(rect3,power);
    }
}
