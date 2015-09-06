using UnityEngine;
using System;
using System.Collections;

public class Ranking : MonoBehaviour {
	public GUIStyle style_for_title;
	public GUIStyle style_for_ranking;
	public GUIStyle style_for_button;
	public int stage_id = 0;
	// Use this for initialization
	void Start () {
		// ranking_stage_idをconfigから取得
		stage_id = Config.ranking_stage_id;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			GameObject touched_object = get_touch_object();
			if (touched_object.tag == "back_button") {
				Application.LoadLevel("TopPage");
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
		//現在表示しているrankingのstage名を表示
		style_for_title.fontSize = (int)60 * Config.s_height/1080;
		style_for_title.normal.textColor = Color.white;
		Rect rect = new Rect(
			10,
			(float)Config.s_height*0.15f,
			(float)Config.s_width*0.9f,
			(float)Config.s_height * 0.12f
		);
		String current_stage_num = "Stage" + (stage_id+1).ToString();
		GUI.Label(rect,current_stage_num, style_for_title);
		//local内部に保存しているランキング情報にアクセス
		for (int i = 0; i < Config.user_high_score_num; i++) {
			int tmp_score = 0;
			String highscore_key = "user_score_" + (stage_id +1).ToString() + "_" + (i+1).ToString();
			int score = 0;
			if (PlayerPrefs.HasKey(highscore_key)) {
				score = PlayerPrefs.GetInt(highscore_key);
			}
			GUI.Label(new Rect(
				(float)Config.s_width * 0.58f,
				(float)Config.s_height * (0.25f + 0.12f *i),
				(float)Config.s_width * 0.9f,
				(float)Config.s_height*0.25f),
				score.ToString() + "点",
				style_for_ranking
			);
		}
	}
}
