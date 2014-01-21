using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public static Vector3 ball_standard_position = new Vector3(0.26f,0.25f,-14.3f);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if ((this.rigidbody.velocity == Vector3.zero || this.rigidbody.velocity.z < 0) && GameController.game_status == 1)  {
            this.rigidbody.angularVelocity = Vector3.zero;
            this.rigidbody.velocity = Vector3.zero;
            this.transform.position = ball_standard_position;
            GameController.game_status = 2;
        }
	}

    public void shoot(Vector3 start_pos, Vector3 end_pos, double time) {
        this.rigidbody.velocity= (end_pos - start_pos).normalized * 25;
    }
}
