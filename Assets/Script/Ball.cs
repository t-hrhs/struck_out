using UnityEngine;
using System;
using System.Collections;

public class Ball : MonoBehaviour {
    public static Vector3 ball_standard_position = new Vector3(0.26f,0.25f,-14.3f);
    public static float power = 0;
    AudioSource audioSource;
    public AudioClip normal_sound;
    public AudioClip target_sound;
    public AudioClip shout_sound;
    //Maxの曲がり具合が0.3くらいだと思う。
    public static float ac_max = 0.3f;
    public static float ac_x = 0.3f;
	// Use this for initialization
	void Start () {
        audioSource = this.GetComponent<AudioSource>();
	    power = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (
                (this.transform.position.z > 12.0f && this.rigidbody.velocity.magnitude < 2.0 ||
                 this.transform.position.x > 13 ||
                 this.transform.position.x < -8 ||
                 this.rigidbody.velocity.magnitude < 0.1f ||
                 this.rigidbody.velocity.z < 0) && 
                GameController.game_status == 1)  {
            this.rigidbody.angularVelocity = Vector3.zero;
            this.rigidbody.velocity = Vector3.zero;
            this.transform.position = ball_standard_position;
            GameController.game_status = 2;
        }
	}

    /*public void shoot(Vector3 start_pos, Vector3 end_pos, TimeSpan time) {
        ac_x = ac_max * (float)Pointer.ac_prop();
        Vector3 temp = DrawLine.ball_direction - GameController.ball_start_position;
        temp = new Vector3 (temp.x,Pointer.ball_height, temp.z);
        int time_evaluation = time_ev((int)time.TotalMilliseconds);
        int dis_evaluation = dis_ev((end_pos - start_pos).magnitude);
        power = (float)time_evaluation * dis_evaluation / 36 * 100;
        temp = temp.normalized * time_evaluation * dis_evaluation;
        this.rigidbody.velocity= temp;
    }*/
    public void shoot() {
        ac_x = ac_max * (float)Pointer.ac_prop();
        Vector3 temp = DrawLine.ball_direction - GameController.ball_start_position;
        temp = new Vector3(temp.x,Pointer.ball_height, temp.z);
        //power = 24;
        temp = temp.normalized * power * 0.36f;
        this.rigidbody.velocity = temp;
        audioSource.clip = shout_sound;
        audioSource.Play();
    }

    void FixedUpdate() {
        if (GameController.game_status == 1) {
            float temp = (float)this.rigidbody.velocity.x + ac_x;
            this.rigidbody.velocity = new Vector3(temp, this.rigidbody.velocity.y, this.rigidbody.velocity.z);
        }
    }

    //パネルに衝突した際に効果音を導入する
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Panel") {
            Panel panel = collision.gameObject.GetComponent<Panel>();
            if (!panel.clear_flag && panel.point > 1000 ) {
                GameController.panel_num_per_action++;
                GameController.score_per_action+=panel.point;
                audioSource.clip = target_sound;
                audioSource.Play();
            }
            else if(!panel.clear_flag) {
                GameController.panel_num_per_action++;
                GameController.score_per_action+=panel.point;
                audioSource.clip = normal_sound;
                audioSource.Play();
            }
        }
    }
}
