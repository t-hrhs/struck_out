using UnityEngine;
using System.Collections;

public class TopPage : MonoBehaviour {
    public GUIStyle style_for_title;
    public GUIStyle style_for_button;
    public int user_clear_stage = 0;
	// Use this for initialization
	void Start () {
        Screen.fullScreen = false;
        Application.targetFrameRate =  45;
        if (PlayerPrefs.HasKey("user_stage")) {
            user_clear_stage = PlayerPrefs.GetInt("user_stage");
        }
	}

	// Update is called once per frame
	void Update () {
    if(Input.GetMouseButtonDown(0)) {
      GameObject touched_object = get_touch_object();
      if (touched_object.tag == "how_to_btn") {
        Application.LoadLevel("HowToPlay");
      } else if (touched_object.tag == "start_btn") {
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
}
