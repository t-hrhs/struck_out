using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour {
    public static double judge_point_z = 11.3f;
    public bool clear_flag = false;
    public int point = 1000;
    public Texture2D[] textures = new Texture2D[9];
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        //ありえない方向にパネルが動き出したらその場停止
        if (this.GetComponent<Rigidbody>().velocity.z < 0) {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        } else {
            if (this.transform.position.z > (float)judge_point_z) {
                //constraintの初期化
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                //this.active = false;
                if (!this.clear_flag) {
                    //NOTE : ここでは足さず、連続ボーナス等をまとめて
                    //GameController.total_score += point;
                    GameController.panel_remaining_num--;
                }
                this.clear_flag = true;
                this.GetComponent<Renderer>().enabled = false;
                //colliderの判定をoffにする
                this.GetComponent<Collider>().enabled = false;
            }
        }
	}

    public void make_target(int temp) {
        this.point = 1000 * temp;
        this.GetComponent<Renderer>().material.color = Color.red;
    }

    public void setDefault() {
        this.GetComponent<Renderer>().material.color = Color.white;
        this.point = 1000;
    }
    public void set_texture(int index) {
        this.transform.Rotate(0, 180, 0);
        this.GetComponent<Renderer>().material.mainTexture=textures[index];
    }
}
