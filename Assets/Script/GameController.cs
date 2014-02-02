using UnityEngine;
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
    public GameObject ball;
    public static bool touch_for_ball = true;
    Vector3 flick_end = Vector3.zero;
	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Ball");
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
	}
	
	// Update is called once per frame
	void Update () {
        //フリック開始終了
        /*if (Input.GetMouseButtonUp(0) && game_status == 0) {
            flick_end = get_touch_point();
            touch_for_ball = true;
        }*/
        //ドラッグ中
        if (Input.GetMouseButton(0) && game_status == 0) {
            flick_end = get_touch_point();
            touch_for_ball = true;
        }
        //ゲーム終了条件の判定もここで行う
        if (game_status == 2) {
            /*for (int i = 0; i < Config.panel_width_num;i++) {
                bool ng = false;
                for (int j = 0; j < Config.panel_height_num[Config.stage_id];j++) {
                    if (!panels[i,j].clear_flag) {
                        ng = true;
                        break;
                    }
                }
                if (ng) {
                    game_status = 0;
                    break;
                }
            }
            Debug.Log("game_cleard");
            */
            game_status = 0;
        }
	}

    Vector3 get_touch_point() {
        //マウスカーソルからのRay発射
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (!hit.collider.gameObject) {
                //衝突したオブジェクトがなければ暫定的に原点を返す
                Debug.Log("Ray doesn\'t hit the object!!");
                return Vector3.zero;
            }
            //衝突したオブジェクトがある場合はその地点の座標を取得
            Vector3 hit_point = hit.point;
            if (hit_point.z <= -15.0f) {
                touch_for_ball = false;
            }
            if (hit.collider.gameObject.tag=="pointer" ||
                    hit.collider.gameObject.tag=="ball_cylinder") {
                //この場合はフリック動作でない事を明記
                touch_for_ball = true;
                //pointerオブジェクトを探索する
                GameObject pointer_obj = GameObject.Find("Pointer");
                //pointerをタッチされた座標に更新する
                if (pointer_obj.renderer.enabled) {
                    Pointer pointer = pointer_obj.GetComponent<Pointer>();
                    pointer.change_position(hit.point);
                }
            }
            if (touch_for_ball) {
                Vector3 ball_direction = -1 * (hit_point - ball.transform.position) + ball.transform.position;
                DrawLine.ball_direction = new Vector3(
                    ball_direction.x,
                    DrawLine.ball_direction.y,
                    ball_direction.z
                );
                //Debug.Log(DrawLine.ball_direction.y);
                //Vector3 temp = ball.transform.position + ball_direction;
                //temp = new Vector3(temp.x,DrawLine.ball_direction.y, temp.z);
                //Debug.Log(temp);
                return DrawLine.ball_direction;
            }
            return flick_end;
        }
        Debug.Log("fatal error");
        return Vector3.zero;
    }
    //ボタン等の設置
    void OnGUI() {
        GUI.skin = style;
        if ( GUI.Button( new Rect(50, 1000, 200, 100), "Shoot!!" ) ) {
            //Debug.Log("蹴る位置が押されました。");
            /*GameObject indicator = GameObject.Find("Ball_Indicator");
            GameObject pointer = GameObject.Find("Pointer");
            indicator.renderer.enabled = !indicator.renderer.enabled;
            pointer.renderer.enabled = !pointer.renderer.enabled;*/
            Ball ball_script = ball.GetComponent<Ball>();
            game_status = 1;
            ball_script.shoot(ball.transform.position, flick_end, 1);
        }
    }
}
