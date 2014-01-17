using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// start to touch
		if (Input.GetMouseButtonDown(0)) {
			Ray clkRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		}
		else if (Input.GetMouseButtonUp(0)) {

		}
	}
}
