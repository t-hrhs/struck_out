using UnityEngine;
using System.Collections;

public class PopupManager : MonoBehaviour {
    public static bool select_done;
    void Start() {
        select_done = true;
    }
    void OnSelectionChange (string val)
    {
        switch(val) {
            case "Direct":
                Ball.ball_type = 0;
                break;
        case "Left Curve":
            Ball.ball_type = 1;
            Debug.Log ("test");
                break;
        case "Right Curve":
            Ball.ball_type = 2;
            Debug.Log ("test");
            break;
        }
    }
    void OnMainButtonClicked () {
        return;
    }
}


