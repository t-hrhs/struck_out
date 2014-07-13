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
    public static int[] panel_height_num = {3,3,3,3,3};

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
    };
    //3-2. ボール数の情報
    public static int[] ball_num = {15,15,15};
}
