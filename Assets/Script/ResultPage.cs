using UnityEngine;
using System.Collections;

public class ResultPage : MonoBehaviour {
    public GUISkin style;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI () {
        //TopPageに飛ぶ為のボタンを設置する
        GUI.skin = style;
        //ボタンの色の都合(あまり意味はない)
        GUI.backgroundColor = Color.yellow;
        Rect rect = new Rect(10,10,600,100);
        GUI.Label(rect,"Result");
        if (GameController.is_cleared) {
            string temp = "クリア!!\n" + GameController.total_score.ToString() + "点\n獲得!!";
            GUI.Label(new Rect(20,200,600,300),temp);
        } else {
            string temp = "残念!!\nクリアできず…";
            GUI.Label(new Rect(20,200,600,300),temp);
        }
        if (GUI.Button(new Rect(100,900,440,150),"TopPage")) {
            //TopPageに飛ぶ
            Application.LoadLevel("TopPage");
        }
    }
}
