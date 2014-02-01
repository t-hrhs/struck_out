using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public static Vector3 ball_standard_position = new Vector3(0.26f,0.25f,-11.0f);
    //Maxの曲がり具合が0.3くらいだと思う。
    public static float ac_max = 0.3f;
    public static float ac_x = 0.3f;
	// Use this for initialization
	void Start () {
	
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

    public void shoot(Vector3 start_pos, Vector3 end_pos, double time) {
        ac_x = ac_max * (float)Pointer.ac_prop();
        this.rigidbody.velocity= (end_pos - start_pos).normalized * 25;
    }

    void FixedUpdate() {
        if (GameController.game_status == 1) {
            float temp = (float)this.rigidbody.velocity.x + ac_x;
            this.rigidbody.velocity = new Vector3(temp, this.rigidbody.velocity.y, this.rigidbody.velocity.z);
        }
    }
}
