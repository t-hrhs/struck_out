using UnityEngine;
using System;
using System.Collections;

public class Logo : MonoBehaviour {
    public Texture2D[] textures = new Texture2D[74];
    int index = 0;
	// Use this for initialization
	void Start () {
	    index = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (GameController.animation) {
            this.GetComponent<Renderer>().material.mainTexture = textures[index];
            index++;
            if (index > 73) {
                index = 0;
            }
        } else {
            index = 0;
            this.GetComponent<Renderer>().material.mainTexture = textures[index];
        }
	}
}
