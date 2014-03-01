using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour {
    public static double judge_point_z = 12.0f;
    public bool clear_flag = false;
    public int point = 1000;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (this.transform.position.z > (float)judge_point_z) {
            //constraintの初期化
            this.rigidbody.constraints = RigidbodyConstraints.None;
            //this.active = false;
            if (!this.clear_flag) {
                GameController.total_score += point;
                GameController.panel_num--;
            }
            this.clear_flag = true;
            //colliderの判定をoffにする
            //this.collider.enabled = false;
        }
	}

    public void make_target(int temp) {
        this.point = 1000 * temp;
        this.renderer.material.color = Color.red;
    }

    public void setDefault() {
        this.renderer.material.color = Color.white;
        this.point = 1000;
    }
}
