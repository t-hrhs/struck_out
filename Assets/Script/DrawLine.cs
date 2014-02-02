using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {
    private LineRenderer lineRenderer;
    private Vector3 ball_position;
    public static Vector3 ball_direction = new Vector3(1,1,1);
	// Use this for initialization
	void Start () {
	    lineRenderer = GetComponent<LineRenderer>();
        ball_position = GameObject.Find("Ball").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(ball_direction);
        if (GameController.game_status==0) {
            //TODO : fpsがつらくなったらここはpositionを固定にする
            lineRenderer.enabled = true;
	        lineRenderer.SetPosition(0, ball_position);
            lineRenderer.SetPosition(1, ball_direction);
        } else {    //ボールが動いている場合は表示しない
            lineRenderer.enabled = false;
        }
	}
}
