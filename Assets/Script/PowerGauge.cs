using UnityEngine;
using System.Collections;

public class PowerGauge : MonoBehaviour {

// Use this for initialization
    void Start () {
        this.transform.position = new Vector3(-1.13f,2.15f,-15.4f);
    }

    // Update is called once per frame
    void Update () {
        float power = Ball.power;
        float rare = power/100;
        this.transform.localScale = new Vector3(
            this.transform.localScale.x,
            rare,
            this.transform.localScale.z
        );
        this.transform.position = new Vector3(
            this.transform.position.x,
            1.65f + this.transform.localScale.y,
            this.transform.position.z
        );
    }
}
