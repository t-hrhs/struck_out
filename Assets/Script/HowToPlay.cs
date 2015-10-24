using UnityEngine;
using System.Collections;
using System;

public class HowToPlay : MonoBehaviour {
    public GUIStyle style_for_button;
    public GUIStyle style_for_left_arrow;
    public GUIStyle style_for_left_arrow_disable;
    public GUIStyle style_for_right_arrow;
    public GUIStyle style_for_right_arrow_disable;
    public int page=0;
    public int page_num = 2;
    private static String how_to_bg_base_path = "Img/how_to_page0";
    // Use this for initialization
    void Start () {
        page=0;
    }

    // Update is called once per frame
    void Update () {

    }

    void OnGUI () {
        Rect rect = new Rect(10,10,(float)Config.s_width*0.9f,(float)Config.s_height * 0.12f);
        Rect left_arrow = new Rect(
            (int)(Config.s_width * 0.53),
            (int)(Config.s_height * 0.89),
            (int)(Config.s_width * 0.1),
            (int)(Config.s_height * 0.05)
        );
        Rect right_arrow = new Rect(
            (int)(Config.s_width * 0.83),
            (int)(Config.s_height * 0.89),
            (int)(Config.s_width * 0.1),
            (int)(Config.s_height * 0.05)
            );
        style_for_button.fontSize = (int)36 * Config.s_height/1080;
        int x_offset = (int)(Config.s_width * 0.05);
        int y_offset = (int)(Config.s_height * 0.15);
        int tmp = (int)(Config.s_height * 0.85);
        int interval = 5;
        int bt_size_x = (int)((Config.s_width - x_offset * 2)/4 - interval);
        int bt_size_y = (int)((Config.s_height - y_offset * 2)/8 - interval);
        if(GUI.Button(new Rect(x_offset, tmp, bt_size_x, bt_size_y), "Top", style_for_button)) {
            Application.LoadLevel("TopPage");
        }
         //  pager
        if (page  == 0) {
          if(GUI.Button(left_arrow, "", style_for_left_arrow_disable)) {
                //nothing to do
           }
        } else {
            if(GUI.Button(left_arrow, "", style_for_left_arrow)) {
                page--;
                GameObject how_to_bg = GameObject.Find ("HowToBg");
                String next_bg_path = how_to_bg_base_path + (page + 1);
                Texture2D tex = (Texture2D) Resources.Load(next_bg_path, typeof(Texture2D));
                HowToBg how_to_bg_obj = how_to_bg.GetComponent<HowToBg>();
                how_to_bg_obj.GetComponent<Renderer>().material.mainTexture = tex;
            }
        }
        if (page + 1 == page_num) {
            if(GUI.Button(right_arrow, "", style_for_right_arrow_disable)) {
                 //nothing to do
            }
        } else {
            if(GUI.Button(right_arrow, "", style_for_right_arrow)) {
                page++;
                GameObject how_to_bg = GameObject.Find ("HowToBg");
                String next_bg_path = how_to_bg_base_path + (page + 1);
                Texture2D tex = (Texture2D) Resources.Load(next_bg_path, typeof(Texture2D));
                HowToBg how_to_bg_obj = how_to_bg.GetComponent<HowToBg>();
                how_to_bg_obj.GetComponent<Renderer>().material.mainTexture = tex;
            }
        }
    }
}
