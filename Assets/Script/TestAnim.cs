using UnityEngine;
using System.Collections;

public class TestAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Animator motion = GetComponent<Animator>();
        AnimatorStateInfo state= motion.GetCurrentAnimatorStateInfo(0);

        if(Input.GetKeyDown("space")){
            motion.SetBool("Jump", true);
        }

        if(state.IsName("kick_22")){
            motion.SetBool("Jump", false);
        }
	}
}
