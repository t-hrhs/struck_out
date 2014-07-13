using UnityEngine;
using System;
using System.Collections;

public class PanelManager {
    //panelファイルは動的に変わらないのでstatic宣言
    private static String[] panel_files = {"Prefab/PanelPrefab"};
    //panelのGameObjectメソッドもclass methodで作成
    public static GameObject make_panel_object(int stage_id, int index) {
        float x = Config.panel_config[stage_id][index]["x"];
        float y = Config.panel_config[stage_id][index]["y"];
        float z = Config.panel_config[stage_id][index]["z"];
        GameObject panel = GameObject.Instantiate(
                Resources.Load(panel_files[0]),
                new Vector3(x,y,z),
                Quaternion.identity
        ) as GameObject;
        return panel;
    }
}
