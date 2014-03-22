using UnityEngine;
using System.Collections;

public class Pointer : MonoBehaviour {
    public static Vector3 current_position;
    public static Vector3 center_position;
    public static float cyclinder_radius;
    public static float pointer_radius;
    public static float ball_height;
    public static Vector3[] positions;
	// Use this for initialization
	void Start () {
        center_position = GameObject.Find("Ball_Indicator").transform.position;
        current_position = center_position;
        cyclinder_radius = GameObject.Find("Ball_Indicator").transform.localScale.x/2;
        pointer_radius = this.transform.localScale.x/2;
        positions = new Vector3[13];
        float temp = center_position.z - 0.005f;
        positions[0] = new Vector3(
            center_position.x,
            center_position.y + cyclinder_radius - pointer_radius,
            temp
        );
        positions[1] = new Vector3(
            center_position.x - 0.75f * cyclinder_radius,
            center_position.y + cyclinder_radius * 0.5f,
            temp
        );
        positions[2] = new Vector3(
            center_position.x,
            center_position.y + cyclinder_radius * 0.5f,
            temp
        );
        positions[3] = new Vector3(
            center_position.x + 0.75f * cyclinder_radius,
            center_position.y + cyclinder_radius * 0.5f,
            temp
        );
        positions[4] = new Vector3(
            center_position.x - cyclinder_radius + pointer_radius,
            center_position.y,
            temp
        );
        positions[5] = new Vector3(
            center_position.x - cyclinder_radius * 0.5f,
            center_position.y,
            temp
        );
        positions[6] = new Vector3(
            center_position.x,
            center_position.y,
            temp
        );
        positions[7] = new Vector3(
            center_position.x + cyclinder_radius * 0.5f,
            center_position.y,
            temp
        );
        positions[8] = new Vector3(
            center_position.x + cyclinder_radius - pointer_radius,
            center_position.y,
            temp
        );
        positions[9] = new Vector3(
            center_position.x - cyclinder_radius * 0.75f,
            center_position.y - cyclinder_radius * 0.5f,
            temp
        );
        positions[10] = new Vector3(
            center_position.x,
            center_position.y - cyclinder_radius * 0.5f,
            temp
        );
        positions[11] = new Vector3(
            center_position.x + cyclinder_radius * 0.75f,
            center_position.y - cyclinder_radius * 0.5f,
            temp
        );
        positions[12] = new Vector3(
            center_position.x,
            center_position.y - cyclinder_radius + pointer_radius,
            temp
        );
	}
	
	// Update is called once per frame
	void Update () {

    }
    public void change_position(Vector3 mouse_input) {
        mouse_input = new Vector3(
            mouse_input.x,
            mouse_input.y,
            center_position.z
        );
        int min_index = 0;
        float min_length = (mouse_input - positions[0]).magnitude;
        for (int i = 0;i<13;i++) {
            if (min_length > (mouse_input - positions[i]).magnitude) {
                min_index = i;
                min_length = (mouse_input - positions[i]).magnitude;
            }
        }
        this.transform.position = positions[min_index];
        current_position = positions[min_index];
        ball_height = GameController.max_height * (center_position.y + cyclinder_radius - current_position.y) /cyclinder_radius * 0.5f;
    }
    public static double ac_prop() {
        return (double) -1 * (current_position.x-center_position.x)/cyclinder_radius;
    }
}
