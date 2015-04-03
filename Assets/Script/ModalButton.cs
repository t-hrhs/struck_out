using UnityEngine;
using System.Collections;

public class ModalButton : MonoBehaviour {
    private int button_type = 0;
    /*-----------------
    button type
     0: undef
     1: back_to_top(give_up)
     2: close
     ---------------*/
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void set_button_type(int button_type) {
        this.button_type = button_type;
    }
    public void activate_event_by_button_type() {
        switch (this.button_type) {
            case 1:
                  Application.LoadLevel("TopPage");
                  break;
            case 2:
                  Debug.Log("Button2 touched");
                  break;
            default:
                  Debug.Log("Unrecognized button touched");
                  break;
        }
        GameObject modal_obj = GameObject.Find("Modal");
        Modal modal = modal_obj.GetComponent<Modal>();
        modal.close_window();
    }
}
