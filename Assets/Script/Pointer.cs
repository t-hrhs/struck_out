using UnityEngine;
using System.Collections;

public class Pointer : MonoBehaviour {
    public static Vector3 current_position;
    public static Vector3 center_position;
    public static float highest_y;
    public static float cylinder_radius;
    public static int height_max = 15;
	// Use this for initialization
	void Start () {
        center_position = GameObject.Find("Ball_Indicator").transform.position;
        current_position = center_position;
        cylinder_radius = GameObject.Find("Ball_Indicator").transform.localScale.x;
        float temp = center_position.y;
        highest_y = temp + cylinder_radius;
	}
	
	// Update is called once per frame
	void Update () {

    }
    public void change_position(Vector3 mouse_input) {
        this.transform.position = mouse_input;
        current_position = mouse_input;
        float direction_y = (highest_y - current_position.y)/cylinder_radius * height_max * 0.5f;
        Vector3 temp = DrawLine.ball_direction;
        DrawLine.ball_direction = new Vector3(
            temp.x,
            direction_y,
            temp.z
        );
    }
    public static double ac_prop() {
        return (double) -1 * (current_position.x-center_position.x)/cylinder_radius;
    }
}
