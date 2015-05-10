using UnityEngine;
using System.Collections;

public class TopPage : MonoBehaviour {
    public GUIStyle style_for_title;
    public GUIStyle style_for_button;
    public int user_clear_stage = 0;
	// Use this for initialization
	void Start () {
        Screen.fullScreen = false;
        Application.targetFrameRate =  15;
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
        float bt_x_offset = Config.s_width  *  0.05f;
        float bt_y_offset = Config.s_height  *  0.90f;
        float bt_size_x = Config.s_width  * ((0.9f-0.05f*(2-1))/2);
        float bt_size_y = Config.s_height * 0.05f;
        if (GUI.Button(new Rect(bt_x_offset, bt_y_offset, bt_size_x, bt_size_y),"遊び方",style_for_button)) {
            Application.LoadLevel("HowToPlay");
        }
        if (GUI.Button(new Rect( bt_x_offset * 2 + bt_size_x, bt_y_offset, bt_size_x, bt_size_y),"遊ぶ!!",style_for_button)) {
            Config.stage_id = 0;
            //Go to the 1st STG
            Application.LoadLevel("StageList");
            //Application.LoadLevel("explain_stage_1");
        }
    }
}
