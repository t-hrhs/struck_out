using UnityEngine;
using System;
using System.Collections;

public class StageList : MonoBehaviour {
    public int user_clear_stage = 0;
    public GUIStyle style_for_left_arrow;
    public GUIStyle style_for_left_arrow_disable;
    public GUIStyle style_for_right_arrow;
    public GUIStyle style_for_right_arrow_disable;
    public int page=0;
    public int page_num = 2;
    public StageAbs[] stage_list = new StageAbs[StageListManager.stage_num_per_page];
    public HighScore[] high_score_list = new HighScore[StageListManager.stage_num_per_page];
    // Use this for initialization
    void Start () {
        Application.targetFrameRate =  45;
        if (PlayerPrefs.HasKey("user_stage")) {
            user_clear_stage = PlayerPrefs.GetInt("user_stage");
        }
        page = 0;
        stage_list = StageListManager.make_stage_list_obj (page, user_clear_stage);
        high_score_list = StageListManager.make_high_score_list_obj (page, user_clear_stage);
    }

    // Update is called once per frame
    void Update () {
      if(Input.GetMouseButtonDown(0)) {
        GameObject touched_object = get_touch_object();
        if (touched_object.tag == "top_button") {
          Application.LoadLevel("TopPage");
        } else if (touched_object.tag == "StageAbs") {
          StageAbs hit_stage_abs = touched_object.GetComponent<StageAbs>();
          Config.stage_id = hit_stage_abs.stage_id;
          Application.LoadLevel("GameScene");
        } else if (touched_object.tag == "high_score") {
          HighScore high_score = touched_object.GetComponent<HighScore>();
          Config.ranking_stage_id = high_score.stage_id;
          Application.LoadLevel("Ranking");
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
            StageListManager.destroyAll(stage_list, high_score_list);
            stage_list = StageListManager.make_stage_list_obj (page, user_clear_stage);
            high_score_list = StageListManager.make_high_score_list_obj (page, user_clear_stage);
          }
      }
      if (page + 1 == page_num) {
          if(GUI.Button(right_arrow, "", style_for_right_arrow_disable)) {
            //nothing to do
          }
      } else {
          if(GUI.Button(right_arrow, "", style_for_right_arrow)) {
            page++;
            StageListManager.destroyAll(stage_list, high_score_list);
            stage_list = StageListManager.make_stage_list_obj (page, user_clear_stage);
            high_score_list = StageListManager.make_high_score_list_obj (page, user_clear_stage);
          }
      }
    }

    //タッチしたobjectのタグを返す
    //TODO : Utilに持っていきたい
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
