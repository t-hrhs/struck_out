using UnityEngine;
using System;
using System.Collections;

public class StageListManager {
    public static int stage_num_per_page = 8;
    private static String stage_list_base_path = "Img/stage_list/stage_";
    private static Vector3 base_postion = new Vector3(-2.5f, 1.16f, 4.43f);
    private static Vector3 base_scale = new Vector3(0.4f, 1.00f, 0.24f);
    private static Vector3 high_score_base_postion = new Vector3(-0.83f, 3.77f, 2.14f);
    private static Vector3 high_score_base_scale = new Vector3(0.04f, 0.04f, 0.04f);
    private static float x_offset = 5.00f;
    private static float z_offset = 3.00f;
    private static float high_score_x_offset = 4.00f;
    private static float high_score_z_offset = 2.40f;
    private static int max_page_num = (int)12/8;
    public static StageAbs[] make_stage_list_obj (int page, int user_progress) {
        StageAbs[] answer;
        answer = new StageAbs[stage_num_per_page];
        if ( page*stage_num_per_page >= user_progress ) {
            page = (int)user_progress/stage_num_per_page;
        }
        if (max_page_num < page) {
            page = max_page_num;
        }
        for  (int i=0; i< stage_num_per_page; i++) {
            String test = "Prefab/StageAbs";
            GameObject stage_abs = GameObject.Instantiate(
                Resources.Load(test),
                new Vector3(0,0,0),
                Quaternion.identity
            ) as GameObject;
            stage_abs.transform.position = new Vector3(
                base_postion.x + x_offset * (i%2),
                base_postion.y,
                base_postion.z - z_offset * (i/2)
            );
            stage_abs.transform.localScale = base_scale;
            StageAbs stage_abs_obj = stage_abs.GetComponent<StageAbs> ();
            stage_abs_obj.stage_id = page * stage_num_per_page + i;
            String test2 = stage_list_base_path + (page*stage_num_per_page + i+1);
            Texture2D tex = (Texture2D) Resources.Load(test2, typeof(Texture2D));
            stage_abs.GetComponent<Renderer>().material.mainTexture = tex;
            stage_abs_obj.transform.rotation = Quaternion.Euler( 0,180,0 );
            answer[i] = stage_abs_obj;
            if (page*stage_num_per_page + i + 1 > user_progress || page*stage_num_per_page + i + 1 >= Config.total_stage_num) {
                break;
            }
        }
        return answer;
    }
    public static HighScore[] make_high_score_list_obj (int page, int user_progress) {
      HighScore[] high_score_list;
      high_score_list = new HighScore[stage_num_per_page];
      if ( page*stage_num_per_page >= user_progress ) {
          page = (int)user_progress/stage_num_per_page;
      }
      if (max_page_num < page) {
          page = max_page_num;
      }
      for  (int i=0; i< stage_num_per_page; i++) {
          String test = "Prefab/HighScore";
          GameObject high_score = GameObject.Instantiate(
              Resources.Load(test),
              new Vector3(0,0,0),
              Quaternion.identity
          ) as GameObject;
          high_score.transform.position = new Vector3(
              high_score_base_postion.x + high_score_x_offset * (i%2),
              high_score_base_postion.y,
              high_score_base_postion.z - high_score_z_offset * (i/2)
          );
          high_score.transform.localScale = high_score_base_scale;
          HighScore high_score_obj = high_score.GetComponent<HighScore> ();
          high_score_obj.stage_id = page * stage_num_per_page + i;
          //TODO : high_scoreを取得し、3Dtextの値を0から更新
          String highscore_key = "user_score_" + (high_score_obj.stage_id +1).ToString() + "_1";
          if (PlayerPrefs.HasKey(highscore_key)) {
            high_score.GetComponent<TextMesh>().text = PlayerPrefs.GetInt(highscore_key).ToString();
          }
          high_score.transform.rotation = Quaternion.Euler( 90,0,0 );
          high_score_list[i] = high_score_obj;
          if (page*stage_num_per_page + i + 1 > user_progress || page*stage_num_per_page + i + 1 >= Config.total_stage_num) {
              break;
          }
      }
      return high_score_list;
    }
    public static bool should_show_next_page(int page,int user_progress) {
        max_page_num = (int)user_progress/stage_num_per_page;
        if (page < max_page_num) {
            return true;
        }
        return false;
    }
    public static bool should_show_prev_page(int page,int user_progress) {
        if (page < 1) {
            return false;
        }
        return true;
    }
    public static void destroyAll(StageAbs[] stage_list, HighScore[] high_score_list) {
        for (int i = 0; i < stage_num_per_page; i++) {
            if (stage_list[i] != null) {
              StageAbs.Destroy(stage_list[i].gameObject);
              stage_list[i] = null;
            }
            if (high_score_list[i] != null) {
              HighScore.Destroy(high_score_list[i].gameObject);
              high_score_list[i] = null;
            }
        }
    }
}
