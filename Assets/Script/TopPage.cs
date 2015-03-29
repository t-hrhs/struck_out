using UnityEngine;
using System.Collections;

public class TopPage : MonoBehaviour {
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
        style_for_button.fontSize = (int)36 *  Config.s_height/1080;
        Rect rect = new Rect(10,10,(float)Config.s_width*0.9f,(float)Config.s_height * 0.12f);
        int x_offset = (int)(Config.s_width * 0.05);
        int y_offset = (int)(Config.s_height * 0.15);
        int tmp = (int)(Config.s_height * 0.85);
        int interval = 5;
        int bt_size_x = (int)((Config.s_width-x_offset * 2) - interval);
        int bt_size_y = (int)((Config.s_height-y_offset * 2)/6 - interval);
        if (GUI.Button(new Rect(x_offset, tmp, bt_size_x, bt_size_y),"遊ぶ!!",style_for_button)) {
            Config.stage_id = 0;
            //Go to the 1st STG
            Application.LoadLevel("StageList");
            //Application.LoadLevel("explain_stage_1");
        }
    }
}
