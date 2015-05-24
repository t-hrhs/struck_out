using UnityEngine;
using System;
using System.Collections;

public class ResultPage : MonoBehaviour {
    public GUIStyle style_for_title;
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
	
	}
    void OnGUI () {
        //TopPageに飛ぶ為のボタンを設置する
        style_for_title.fontSize = (int)80 * Config.s_height/1080;
        style_for_ranking.fontSize = (int) 50 * Config.s_height/1080;
        style_for_button.fontSize = (int)36 * Config.s_height/1080;
        Rect rect = new Rect(10,10,(float)Config.s_width * 0.9f ,(float)Config.s_height*0.1f);
        GUI.Label(rect,"Result",style_for_title);
        int x_offset = (int)(Config.s_width * 0.05);
        int y_offset = (int)(Config.s_height * 0.15);
        int interval = 5;
        if (GameController.is_cleared) {
            string temp = "クリア!!\n" + GameController.total_score.ToString() + "点獲得!!";
            GUI.Label(new Rect(20,(float)Config.s_height * 0.2f,(float)Config.s_width * 0.9f, (float)Config.s_height*0.25f),temp,style_for_title);
        } else {
            string temp = "残念!!\nクリアできず…";
            GUI.Label(new Rect(20,(float)Config.s_height * 0.2f,(float)Config.s_width * 0.9f, (float)Config.s_height*0.25f),temp,style_for_title);
        }
        if (GUI.Button(new Rect((float)Config.s_width*0.05f,Config.s_height * 0.85f,(int)((Config.s_width-x_offset * 2) - interval),(int)((Config.s_height-y_offset * 2)/6 - interval)),"TopPage",style_for_button)) {
            //TopPageに飛ぶ
            Application.LoadLevel("TopPage");
        }
        for (int i = 0; i < Config.user_high_score_num; i++) {
            int tmp_score = 0;
            String highscore_key = "user_score_" + (Config.stage_id + 1).ToString() + "_" + (i+1).ToString();
            if (PlayerPrefs.HasKey(highscore_key)) {
                tmp_score = PlayerPrefs.GetInt(highscore_key);
            }
            String temp;
            if (tmp_score > 0 && tmp_score == GameController.total_score) {
                temp = "Rank"  + (i+1).ToString() +  ":"  + tmp_score.ToString() + "点!!<- now updated\n";
            } else {
                temp = "Rank"  + (i+1).ToString() +  ":"  + tmp_score.ToString() + "点!!\n";
            }
            GUI.Label(new Rect(20,(float)Config.s_height * (0.50f + 0.05f *i),(float)Config.s_width * 0.9f, (float)Config.s_height*0.25f),temp,style_for_ranking);
        }
    }
}
