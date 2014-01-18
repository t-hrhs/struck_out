using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    Vector3 flick_start = Vector3.zero;
    Vector3 flick_end = Vector3.zero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    //フリック開始判定
        if (Input.GetMouseButtonDown(0)) {
            flick_start = get_touch_point();
            flick_start.y = 0.0f;
        }
        //フリック開始終了
        if (Input.GetMouseButtonUp(0)) {
            flick_end = get_touch_point();
            GameObject ball = GameObject.Find("Ball");
            Ball ball_script = ball.GetComponent<Ball>();
            ball_script.shoot(flick_start, flick_end, 1);
            flick_start = Vector3.zero;
            flick_end = Vector3.zero;
        }
	}

    Vector3 get_touch_point() {
        //マウスカーソルからのRay発射
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (!hit.collider.gameObject) {
                //衝突したオブジェクトがなければ暫定的に原点を返す
                Debug.Log("Ray doesn\'t hit the object!!");
                return Vector3.zero;
            }
            //衝突したオブジェクトがある場合はその地点の座標を取得
            Vector3 hit_point = hit.point;
            return hit_point;
        }
        Debug.Log("fatal error");
        return Vector3.zero;
    }
}
