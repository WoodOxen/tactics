/// CarWaypoints v1.0 (赛车路标点插件) <summary>
/// 作者：阿升哥哥
/// 博客：http://www.cnblogs.com/shenggege
/// 联系方式：6087537@qq.com
/// 最后修改：2015/2/17 21:13
/// </summary>

using UnityEngine;
using UnityEditor;
using System.IO;
using System.Xml;

/// 这个脚本添加插件菜单到u3d编辑器中 <summary>
/// 这个脚本添加插件菜单到u3d编辑器中
/// </summary>
public class WaypointMenu
{
    /// 创建路标点数据文件 <summary>
    /// 创建路标点数据文件
    /// </summary>
    [MenuItem("Assets/Create/Waypoints Data")]
    public static void CreateWaypointsData()
    {
        string dataName = "New Waypoints Data";

        //获取选择的所有物体
        Object[] objects = Selection.objects;

        foreach (Object obj3 in objects)
        {
            //获取路径
            string path = AssetDatabase.GenerateUniqueAssetPath(Path.Combine(Path.GetDirectoryName(AssetDatabase.GetAssetPath(obj3) + "/" + obj3.name), dataName) + ".xml");

            //当路径为空时说明路径包含了文件
            if (path == "")
                path = AssetDatabase.GenerateUniqueAssetPath(Path.Combine(Path.GetDirectoryName(AssetDatabase.GetAssetPath(obj3)), dataName) + ".xml");

            //实例化并保存XML
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("waypoints");
            xmlDoc.AppendChild(root);
            xmlDoc.Save(path);

            //刷新面板
            AssetDatabase.Refresh();
        }
    }

    /// 创建路标点 <summary>
    /// 创建路标点
    /// </summary>
    [MenuItem("CarWaypoints/Create Waypoints &C", false, 10)]
    static void CreateWaypoints()
    {
        if (WaypointMessage.myTransform != null)
        {
            Debug.Log("创建失败：路标点已存在，请勿重复创建");
        }
        else
        {
            GameObject go = new GameObject();
            go.name = "Waypoints";

            go.AddComponent<WaypointMessage>();
            WaypointMessage.myTransform = go.transform;
            Debug.Log("创建成功：路标点创建完成");
        }

        Selection.activeTransform = WaypointMessage.myTransform;
    }

    /// 保存路标点 <summary>
    /// 保存路标点
    /// </summary>
    [MenuItem("CarWaypoints/Save Waypoints &S", false, 11)]
    static void SaveWaypoints()
    {
        if (WaypointMessage.myTransform == null)
        {
            Debug.Log("保存失败：尚未创建路标点");
        }
        else
        {
            WaypointMessage WM = WaypointMessage.myTransform.GetComponent<WaypointMessage>();

            if (WM.curWaypointsXMLPath == "" || WM.curWaypointsXMLText == null)
            {
                Debug.Log("保存失败：尚未指定路标点数据文件");
            }
            else
            {
                WM.SaveWaypointsToXml(WM, WM.curWaypointsXMLPath);
            }
        }
    }

    /// 添加路标点 <summary>
    /// 添加路标点
    /// </summary>
    [MenuItem("CarWaypoints/Add Waypoint &A", false, 11)]
    static void AddWaypoint()
    {
        if (WaypointMessage.myTransform == null)
        {
            Debug.Log("添加失败：尚未创建路标点");
        }
        else
        {
            WaypointMessage WM = WaypointMessage.myTransform.GetComponent<WaypointMessage>();

            if (WM.curWaypointsXMLPath == "" || WM.curWaypointsXMLText == null)
            {
                Debug.Log("添加失败：尚未指定路标点数据文件");
            }
            else
            {
                WM.AddWaypoint(WM);
            }
        }
    }

    /// 帮助/联系作者 <summary>
    /// 帮助/联系作者
    /// </summary>
    [MenuItem("CarWaypoints/Help &H", false, 999)]
    static void Help()
    {
        WaypointMessage.Help();
    }
}
