/// CarWaypoints v1.0 (赛车路标点插件) <summary>
/// 作者：阿升哥哥
/// 博客：http://www.cnblogs.com/shenggege
/// 联系方式：6087537@qq.com
/// 最后修改：2015/2/17 18:13
/// </summary>

using UnityEditor;
using UnityEngine;

/// 路标点编辑器 <summary>
/// 路标点编辑器
/// </summary>
[CustomEditor(typeof(WaypointMessage))]
public class WaypointsEditor : Editor
{
    private WaypointMessage WM = null;
    private bool showWaypoint = false;

    /*
    void OnSceneGUI()
    {
        //不在编辑器中则返回
        if (Application.platform != RuntimePlatform.WindowsEditor)
            return;

        WM = target as WaypointMessage;

        if (WM == null)
            return;

        Handles.BeginGUI();
        GUILayout.BeginArea(new Rect(10, 10, 200, 200));

        if (WM.curWaypointsXMLPath != null)
        {
            if (GUILayout.Button("Save Waypoints", GUILayout.Width(150), GUILayout.Height(30)))
                WM.SaveWaypointsToXml(WM, WM.curWaypointsXMLPath);

            if (GUILayout.Button("Add Waypoint", GUILayout.Width(150), GUILayout.Height(30)))
                WM.AddWaypoint(WM);
        }

        GUILayout.EndArea();
        Handles.EndGUI();
    }*/

    public override void OnInspectorGUI()
    {
        //不在编辑器中则返回
        if (Application.platform != RuntimePlatform.WindowsEditor)
            return;

        WM = target as WaypointMessage;

        if (WM == null)
            return;

        EditorGUILayout.Space();
        GUILayout.BeginHorizontal();

        //刷新路标点
        if (GUILayout.Button("Refresh", GUILayout.Height(20)))
            WM.RefreshWaypoints(WM);

        //获取XML文件数据
        WM.lastWaypointsXMLText = (TextAsset)EditorGUILayout.ObjectField(WM.curWaypointsXMLText, typeof(TextAsset), false);

        GUILayout.EndHorizontal();
        EditorGUILayout.Space();

        //上次数据与当前数据不同时则刷新数据
        if (WM.lastWaypointsXMLText != WM.curWaypointsXMLText)
        {
            WM.curWaypointsXMLText = WM.lastWaypointsXMLText;

            WM.RefreshWaypoints(WM);
        }

        //两点间最大距离
        WM.maxWaypointDis = EditorGUILayout.FloatField("Max Waypoint Dis", WM.maxWaypointDis);

        //线颜色
        WM.lineColor = EditorGUILayout.ColorField("Line Color", WM.lineColor);

        //线宽度
        WM.lineWidth = EditorGUILayout.FloatField("Line Width", WM.lineWidth);

        //显示隐藏路标点连接线
        WM.showWaypoint = EditorGUILayout.Toggle("Show Waypoint", WM.showWaypoint);

        //显示隐藏路标点方向线
        WM.showWaypointDir = EditorGUILayout.Toggle("Show Waypoint Dir", WM.showWaypointDir);

        //对齐地面
        WM.alignGround = EditorGUILayout.Toggle("Align Ground", WM.alignGround);

        //离地面距离
        WM.disGround = EditorGUILayout.FloatField("Dis Ground", WM.disGround);

        //是否绕圈
        WM.isAroundCircle = EditorGUILayout.Toggle("Is Around Circle", WM.isAroundCircle);

        /* 以下屏蔽代码暂时不用
        showWaypoint = EditorGUILayout.Foldout(showWaypoint, "Waypoints Model All -- " + WM.WaypointsModelAll.Count.ToString());
        if (showWaypoint)
        {
            EditorGUI.indentLevel = 2;
            for (int i = 0; i < WM.WaypointsModelAll.Count; i++)
            {
                WM.WaypointsModelAll[i].Show = EditorGUILayout.Foldout(WM.WaypointsModelAll[i].Show, "Waypoint " + waypoint.WaypointsModelAll[i].Index.ToString());
                if (WM.WaypointsModelAll[i].Show)
                {
                    EditorGUILayout.Vector3Field("Position", WM.WaypointsModelAll[i].Position);
                    EditorGUILayout.Vector3Field("Rotation", WM.WaypointsModelAll[i].Rotation.eulerAngles);
                    EditorGUILayout.Vector3Field("Scale", WM.WaypointsModelAll[i].Scale);
                    EditorGUILayout.Space();
                }
            }
        }*/

        EditorGUILayout.Space();
        GUILayout.BeginHorizontal("Box");

        EditorGUILayout.LabelField("Current Waypoints:" + WM.WaypointsModelAll.Count.ToString());

        if (GUILayout.Button("Help", GUILayout.Height(20)))
        {
            WaypointMessage.Help();
        }

        GUILayout.EndHorizontal();
        EditorGUILayout.Space();

        //设置已改变
        EditorUtility.SetDirty(WM);
    }
}