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
    //public Panel[,] panels;
    Vector3 flick_start = Vector3.zero;
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
                //Panel panel = temp.GetComponent<Panel>();
                //this.panels[i,j] = panel;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	    //フリック開始判定
        if (Input.GetMouseButtonDown(0) && game_status == 0) {
            flick_start = get_touch_point();
            flick_start.y = 0.0f;
        }
        //フリック開始終了
        if (Input.GetMouseButtonUp(0) && game_status == 0) {
            flick_end = get_touch_point();
            GameObject ball = GameObject.Find("Ball");
            Ball ball_script = ball.GetComponent<Ball>();
            game_status = 1;
            ball_script.shoot(flick_start, flick_end, 1);
            flick_start = Vector3.zero;
            flick_end = Vector3.zero;
        }
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
            return hit_point;
        }
        Debug.Log("fatal error");
        return Vector3.zero;
    }
}
