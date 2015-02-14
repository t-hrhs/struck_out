using UnityEngine;
using System.Collections;

/* 障害物のインスタンス
 * move_type
 * 1 : 特に何もしない
 * 2 : 上下にジャンプ
 * 3 : 中央<->左
 * 4 : 中央<->右
 * 5 : 左->右
 * 6 : 右->左
 * 7 : 拡大縮小
 */

public class Obstacle : MonoBehaviour {
    int left_edge_position = -6;
    int right_edge_position = 6;
    public int move_type = 1;
    public int operate = 1;
    public Vector3 base_local_scale = new Vector3(1.0f,1.0f,1.0f);
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
            case 5:
                  move_left_to_right ();
                  break;
            case 6:
                  move_right_to_left();
                  break;
            case 7:
                  large_and_small();
                  break;
            default:
                  break;
        }
	}
    void move_up_down() {
        if (this.transform.position.y < this.transform.localScale.y/2) {
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
    void move_left_to_right() {
        Vector3 current_position = this.transform.position;
        float temp_x = current_position.x;
        Debug.Log(temp_x);
        if (temp_x < right_edge_position) {
            temp_x += 0.05f;
            this.transform.position = new Vector3(
                temp_x,
                current_position.y,
                current_position.z
            );
        } else {
            temp_x = left_edge_position;
            this.transform.position = new Vector3(
                temp_x,
                current_position.y,
                current_position.z
            );
        }
    }
    void move_right_to_left() {
        Vector3 current_position = this.transform.position;
        float temp_x = current_position.x;
        Debug.Log(temp_x);
        if (temp_x > left_edge_position) {
            temp_x -= 0.05f;
            this.transform.position = new Vector3(
                temp_x,
                current_position.y,
                current_position.z
            );
        } else {
            temp_x = right_edge_position;
            this.transform.position = new Vector3(
                temp_x,
                current_position.y,
                current_position.z
            );
        }
    }
    void large_and_small() {
        int max_scale = 2;
        int min_scale = 1;
        Vector3 current_position = this.transform.position;
        Vector3 current_local_scale = this.transform.localScale;
        float rate = current_local_scale.x / base_local_scale.x;
        if (operate == 1 && rate >= max_scale) {
            operate = 2;
            rate -= 0.01f;
        } else if (operate == 2 && rate <= 1) {
            operate = 1;
            rate += 0.01f;
        } else if (operate == 1) {
            rate += 0.01f;
        } else if (operate == 2) {
            rate -= 0.01f;
        }
        this.transform.localScale = new Vector3(
            base_local_scale.x * rate,
            base_local_scale.y * rate,
            base_local_scale.z * rate
        );
        if (base_local_scale.y * rate /2 >= current_position.y) {
            this.transform.position = new Vector3(
                current_position.x,
                base_local_scale.y * rate /2,
                current_position.z
            );
        }
    }
}
