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
    public static int base_power = 50;
    public static float ac_coefficient;
    //Maxの曲がり具合が0.3くらいだと思う。
    public static float ac_max = 0.25f;
    public static float ac_x = 0.25f;
	// Use this for initialization
	void Start () {
        audioSource = this.GetComponent<AudioSource>();
        ac_coefficient = 0;
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
    public void shoot(
        Vector3 flick_start_position,
        Vector3 flick_end_position,
        Vector3[] flick_positions,
        int flick_update_num,
        float ms
    ) {
        //横向きの加速度の決定
        Vector3 turning_point = _calculate_turning_point(flick_start_position, flick_end_position, flick_positions, flick_update_num);
        ac_x = ac_max * ac_coefficient;

        //ac_x = ac_max * (float)Pointer.ac_prop();
        //ac_x = ac_max;
        //初速のベクトルの決定
        power = 100 * (1000 - ms)/1000;
        if (power < 24) {
            power = 24;
        }
        Vector3 temp = turning_point-flick_start_position;
        float rate = GameController.ball_panel_distance / temp.z;
        temp = new Vector3(temp.x * rate, 20.0f * power/100 ,temp.z * rate);
        temp = (temp.normalized * base_power + temp.normalized * power * (1 - base_power * 0.01f)) * 0.28f;
        //temp = temp.normalized * power * 0.36f;
        this.rigidbody.velocity = temp;
        audioSource.clip = shout_sound;
        audioSource.Play();
    }

    Vector3 _calculate_turning_point(Vector3 flick_start_position, Vector3 flick_end_position, Vector3[] flick_positions, int flick_num) {
        float temp_coef = 0;
        Vector3 answer = flick_end_position;
        for (int i = 0; i < flick_num; i++) {
            Vector3 line_direction = flick_end_position-flick_start_position;
            Vector3 point_direction = flick_positions[i] -flick_start_position;
            Debug.Log(line_direction);
            Debug.Log(point_direction);
            Debug.Log(Vector3.Cross(line_direction,point_direction));
            Vector3 area_vect = Vector3.Cross(line_direction, point_direction);
            float area = area_vect.magnitude;
            Debug.Log(area);
            //float area = (Vector3.Cross(line_direction, point_direction)).magnitude;
            float height = area / line_direction.magnitude;
            if (System.Math.Abs(temp_coef) < height) {
                if (point_direction.x - line_direction.x > 0) {
                    temp_coef = -height;
                } else {
                    temp_coef = height;
                }
                answer = flick_positions[i];
            }
            Debug.Log(temp_coef);
        }
        Debug.Log(temp_coef);
        //人間の操作誤差の抹消
        if (System.Math.Abs(temp_coef) < 10) {
            temp_coef = 0;
        }
        ac_coefficient = temp_coef/10; //10は適当な係数調整
        return answer;
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
                GameController.does_target_hit = true;
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
