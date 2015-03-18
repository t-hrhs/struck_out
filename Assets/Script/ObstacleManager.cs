using UnityEngine;
using System;
using System.Collections;

public class ObstacleManager {
    //panelファイルは動的に変わらないのでstatic宣言
    private static String[] panel_files = {"Prefab/Obstacle_v5","Prefab/Obstacle_v2"};
    //panelのGameObjectメソッドもclass methodで作成
    public static GameObject make_obstacle_object(int stage_id, int index) {
        float x = Config.obstacle_config[stage_id][index]["x"];
        float y = Config.obstacle_config[stage_id][index]["y"];
        float z = Config.obstacle_config[stage_id][index]["z"];
        int panel_index = 0;
        if (Config.obstacle_config [stage_id] [index].ContainsKey ("obs_id")) {
            panel_index = (int)Config.obstacle_config [stage_id] [index] ["obs_id"];
            panel_index = panel_index - 1;
        }
        GameObject obstacle = GameObject.Instantiate(
            Resources.Load(panel_files[panel_index]),
            new Vector3(x,y,z),
            Quaternion.identity
        ) as GameObject;
        obstacle.transform.localScale = new Vector3 (0.7f, 0.7f, 0.5f);
        if (Config.obstacle_config[stage_id][index].ContainsKey("scale_x")) {
            obstacle.transform.localScale = new Vector3 (
                Config.obstacle_config[stage_id][index]["scale_x"],
                Config.obstacle_config[stage_id][index]["scale_y"],
                Config.obstacle_config[stage_id][index]["scale_z"]
            );
        }
        obstacle.transform.eulerAngles = new Vector3(0.0f,180.0f,0.0f);
        Obstacle obstacle_obj = obstacle.GetComponent<Obstacle> ();
        obstacle_obj.move_type = (int)Config.obstacle_config [stage_id] [index] ["type"];
        if (Config.obstacle_config [stage_id] [index].ContainsKey ("scale_x")) {
            obstacle_obj.base_local_scale = new Vector3 (
                Config.obstacle_config [stage_id] [index] ["scale_x"],
                Config.obstacle_config [stage_id] [index] ["scale_y"],
                Config.obstacle_config [stage_id] [index] ["scale_z"]
            );
        }
        obstacle_obj.transform.rotation = Quaternion.Euler( 90,180,0 );
        return obstacle;
    }
}
