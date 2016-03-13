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
    //0. user high score num
    public static int user_high_score_num = 5;

    //1. 端末情報
    public static int s_width = Screen.width;
    public static int s_height = Screen.height;
    public static int modal_button_num = 2;
    //2. ステージ進捗情報
    //NOTE : ステージ名-1にしている(indexは0からはじまるため)
    public static int stage_id = 0;

    //3. ranking閲覧用
    public static int ranking_stage_id = 0;

    //TODO : あとで消す
    public static int total_stage_num = 12;
    public static int panel_width_num = 4;
    public static int[] panel_height_num = {3,3,3,3,3,3,3,3,3,3,3,3};
    //3. ステージ情報
    //3-1. パネルの情報
    public static Dictionary<string, float>[][] panel_config = new Dictionary<string, float>[][]{
        //ステージ1
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.73f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.18f},{"z",19.4f}},
        },
        //ステージ2
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.73f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.18f},{"z",19.4f}},
        },
        //ステージ3
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.73f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.18f},{"z",19.4f}},
        },
        //ステージ4
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.73f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.18f},{"z",19.4f}},
        },
        //ステージ5
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.73f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.18f},{"z",19.4f}},
        },
        //ステージ6
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.73f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.18f},{"z",19.4f}},
        },
        //ステージ7
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.73f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.18f},{"z",19.4f}},
        },
        //ステージ8
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.73f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.18f},{"z",19.4f}},
        },
        //ステージ9
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.73f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.18f},{"z",19.4f}},
        },
        //ステージ10
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.73f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.18f},{"z",19.4f}},
        },
        //ステージ11
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.73f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.18f},{"z",19.4f}},
        },
        //ステージ12
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.27f},{"y",0.73f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",3.63f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-6.15f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",-1.65f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",2.85f},{"y",2.18f},{"z",19.4f}},
            new Dictionary<string, float>() {{"x",7.35f},{"y",2.18f},{"z",19.4f}},
        },
    };
    //3-2. ボール数の情報
    public static int[] ball_num = {15,15,15,15,15,15,15,15,15,15,15,15};
    //3-3. 障害物の情報
    public static Dictionary<string, float>[][] obstacle_config = new Dictionary<string, float>[][]{
        //ステージ1(障害物0個)
        new Dictionary<string, float>[] {},
        //ステージ2
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",-2.297467f},{"y",2.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.15f},{"scale_y",0.18f},{"scale_z",0.30f},{"type",1}},
            new Dictionary<string, float>() {{"x",2.714816f},{"y",2.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.15f},{"scale_y",0.18f},{"scale_z",0.30f},{"type",1}},
        },
        //ステージ3
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",-2.297467f},{"y",2.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.15f},{"scale_y",0.18f},{"scale_z",0.30f},{"type",1}},
            new Dictionary<string, float>() {{"x",0.297467f},{"y",2.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.15f},{"scale_y",0.18f},{"scale_z",0.30f},{"type",1}},
            new Dictionary<string, float>() {{"x",2.714816f},{"y",2.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.15f},{"scale_y",0.18f},{"scale_z",0.30f},{"type",1}},
        },
        //ステージ4
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.297467f},{"y",2.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.15f},{"scale_y",0.18f},{"scale_z",0.30f},{"type",2}},
        },
        //ステージ5
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.297467f},{"y",2.407805f},{"z",-2.9656441f},{"obs_id",2.0f},{"scale_x",0.15f},{"scale_y",0.18f},{"scale_z",0.30f},{"type",1}},
            new Dictionary<string, float>() {{"x",-2.297467f},{"y",2.407805f},{"z",-2.9656441f},{"obs_id",2.0f},{"scale_x",0.15f},{"scale_y",0.18f},{"scale_z",0.30f},{"type",2}},
            new Dictionary<string, float>() {{"x",-1.297467f},{"y",2.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.15f},{"scale_y",0.18f},{"scale_z",0.30f},{"type",2}},
            new Dictionary<string, float>() {{"x",-3.714816f},{"y",2.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.15f},{"scale_y",0.18f},{"scale_z",0.30f},{"type",2}},
        },
        //ステージ6
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.297467f},{"y",3.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",1}},
        },
        //ステージ7
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.297467f},{"y",2.407805f},{"z",-2.9656441f},{"obs_id",2.0f},{"scale_x",0.15f},{"scale_y",0.18f},{"scale_z",0.30f},{"type",1}},
            new Dictionary<string, float>() {{"x",0.297467f},{"y",3.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",6}},
        },
        //ステージ8
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.297467f},{"y",2.407805f},{"z",-2.9656441f},{"obs_id",2.0f},{"scale_x",0.15f},{"scale_y",0.18f},{"scale_z",0.30f},{"type",1}},
            new Dictionary<string, float>() {{"x",0.297467f},{"y",3.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",6}},
            new Dictionary<string, float>() {{"x",0.297467f},{"y",3.407805f},{"z",-1.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",5}},
        },
        //ステージ9
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.297467f},{"y",2.407805f},{"z",-2.9656441f},{"obs_id",2.0f},{"scale_x",0.15f},{"scale_y",0.18f},{"scale_z",0.30f},{"type",1}},
            new Dictionary<string, float>() {{"x",0.297267f},{"y",3.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",6}},
            new Dictionary<string, float>() {{"x",-2.297467f},{"y",3.407805f},{"z",-1.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",1}},
        },
        //ステージ10
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.297467f},{"y",2.407805f},{"z",-2.9656441f},{"obs_id",2.0f},{"scale_x",0.15f},{"scale_y",0.18f},{"scale_z",0.30f},{"type",1}},
            new Dictionary<string, float>() {{"x",2.714816f},{"y",3.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",4}},
            new Dictionary<string, float>() {{"x",-2.297467f},{"y",3.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",3}},
        },
        //ステージ11
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",-4.7f},{"y",3.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",1}},
            new Dictionary<string, float>() {{"x",-2.297467f},{"y",3.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",1}},
            new Dictionary<string, float>() {{"x",2.714816f},{"y",3.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",1}},
            new Dictionary<string, float>() {{"x",5.2f},{"y",3.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",1}},
        },
        //ステージ12
        new Dictionary<string, float>[] {
            new Dictionary<string, float>() {{"x",0.297467f},{"y",2.407805f},{"z",-2.9656441f},{"obs_id",2.0f},{"scale_x",0.15f},{"scale_y",0.18f},{"scale_z",0.30f},{"type",1}},
            new Dictionary<string, float>() {{"x",-4.7f},{"y",3.407805f},{"z",-1.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",1}},
            new Dictionary<string, float>() {{"x",5.2f},{"y",3.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",4}},
            new Dictionary<string, float>() {{"x",-4.7f},{"y",3.407805f},{"z",-0.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",3}},
            new Dictionary<string, float>() {{"x",5.2f},{"y",3.407805f},{"z",-1.9656441f},{"obs_id",2.0f},{"scale_x",0.30f},{"scale_y",0.36f},{"scale_z",0.60f},{"type",1}},
        },
    };

}
