using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
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
	// Use this for initialization
	void Start () {
        //game_statusをuser_touchableにする
	    game_status = 0;
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
            }
        }
        ball_start_position = GameObject.Find("Ball").transform.position;
        ball_panel_distance = 12.5f - ball_start_position.z;
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
                ball_script.shoot(ball_start_position, flick_end, 1);
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
            game_status = 0;
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
                if (!ball_touch && touch_for_flick && hit_point.z > ball_start_position.z) {
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
}
