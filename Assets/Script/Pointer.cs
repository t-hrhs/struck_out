using UnityEngine;
using System.Collections;

public class Pointer : MonoBehaviour {
    public static Vector3 current_position;
    public static Vector3 center_position;
    public static float cyclinder_radius;
    public static float ball_height;
	// Use this for initialization
	void Start () {
        center_position = GameObject.Find("Ball_Indicator").transform.position;
        current_position = center_position;
        cyclinder_radius = GameObject.Find("Ball_Indicator").transform.localScale.x/2;
	}
	
	// Update is called once per frame
	void Update () {

    }
    public void change_position(Vector3 mouse_input) {
        this.transform.position = mouse_input;
        current_position = mouse_input;
        ball_height = GameController.max_height * (center_position.y + cyclinder_radius - current_position.y) /cyclinder_radius * 0.5f;
    }
    public static double ac_prop() {
        return (double) -1 * (current_position.x-center_position.x)/cyclinder_radius;
    }
}
