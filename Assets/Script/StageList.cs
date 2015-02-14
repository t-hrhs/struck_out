using UnityEngine;
using System.Collections;

public class StageList : MonoBehaviour {
    public GUISkin style;
    public GUIStyle style_for_title;
    public GUIStyle style_for_button;
    public int user_clear_stage = 0;
    // Use this for initialization
    void Start () {
        if (PlayerPrefs.HasKey("user_stage")) {
            user_clear_stage = PlayerPrefs.GetInt("user_stage");
        }
    }

    // Update is called once per frame
    void Update () {

    }

    void OnGUI () {
        //説明画面に飛ぶ為のボタンを設置する
        GUI.skin = style;
        //ボタンの色の都合(あまり意味はない)
        GUI.backgroundColor = Color.yellow;
        style_for_title = new GUIStyle();
        style_for_title.fontSize = (int)80 * Config.s_height/1080;
        style_for_title.normal.textColor = Color.white;
        Rect rect = new Rect(10,10,(float)Config.s_width*0.9f,(float)Config.s_height * 0.12f);
        //TODO : ここらへん定数をどこかに持っていきたい
        //style_for_button = new GUIStyle();
        style_for_button.fontSize = (int)40 * Config.s_height/1080;
        style_for_button.normal.textColor = Color.white;
        int x_offset = (int)(Config.s_width * 0.05);
        int y_offset = (int)(Config.s_height * 0.15);
        int interval = 5;
        int bt_size_x = (int)((Config.s_width-x_offset * 2)/3 - interval);
        int bt_size_y = (int)((Config.s_height-y_offset * 2)/6 - interval);
        GUI.Label(rect,"StageList", style_for_title);
        if (GUI.Button(new Rect(x_offset, y_offset, bt_size_x, bt_size_y),"1st STG", style_for_button)) {
            Config.stage_id = 0;
            //Go to the 1st STG
            Application.LoadLevel("GameScene");
            //Application.LoadLevel("explain_stage_1");
        }
        if (user_clear_stage > 0) {
            if (GUI.Button(new Rect(x_offset + bt_size_x + interval, y_offset, bt_size_x, bt_size_y),"2nd STG",style_for_button)) {
                Config.stage_id = 1;
                //Go to the 2nd STG
                Application.LoadLevel("GameScene");
                //Application.LoadLevel("explain_stage_1");
            }
        }
        if (user_clear_stage > 1) {
            if (GUI.Button(new Rect(x_offset + (bt_size_x + interval) * 2, y_offset, bt_size_x, bt_size_y),"3rd STG", style_for_button)) {
                Config.stage_id = 2;
                //Go to the 3rd STG
                Application.LoadLevel("GameScene");
                //Application.LoadLevel("explain_stage_1");
            }
        }
        if (user_clear_stage > 2) {
            if (GUI.Button(new Rect(x_offset, y_offset + bt_size_y + interval, bt_size_x, bt_size_y),"4th STG", style_for_button)) {
                Config.stage_id = 3;
                //Go to the 4th STG
                Application.LoadLevel("GameScene");
                //Application.LoadLevel("explain_stage_1");
            }
        }
        if (user_clear_stage > 3) {
            if (GUI.Button(new Rect(x_offset + bt_size_x + interval, y_offset + bt_size_y + interval, bt_size_x, bt_size_y),"5th STG", style_for_button)) {
                Config.stage_id = 4;
                //Go to the 5th STG
                Application.LoadLevel("GameScene");
                //Application.LoadLevel("explain_stage_1");
            }
        }
        if (user_clear_stage > 3) {
            if (GUI.Button(new Rect(x_offset + (bt_size_x + interval)*2, y_offset + bt_size_y + interval, bt_size_x, bt_size_y),"6th STG", style_for_button)) {
                Config.stage_id = 5;
                //Go to the 5th STG
                Application.LoadLevel("GameScene");
                //Application.LoadLevel("explain_stage_1");
            }
        }
        if (user_clear_stage > 3) {
            if (GUI.Button(new Rect(x_offset, y_offset + (bt_size_y + interval)*2, bt_size_x, bt_size_y),"7th STG", style_for_button)) {
                Config.stage_id = 6;
                //Go to the 4th STG
                Application.LoadLevel("GameScene");
                //Application.LoadLevel("explain_stage_1");
            }
        }
        if (user_clear_stage > 3) {
            if (GUI.Button(new Rect(x_offset + bt_size_x + interval, y_offset + (bt_size_y + interval)*2, bt_size_x, bt_size_y),"8th STG", style_for_button)) {
                Config.stage_id = 7;
                //Go to the 5th STG
                Application.LoadLevel("GameScene");
                //Application.LoadLevel("explain_stage_1");
            }
        }
        if (user_clear_stage > 3) {
            if (GUI.Button(new Rect(x_offset + (bt_size_x + interval)*2, y_offset + (bt_size_y + interval)*2, bt_size_x, bt_size_y),"9th STG", style_for_button)) {
                Config.stage_id = 8;
                //Go to the 5th STG
                Application.LoadLevel("GameScene");
                //Application.LoadLevel("explain_stage_1");
            }
        }
        if (user_clear_stage > 3) {
            if (GUI.Button(new Rect(x_offset, y_offset + (bt_size_y + interval)*3, bt_size_x, bt_size_y),"10th STG", style_for_button)) {
                Config.stage_id = 9;
                //Go to the 4th STG
                Application.LoadLevel("GameScene");
                //Application.LoadLevel("explain_stage_1");
            }
        }
        if (user_clear_stage > 3) {
            if (GUI.Button(new Rect(x_offset + bt_size_x + interval, y_offset + (bt_size_y + interval)*3, bt_size_x, bt_size_y),"11th STG", style_for_button)) {
                Config.stage_id = 10;
                //Go to the 5th STG
                Application.LoadLevel("GameScene");
                //Application.LoadLevel("explain_stage_1");
            }
        }
        if (user_clear_stage > 3) {
            if (GUI.Button(new Rect(x_offset + (bt_size_x + interval)*2, y_offset + (bt_size_y + interval)*3, bt_size_x, bt_size_y),"12th STG", style_for_button)) {
                Config.stage_id = 11;
                //Go to the 5th STG
                Application.LoadLevel("GameScene");
                //Application.LoadLevel("explain_stage_1");
            }
        }
    }
}

