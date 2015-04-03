using UnityEngine;
using System.Collections;

public class HowToPlay : MonoBehaviour {
    public GUIStyle style_for_title;
    public GUIStyle style_for_explain;
    public GUIStyle style_for_button;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    void OnGUI () {
        //説明画面に飛ぶ為のボタンを設置する
        //TODO : Configに部分ごとのfontサイズを管理する
        style_for_title.fontSize = (int)80 * Config.s_height/1080;
        style_for_title.normal.textColor = Color.white;
        Rect rect = new Rect(10,10,(float)Config.s_width*0.9f,(float)Config.s_height * 0.12f);
        GUI.Label(rect,"遊び方", style_for_title);
        //説明文言の為のstyle
        style_for_explain.fontSize = (int)36 * Config.s_height/1080;
        style_for_explain.normal.textColor = Color.white;
        Rect expl1 = new Rect(
                10,
                (float)Config.s_height * 0.13f,
                (float)Config.s_width*0.9f,
                (float)Config.s_height * 0.06f
        );
        GUI.Label(expl1, "1. まずはボールの蹴る位置を決めよう", style_for_explain);
        Rect expl2 = new Rect(
                (float)Config.s_width * 0.10f,
                (float)Config.s_height * 0.35f,
                (float)Config.s_width * 0.9f,
                (float)Config.s_height * 0.12f
        );
        GUI.Label(expl2, "蹴る位置によってボールの軌道が\n変わるぞ", style_for_explain);
        Rect expl3 = new Rect(
                10,
                (float)Config.s_height * 0.55f,
                (float)Config.s_width*0.9f,
                (float)Config.s_height * 0.06f
        );
        GUI.Label(expl3, "2. 簡単フリック操作でボールを蹴りだそう", style_for_explain);
        Rect expl4 = new Rect(
                (float)Config.s_width * 0.10f,
                (float)Config.s_height * 0.75f,
                (float)Config.s_width * 0.9f,
                (float)Config.s_height * 0.12f
        );
        GUI.Label(expl4, "フリックの速さによって蹴る強さが\n変わるぞ", style_for_explain);
        style_for_button.fontSize = (int)36 * Config.s_height/1080;
        int x_offset = (int)(Config.s_width * 0.05);
        int y_offset = (int)(Config.s_height * 0.15);
        int tmp = (int)(Config.s_height * 0.85);
        int interval = 5;
        int bt_size_x = (int)((Config.s_width - x_offset * 2) - interval);
        int bt_size_y = (int)((Config.s_height - y_offset * 2)/6 - interval);
        if(GUI.Button(new Rect(x_offset, tmp, bt_size_x, bt_size_y), "Top", style_for_button)) {
            Application.LoadLevel("TopPage");
        }
    }
}

