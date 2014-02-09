using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour {
    public static double judge_point_z = 13.5f;
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
            if (!this.clear_flag) {
                GameController.total_score += point;
            }
            this.clear_flag = true;
            //colliderの判定をoffにする
            //this.collider.enabled = false;
        }
	}
}
