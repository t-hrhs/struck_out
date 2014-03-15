using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (Config.stage_id==2) {
            if (this.transform.position.y < 1.681f) {
                this.rigidbody.velocity = new Vector3(0.0f,10.0f,0.0f);
            }
        }
	    if (Config.stage_id==3) {
            if (this.transform.position.y < 1.681f) {
                this.rigidbody.velocity = new Vector3(0.0f,Random.Range(0.0f,10.0f),0.0f);
            }
        }
	}
}
