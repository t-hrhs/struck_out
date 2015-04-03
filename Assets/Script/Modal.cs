using UnityEngine;
using System.Collections;

public class Modal : MonoBehaviour {
    private GameObject sub_cam;
	// Use this for initialization
	void Start () {
	    this.GetComponent<Collider>().enabled = false;
	    this.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //open the modal window
    public void open_window() {
	    this.GetComponent<Collider>().enabled = true;
	    this.GetComponent<Renderer>().enabled = true;
        // disable SubCamera
        GameObject SubCam = GameObject.Find("SubCamera");
        if (SubCam != null) {
            sub_cam = SubCam;
            SubCam.SetActive(false);
        }
    }
    public void close_window() {
	    this.GetComponent<Collider>().enabled = false;
	    this.GetComponent<Renderer>().enabled = false;
        if (sub_cam != null) {
            sub_cam.SetActive(true);
        }
    }
}
