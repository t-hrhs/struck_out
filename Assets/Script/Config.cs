using UnityEngine;
using System.Collections;

public static class Config {
    //複数ステージ作る場合の考慮
    //stage_number-1 because of array index
    public static int stage_id = 0;
    public static int panel_width_num = 4;
    public static int[] panel_height_num = {3,3,3,3,3};
    //panel_status
    //0 : normal
    //1以上 : 特殊パネル
    public static int[,,] panel_status = {
        {
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0}
        },
        {
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0}
        },
    };
}
