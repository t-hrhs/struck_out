using UnityEngine;
using System.Collections;

public class TopPage : MonoBehaviour {
    public GUISkin style;
    public GUIStyle style_for_title;
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
        style_for_title = new GUIStyle();
        style_for_title.fontSize = (int)80 * Config.s_height/1080;
        style_for_title.normal.textColor = Color.white;
        Rect rect = new Rect(10,10,(float)Config.s_width*0.9f,(float)Config.s_height * 0.12f);
        int x_offset = (int)(Config.s_width * 0.05);
        int y_offset = (int)(Config.s_height * 0.15);
        int tmp = (int)(Config.s_height * 0.85);
        int interval = 5;
        int bt_size_x = (int)((Config.s_width-x_offset * 2) - interval);
        int bt_size_y = (int)((Config.s_height-y_offset * 2)/6 - interval);
        GUI.Label(rect,"Kick Target", style_for_title);
        if (GUI.Button(new Rect(x_offset, tmp, bt_size_x, bt_size_y),"遊ぶ!!")) {
            Config.stage_id = 0;
            //Go to the 1st STG
            Application.LoadLevel("StageList");
            //Application.LoadLevel("explain_stage_1");
        }
    }
}
