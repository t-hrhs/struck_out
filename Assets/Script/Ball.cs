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
    //水平方向の加速度の定数(カーブ実現のため)。
    //TODO : 定数なのでfinalを使いたい
    public static float ac_max = 0.20f;
    public static float ac_x = 0.20f;
    /*-------------------------------
    ball_type : 球種を保持する変数
    0 : 直進ボール
    1 : right_curve(ac_xをマイナスにする)
    2 : left_curve(ac_xをプラスにする)
     --------------------------------*/
    public static int ball_type = 0;
    // Use this for initialization
    void Start () {
        audioSource = this.GetComponent<AudioSource>();
        power = 0;
        ball_type = 0;
    }

    // Update is called once per frame
    void Update () {
        if (
            (
                this.transform.position.z > 12.0f && this.GetComponent<Rigidbody>().velocity.magnitude < 2.0 ||
                this.transform.position.x > 13 ||
                this.transform.position.x < -8 ||
                this.GetComponent<Rigidbody>().velocity.magnitude < 0.1f ||
                this.GetComponent<Rigidbody>().velocity.z < 0
            ) &&
            GameController.game_status == 1
        )  {
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.transform.position = ball_standard_position;
            GameController.game_status = 2;
        }
    }
    public void shoot(
        Vector3 flick_start_position,
        Vector3 flick_end_position,
        int total_ms
    ) {
        //横向きの加速度の決定(蹴り始めた座標で決定する)
        ac_x = ac_max * (float)Pointer.ac_prop();
        //初速のベクトルの決定
        if (total_ms < 150) {
            power = 100;
        } else if (total_ms < 300) {
            power = 90;
        } else if (total_ms < 400) {
            power = 75;
        } else if (total_ms < 500) {
            power = 50;
        } else {
            power = 30;
        }
        Vector3 temp = flick_end_position-flick_start_position;
        float v_y = Pointer.ball_height;
        Vector3 v_x_z = new Vector3(temp.x, 0, temp.z);
        Vector3 normalized_v_x_z = v_x_z.normalized;
        // ループシュート狙いかどうか
        if (v_y <= 12.0f) {
            temp = new Vector3(
                normalized_v_x_z.x * (16 + power/2) * 0.35f,
                Pointer.ball_height/20.0f * (16 + power/2) * 0.34f,
                normalized_v_x_z.z * (16 + power/2) * 0.39f
            );
        } else {
            temp = new Vector3(
                normalized_v_x_z.x * (16 + power/2) * 0.33f,
                Pointer.ball_height/20.0f * (16 + power/2) * 0.35f,
                normalized_v_x_z.z * (16 + power/2) * 0.20f
            );
        }
        this.GetComponent<Rigidbody>().velocity = temp;
        audioSource.clip = shout_sound;
        audioSource.Play();
    }

    float _calculate_ac_coefficient(Vector3 flick_start_position) {
        float judge_distance = 0.5f;
        Vector3 jundge_position = GameController.ball_start_position;
        //発射位置がボールがそれほど離れていないかったらカーブをかけない
        if (ball_type == 0) {
            return 0;
        } else if (ball_type == 1) {
            return -1;
        } else if (ball_type == 2) {
            return 1;
        }
        return 0;
    }

    void FixedUpdate() {
        if (GameController.game_status == 1) {
            float temp = (float)this.GetComponent<Rigidbody>().velocity.x + ac_x;
            this.GetComponent<Rigidbody>().velocity = new Vector3(temp, this.GetComponent<Rigidbody>().velocity.y, this.GetComponent<Rigidbody>().velocity.z);
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
