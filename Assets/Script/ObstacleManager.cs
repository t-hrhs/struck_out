using UnityEngine;
using System;
using System.Collections;

public class ObstacleManager {
    //panelファイルは動的に変わらないのでstatic宣言
    private static String[] panel_files = {"Prefab/Obstacle_v5"};
    //panelのGameObjectメソッドもclass methodで作成
    public static GameObject make_obstacle_object(int stage_id, int index) {
        float x = Config.obstacle_config[stage_id][index]["x"];
        float y = Config.obstacle_config[stage_id][index]["y"];
        float z = Config.obstacle_config[stage_id][index]["z"];
        GameObject obstacle = GameObject.Instantiate(
            Resources.Load(panel_files[0]),
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
        Obstacle obstacle_obj = obstacle.GetComponent<Obstacle> ();
        obstacle_obj.move_type = (int)Config.obstacle_config [stage_id] [index] ["type"];
        return obstacle;
    }
}