using UnityEngine;
using System.Collections;
using System;

public class HowToPlay : MonoBehaviour {
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
      if(Input.GetMouseButtonDown(0)) {
        GameObject touched_object = get_touch_object();
        if (touched_object.tag == "top_button") {
          Application.LoadLevel("TopPage");
        }
      }
    }

    void OnGUI () {
        Rect left_arrow = new Rect(
            (int)(Config.s_width * 0.53),
            (int)(Config.s_height * 0.91),
            (int)(Config.s_width * 0.1),
            (int)(Config.s_height * 0.05)
        );
        Rect right_arrow = new Rect(
            (int)(Config.s_width * 0.83),
            (int)(Config.s_height * 0.91),
            (int)(Config.s_width * 0.1),
            (int)(Config.s_height * 0.05)
            );
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
    GameObject get_touch_object() {
      //マウスカーソルからのRay発射
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      // tagのついているobjectをタッチした場合
      if (Physics.Raycast(ray, out hit)) {
        if (hit.collider.gameObject.tag != "") {
          return hit.collider.gameObject;
        }
      }
      return null;
    }
}
