/**
  * @file GetWayPoints.cs
  * @brief 从RoadArchitect插件创建的路中提取路标点
  * @details  
  * 在Unity编辑界面点击运行，选择对应的road
  * 在其inspector界面点击Update road，再调用下列函数：
  * SaveJson()将数据存为json文件
  * SaveXml()将数据存为xml文件，同时做了些处理，比如每两个实际的路标点才保存一个
  * 这两个函数不会自动调用，需要将函数放在按钮上或者设置按下某按键后执行
  * 储存在Assets/StreamingAssets
  * @author 李雨航
  * @date 2023.3.26
  */


using GSD.Roads;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using UnityEngine;

public class GetWayPoints : MonoBehaviour
{
    public GameObject Spline;
    trackData WayPoints;
    string flie_name = "waypoints_race04";
    string path; //文件的路径
    // Start is called before the first frame update
    void Start()
    {
        //GSDRoad road = this.GetComponent<GSDRoad>();
        WayPoints = new trackData();
        //Path = Application.streamingAssetsPath + "/waypoints_race04.json";
    }

    public void SaveJson()
    {
        WayPoints = Spline.GetComponent<GSDSplineC>().WayPoints;
        path = Application.streamingAssetsPath + "/" + flie_name + ".json";
        if (!File.Exists(path))
        {
            File.Create(path);
        }
        string json = JsonUtility.ToJson(WayPoints, true);
        StartCoroutine(save_json_helper(json));
        
    }

    public void SaveXml()
    {
        //根据
        Vector3 pos;
        Vector3 rot_euler;
        Quaternion rot;
        string scale = "(1.00,1,00,1,00)";

        WayPoints = Spline.GetComponent<GSDSplineC>().WayPoints;
        path = Application.streamingAssetsPath + "/" + flie_name + ".xml";
        //创建xml文档
        XmlDocument xml = new XmlDocument();
        //创建根节点
        XmlElement root = xml.CreateElement("waypoints");
        int index = 0;
        int count = WayPoints.way_points_pos.Count;
        for(int i = 0; i < count; i = i+2)
        {
            //创建根节点的子节点
            XmlElement waypoint_node = xml.CreateElement("waypoint");
            //设置根节点的子节点的属性
            waypoint_node.SetAttribute("index", index.ToString());
            index += 1;

            //添加两个子节点到根节点的子节点的下面
            XmlElement positon_node = xml.CreateElement("position");
            pos.x = Mathf.Round(WayPoints.way_points_pos[i].x * 100f) / 100f;
            pos.y = Mathf.Round(WayPoints.way_points_pos[i].y * 100f) / 100f;
            pos.z = Mathf.Round(WayPoints.way_points_pos[i].z * 100f) / 100f;
            positon_node.InnerText = pos.ToString();

            XmlElement rotation_node = xml.CreateElement("rotation");
            rot_euler.x = WayPoints.way_points_rot[i].x;
            rot_euler.y = WayPoints.way_points_rot[i].y;
            rot_euler.z = WayPoints.way_points_rot[i].z;
            rot = Quaternion.Euler(rot_euler);
            rot.w = Mathf.Round(rot.w * 100000f) / 100000f;
            rot.x = Mathf.Round(rot.x * 100000f) / 100000f;
            rot.y = Mathf.Round(rot.y * 100000f) / 100000f;
            rot.z = Mathf.Round(rot.z * 100000f) / 100000f;
            rotation_node.InnerText = rot.ToString();

            XmlElement scale_node = xml.CreateElement("scale");
            scale_node.InnerText = scale;

            //把节点一层一层的添加至xml中，注意他们之间的先后顺序，这是生成XML文件的顺序
            waypoint_node.AppendChild(positon_node);
            waypoint_node.AppendChild(rotation_node);
            waypoint_node.AppendChild(scale_node);

            root.AppendChild(waypoint_node);
        }
        xml.AppendChild(root);
        xml.Save(path);
        Debug.Log("保存成功");
    }

    IEnumerator save_json_helper(string json)
    {
        yield return new WaitForSeconds(0.5f);
        
        File.WriteAllText(path, json);
        Debug.Log("保存成功");
    }
}