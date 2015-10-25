using UnityEngine;
using System;
using System.Collections;

public class ResultPage : MonoBehaviour {
    public GUIStyle style_for_ranking;
    public GUIStyle style_for_button;
    AudioSource audioSource;
	// Use this for initialization
	void Start () {
	    audioSource = this.GetComponent<AudioSource>();
        audioSource.Play();
	}

	// Update is called once per frame
	void Update () {
    if (Input.GetMouseButtonUp(0)) {
      GameObject touched_object = get_touch_object();
      if (touched_object.tag == "stage_list_btn") {
        Config.stage_id = 0;
        Application.LoadLevel("StageList");
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

  void OnGUI () {
    //TopPageに飛ぶ為のボタンを設置する
    style_for_ranking.fontSize = (int) 50 * Config.s_height/1080;
    style_for_button.fontSize = (int)36 * Config.s_height/1080;
    Rect rect = new Rect(
      (float)Config.s_width*0.65f,
      (float)Config.s_height*0.155f,
      (float)Config.s_width * 0.1f,
      (float)Config.s_height*0.1f
    );
    int current_score = GameController.total_score;
    String current_score_str = current_score.ToString();
    GUI.Label(rect,current_score_str,style_for_ranking);
    for (int i = 0; i < Config.user_high_score_num; i++) {
  		int tmp_score = 0;
    	String highscore_key = "user_score_" + (Config.stage_id +1).ToString() + "_" + (i+1).ToString();
    	int score = 0;
    	if (PlayerPrefs.HasKey(highscore_key)) {
  			score = PlayerPrefs.GetInt(highscore_key);
  		}
  		GUI.Label(new Rect(
  			(float)Config.s_width * 0.58f,
  			(float)Config.s_height * (0.25f + 0.12f *i),
  			(float)Config.s_width * 0.9f,
  			(float)Config.s_height*0.25f),
  			score.ToString(),
  			style_for_ranking
  		);
  	}
  }
}
