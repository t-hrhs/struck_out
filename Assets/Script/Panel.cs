using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour {
    public static int judge_point_z = 14;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (this.transform.position.z > judge_point_z) {
            //constraintの初期化
            this.rigidbody.constraints = RigidbodyConstraints.None;
            //colliderの判定をoffにする
            //this.collider.enabled = false;
        }
	}
}
