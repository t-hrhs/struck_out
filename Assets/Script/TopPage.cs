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
            //Go to the 1st STG
            Application.LoadLevel("GameScene");
            //Application.LoadLevel("explain_stage_1");
        }
    }

}
