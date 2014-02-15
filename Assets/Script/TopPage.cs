using UnityEngine;
using System.Collections;

public class TopPage : MonoBehaviour {
    public GUISkin style;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnGUI () {
        //説明画面に飛ぶ為のボタンを設置する
        GUI.skin = style;
        //ボタンの色の都合(あまり意味はない)
        GUI.backgroundColor = Color.yellow;
        Rect rect = new Rect(10,10,800,100);
        GUI.Label(rect,"Kick Target");
        if (GUI.Button(new Rect(25, 150, 180, 150),"1st STG")) {
            Config.stage_id = 0;
            //Go to the 1st STG
            Application.LoadLevel("GameScene");
            //Application.LoadLevel("explain_stage_1");
        }
        else if (GUI.Button(new Rect(210, 150, 180, 150),"2nd STG")) {
            Config.stage_id = 1;
            //Go to the 2nd STG
            Application.LoadLevel("GameScene2");
            //Application.LoadLevel("explain_stage_1");
        }
    }

}
