using UnityEngine;
using System.Collections;

public class StageList : MonoBehaviour {
    public GUIStyle style_for_title;
    public GUIStyle style_for_button;
    public int user_clear_stage = 0;
    public int page = 0;
    public StageAbs[] stage_list = new StageAbs[StageListManager.stage_num_per_page];
    // Use this for initialization
    void Start () {
        Application.targetFrameRate =  15;
        if (PlayerPrefs.HasKey("user_stage")) {
            user_clear_stage = PlayerPrefs.GetInt("user_stage");
        }
        page = 0;
        stage_list = StageListManager.make_stage_list_obj (page, user_clear_stage);
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetMouseButtonDown(0)) {
            check_touch_stg_abs_and_go();
        }
    }

    void OnGUI () {
        //説明画面に飛ぶ為のボタンを設置する
        style_for_title.fontSize = (int)80 * Config.s_height/1080;
        style_for_title.normal.textColor = Color.white;
        Rect rect = new Rect(10,10,(float)Config.s_width*0.9f,(float)Config.s_height * 0.12f);
        GUI.Label(rect,"Stage一覧", style_for_title);
        //説明画面に飛ぶ為のボタンを設置する
        style_for_button.fontSize = (int)36 *  Config.s_height/1080;
        float bt_x_offset = Config.s_width  *  0.05f;
        float bt_y_offset = Config.s_height  *  0.90f;
        float bt_size_x = Config.s_width  * ((0.9f-0.05f*(2-1))/2);
        float bt_size_y = Config.s_height * 0.05f;
        if (StageListManager.should_show_prev_page(page, user_clear_stage) && GUI.Button(new Rect(bt_x_offset, bt_y_offset, bt_size_x, bt_size_y),"prev",style_for_button)) {
            page--;
            StageListManager.destroyAll(stage_list);
            stage_list = StageListManager.make_stage_list_obj (page, user_clear_stage);
        }
        if (StageListManager.should_show_next_page(page, user_clear_stage) && GUI.Button(new Rect(bt_x_offset * 2 + bt_size_x, bt_y_offset, bt_size_x, bt_size_y),"next",style_for_button)) {
            page++;
            StageListManager.destroyAll(stage_list);
            stage_list = StageListManager.make_stage_list_obj (page, user_clear_stage);
        }
    }

    void check_touch_stg_abs_and_go() {
        //マウスカーソルからのRay発射
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            //オブジェクトに全く衝突しなかった場合
            Debug.Log (hit.collider.gameObject);
            GameObject ball = GameObject.Find("SoccerBall");
            if(hit.collider.gameObject.tag == "StageAbs") {
                StageAbs hit_stage_abs = hit.collider.gameObject.GetComponent<StageAbs>();
                Config.stage_id = hit_stage_abs.stage_id;
                Application.LoadLevel("GameScene");
            }
        }
    }
}

