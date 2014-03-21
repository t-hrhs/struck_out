using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
    public int move_type = 1;
    public int operate = 1;
    //1: 静止,2:上下, 3: 左 4:右
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        switch(move_type) {
            case 1:
                  //静止なので特に何もしない
                  break;
            case 2:
                  move_up_down();
                  break;
            case 3:
                  move_left_side();
                  break;
            case 4:
                  move_right_side();
                  break;
            default:
                  break;
        }
	}
    void move_up_down() {
        if (this.transform.position.y < 2.84f) {
            this.rigidbody.velocity = new Vector3(0.0f,10.0f,0.0f);
        }
    }
    void move_left_side() {
        Vector3 current_position = this.transform.position;
        float temp_x = current_position.x;
        if (operate == 1) {
            temp_x -= 0.05f;
        } else {
            temp_x += 0.05f;
        }
        this.transform.position = new Vector3(
            temp_x,
            current_position.y,
            current_position.z
        );
        if (this.transform.position.x > -0.8f) {
            operate = 1;
        }
        if (this.transform.position.x < -6.6f) {
            operate = 2;
        }
    }
    void move_right_side() {
        Vector3 current_position = this.transform.position;
        float temp_x = current_position.x;
        if (operate == 1) {
            temp_x += 0.05f;
        } else {
            temp_x -= 0.05f;
        }
        this.transform.position = new Vector3(
            temp_x,
            current_position.y,
            current_position.z
        );
        if (this.transform.position.x < 1.2f) {
            operate = 1;
        }
        if (this.transform.position.x > 7.0f) {
            operate = 2;
        }
    }
}
