using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void shoot(Vector3 start_pos, Vector3 end_pos, double time) {
        this.rigidbody.velocity= (end_pos - start_pos).normalized * 25;
    }
}
