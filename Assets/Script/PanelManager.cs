using UnityEngine;
using System;
using System.Collections;

public class PanelManager {
    //panelファイルは動的に変わらないのでstatic宣言
    private static String[] panel_files = {"Prefab/PanelPrefab","Prefab/C_PanelPrefab"};
    //panelのGameObjectメソッドもclass methodで作成
    public static GameObject make_panel_object(int stage_id, int index) {
        float x = Config.panel_config[stage_id][index]["x"];
        float y = Config.panel_config[stage_id][index]["y"];
        float z = Config.panel_config[stage_id][index]["z"];
        int panel_index = 0;
        if (Config.panel_config [stage_id] [index].ContainsKey ("p_id")) {
            panel_index = (int)Config.panel_config [stage_id] [index] ["p_id"];
        }
        GameObject panel = GameObject.Instantiate(
            Resources.Load(panel_files[panel_index]),
                new Vector3(x,y,z),
                Quaternion.identity
        ) as GameObject;
        return panel;
    }
}
