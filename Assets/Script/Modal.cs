using UnityEngine;
using System;
using System.Collections;

public class Modal : MonoBehaviour {
    private GameObject sub_cam;
    private GameObject[] modal_buttons;
    // Use this for initialization
    void Start () {
        this.GetComponent<Collider>().enabled = false;
        this.GetComponent<Renderer>().enabled = false;
        int modal_button_num = Config.modal_button_num;
        modal_buttons = new GameObject[modal_button_num];
        String base_button_name = "ModalButton";
        for(int i = 1; i<=modal_button_num; i++) {
            String button_name = base_button_name + i;
            GameObject tmp = GameObject.Find(button_name);
            ModalButton modal_button = tmp.GetComponent<ModalButton>();
            modal_button.set_button_type(i);
            modal_buttons[i-1] = tmp;
            tmp.SetActive(false);
        }
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
        for(int i=0; i<Config.modal_button_num; i++) {
            this.modal_buttons[i].SetActive(true);
        }
    }
    public void close_window() {
        this.GetComponent<Collider>().enabled = false;
        this.GetComponent<Renderer>().enabled = false;
        if (sub_cam != null) {
            sub_cam.SetActive(true);
        }
        for(int i=0; i<Config.modal_button_num; i++) {
            this.modal_buttons[i].SetActive(false);
        }
    }
}
