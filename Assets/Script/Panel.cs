using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour {
    public static double judge_point_z = 13.5f;
    public bool clear_flag = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (this.transform.position.z > (float)judge_point_z) {
            //constraintの初期化
            this.rigidbody.constraints = RigidbodyConstraints.None;
            this.clear_flag = true;
            //colliderの判定をoffにする
            //this.collider.enabled = false;
        }
	}
}
