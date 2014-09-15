using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/*----------------------------------------
Configクラス
 1. 各端末の情報を保持
 2. ステージの進捗を保持
 3. 各ステージ構成をテキストで保持
----------------------------------------- */
public static class Config {
    //1. 端末情報
    public static int s_width = Screen.width;
    public static int s_height = Screen.height;

    //2. ステージ進捗情報
    //NOTE : ステージ名-1にしている(indexは0からはじまるため)
    public static int stage_id = 0;

    //TODO : あとで消す
    public static int panel_width_num = 4;
    public static int[] panel_height_num = {3,3,3,3,3,3,3};

    //3. ステージ情報
    //3-1. パネルの情報
    public static Dictionary<string, float>[][] panel_config = new Dictionary<string, float>[][]{
        //ステージ1
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.93f},{"z",11.0f}},
        },
        //ステージ2
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.93f},{"z",11.0f}},
        },
        //ステージ3
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.93f},{"z",11.0f}},
        },
        //ステージ4
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.93f},{"z",11.0f}},
        },
        //ステージ5
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.93f},{"z",11.0f}},
        },
        //ステージ6
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.93f},{"z",11.0f},{"p_id",1.0f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",4.93f},{"z",11.0f},{"p_id",1.0f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",4.93f},{"z",11.0f},{"p_id",1.0f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",4.93f},{"z",11.0f},{"p_id",1.0f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",4.93f},{"z",11.0f},{"p_id",1.0f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.93f},{"z",11.0f},{"p_id",1.0f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.93f},{"z",11.0f},{"p_id",1.0f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.93f},{"z",11.0f},{"p_id",1.0f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.93f},{"z",11.0f},{"p_id",1.0f}},
        },
        //ステージ7
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",4.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.93f},{"z",11.0f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.93f},{"z",11.0f}},
        },
    };
    //3-2. ボール数の情報
    public static int[] ball_num = {15,15,15,15,15,15,15};
    //3-3. 障害物の情報
    public static Dictionary<string, float>[][] obstacle_config = new Dictionary<string, float>[][]{
        //ステージ1(障害物0個)
        new Dictionary<string, float>[] {},
        //ステージ2
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",-2.297467f},{"y",2.407805f},{"z",-0.9656441f},{"obs_id",1.0f},{"type",1}},
            new Dictionary<string, float>() {{"x",2.714816f},{"y",2.407805f},{"z",-0.9656441f},{"obs_id",1.0f},{"type",1}},
        },
        //ステージ3
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",2.714815f},{"y",2.838175f},{"z",-4.009133f},{"obs_id",1.0f},{"type",1}},
            new Dictionary<string, float>() {{"x",-2.297467f},{"y",2.838175f},{"z",-4.009132f},{"obs_id",1.0f},{"type",1}},
            new Dictionary<string, float>() {{"x",-2.297467f},{"y",2.838175f},{"z",-0.9656441f},{"obs_id",1.0f},{"type",3}},
            new Dictionary<string, float>() {{"x",2.714816f},{"y",2.838175f},{"z",-0.9656457f},{"obs_id",1.0f},{"type",4}},
        },
        //ステージ4
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",2.714815f},{"y",2.838175f},{"z",-4.009133f},{"obs_id",1.0f},{"scale_x",0.85f},{"scale_y",0.85f},{"scale_z",0.50f},{"type",2}},
            new Dictionary<string, float>() {{"x",-2.297467f},{"y",2.838175f},{"z",-4.009132f},{"obs_id",1.0f},{"scale_x",0.85f},{"scale_y",0.85f},{"scale_z",0.50f},{"type",2}},
            new Dictionary<string, float>() {{"x",-2.297467f},{"y",2.838175f},{"z",-0.9656441f},{"obs_id",1.0f},{"scale_x",0.85f},{"scale_y",0.85f},{"scale_z",0.50f},{"type",3}},
            new Dictionary<string, float>() {{"x",2.714816f},{"y",2.838175f},{"z",-0.9656457f},{"obs_id",1.0f},{"scale_x",0.85f},{"scale_y",0.85f},{"scale_z",0.50f},{"type",4}},
        },
        //ステージ5
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",5.512368f},{"y",2.838175f},{"z",-4.009134f},{"obs_id",1.0f},{"scale_x",0.85f},{"scale_y",0.85f},{"scale_z",0.50f},{"type",2}},
            new Dictionary<string, float>() {{"x",0.2544718f},{"y",6.566844f},{"z",-4.391799f},{"obs_id",1.0f},{"scale_x",2.0f},{"scale_y",2.0f},{"scale_z",0.50f},{"type",2}},
            new Dictionary<string, float>() {{"x",-4.407021f},{"y",2.838175f},{"z",-4.009131f},{"obs_id",1.0f},{"scale_x",0.85f},{"scale_y",0.85f},{"scale_z",0.50f},{"type",2}},
            new Dictionary<string, float>() {{"x",-2.297467f},{"y",2.838175f},{"z",-0.9656441f},{"obs_id",1.0f},{"scale_x",0.85f},{"scale_y",0.85f},{"scale_z",0.50f},{"type",3}},
            new Dictionary<string, float>() {{"x",2.714816f},{"y",2.838175f},{"z",-0.9656457f},{"obs_id",1.0f},{"scale_x",0.85f},{"scale_y",0.85f},{"scale_z",0.50f},{"type",4}},
        },
        //ステージ6
        new Dictionary<string, float>[] {},
        //ステージ7
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.2865039f},{"y",0.98f},{"z",-0.3636186f},{"obs_id",2.0f},{"scale_x",4.00f},{"scale_y",4.00f},{"scale_z",1.50f},{"type",1}},
            new Dictionary<string, float>() {{"x",0.2865039f},{"y",0.98f},{"z",-2.36186f},{"obs_id",2.0f},{"scale_x",2.00f},{"scale_y",2.00f},{"scale_z",0.50f},{"type",3}},
            new Dictionary<string, float>() {{"x",0.2865039f},{"y",0.98f},{"z",-5.936186f},{"obs_id",2.0f},{"scale_x",2.00f},{"scale_y",2.00f},{"scale_z",0.50f},{"type",4}},
        },
    };

}
