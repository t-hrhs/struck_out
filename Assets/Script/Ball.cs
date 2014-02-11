using UnityEngine;
using System;
using System.Collections;

public class Ball : MonoBehaviour {
    public static Vector3 ball_standard_position = new Vector3(0.26f,0.25f,-14.3f);
    public static float power = 0;
    //Maxの曲がり具合が0.3くらいだと思う。
    public static float ac_max = 0.3f;
    public static float ac_x = 0.3f;
	// Use this for initialization
	void Start () {
	    power = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (
                (this.transform.position.z > 13.6f && this.rigidbody.velocity.magnitude < 1.0 ||
                 this.transform.position.x > 8 ||
                 this.transform.position.x < -8 ||
                 this.rigidbody.velocity.magnitude < 0.05f ||
                 this.rigidbody.velocity.z < 0) && 
                GameController.game_status == 1)  {
            this.rigidbody.angularVelocity = Vector3.zero;
            this.rigidbody.velocity = Vector3.zero;
            this.transform.position = ball_standard_position;
            GameController.game_status = 2;
        }
	}

    public void shoot(Vector3 start_pos, Vector3 end_pos, TimeSpan time) {
        ac_x = ac_max * (float)Pointer.ac_prop();
        Vector3 temp = DrawLine.ball_direction - GameController.ball_start_position;
        temp = new Vector3 (temp.x,Pointer.ball_height, temp.z);
        int time_evaluation = time_ev((int)time.TotalMilliseconds);
        int dis_evaluation = dis_ev((end_pos - start_pos).magnitude);
        power = (float)time_evaluation * dis_evaluation / 36 * 100;
        temp = temp.normalized * time_evaluation * dis_evaluation;
        this.rigidbody.velocity= temp;
    }

    void FixedUpdate() {
        if (GameController.game_status == 1) {
            float temp = (float)this.rigidbody.velocity.x + ac_x;
            this.rigidbody.velocity = new Vector3(temp, this.rigidbody.velocity.y, this.rigidbody.velocity.z);
        }
    }

    int time_ev(int milli_sec) {
        if (milli_sec < 200) {
            return 6;
        } else if (milli_sec < 400) {
            return 5;
        } else if (milli_sec < 600) {
            return 4;
        } else if (milli_sec < 800) {
            return 3;
        } else {
            return 2;
        }
    }

    int dis_ev(float distance) {
        float ball_panel_distance = GameController.ball_panel_distance;
        if (ball_panel_distance <= distance) {
            return 6;
        } else if(ball_panel_distance * 0.5 <= distance) {
            return 5;
        } else {
            return 4;
        }
    }
}
