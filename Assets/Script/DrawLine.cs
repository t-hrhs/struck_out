using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {
    private LineRenderer lineRenderer;
    public static Vector3 ball_direction;
	// Use this for initialization
	void Start () {
	    lineRenderer = GetComponent<LineRenderer>();
        ball_direction = new Vector3(GameController.ball_start_position.x,GameController.ball_start_position.y,12.5f);
	}
	
	// Update is called once per frame
	void Update () {
	    if (GameController.game_status == 0) {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0,GameController.ball_start_position);
            lineRenderer.SetPosition(1,ball_direction);
        } else {
            lineRenderer.enabled = false;
        }
	}
}
