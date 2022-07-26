/// CarWaypoints v1.0 (赛车路标点插件) <summary>
/// 作者：阿升哥哥
/// 博客：http://www.cnblogs.com/shenggege
/// 联系方式：6087537@qq.com
/// 最后修改：2015/2/18 1:07
/// </summary>

using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

/// 路标点管理器 <summary>
/// 路标点管理器
/// </summary>
public class WaypointMessage : MonoBehaviour
{
    public static Transform myTransform = null;

    //所有路标点实体
    public List<WaypointsModel> WaypointsModelAll = new List<WaypointsModel>();

    public TextAsset curWaypointsXMLText = null;//当前路标点XML数据
    public TextAsset lastWaypointsXMLText = null;//上次路标点XML数据
    public string curWaypointsXMLPath = "";//当前路标点路径

    public float maxWaypointDis = 10f;//两点间最大距离

    public Color lineColor = Color.blue;//线颜色
    public float lineWidth = 4f;//线宽度

    public bool showWaypoint = true;//显示隐藏路标点连接线
    public bool showWaypointDir = true;//显示隐藏路标点方向线

    public bool alignGround = true; //对齐地面
    public float disGround = 0.5f;//离地面距离

    public bool isAroundCircle = false;//是否绕圈 

    /// 初始化 <summary>
    /// 初始化
    /// </summary>
    void Awake()
    {
        //RefreshWaypoints(transform.GetComponent<WaypointMessage>());
        //DestroyChild(transform);
    }

    void OnDrawGizmos()
    {
        //不在编辑器中则返回
        if (Application.platform != RuntimePlatform.WindowsEditor)
            return;

        myTransform = transform;

        #region 对齐地面&更新数据

        //当前选择的如果是Waypoint时
        if (Selection.activeTransform != null)
        {
            if (Selection.activeTransform.parent == transform)
            {
                int temIndex = int.Parse(Selection.activeTransform.name);
                for (int i = 0; i < WaypointsModelAll.Count; i++)
                {
                    if (temIndex == WaypointsModelAll[i].Index)
                    {
                        //当路标点被移动时更新数据
                        if (i != 0)
                        {
                            //限制两点间最大距离
                            if (Mathf.Abs(Vector3.Distance(WaypointsModelAll[i - 1].Position, Selection.activeTransform.position)) < maxWaypointDis)
                                WaypointsModelAll[i].Position = Selection.activeTransform.position;
                        }
                        else
                        {
                            //最后一个路标点和第一个路标点不计算最大距离
                            WaypointsModelAll[i].Position = Selection.activeTransform.position;
                        }

                        WaypointsModelAll[i].Rotation = Selection.activeTransform.rotation;
                        WaypointsModelAll[i].Scale = Selection.activeTransform.localScale;

                        /*
                        if (i != WaypointsModelAll.Count - 1)
                        {
                            Selection.activeTransform.LookAt(WaypointsModelAll[i + 1].Position);
                        }
                        else if (isAroundCircle)
                        {
                            //如果绕圈则注视起点
                            Selection.activeTransform.LookAt(WaypointsModelAll[0].Position);
                        }*/


                        //对齐地面
                        if (alignGround)
                        {
                            RaycastHit[] hit;
                            hit = Physics.RaycastAll(WaypointsModelAll[i].Position, WaypointsModelAll[i].Rotation * -Vector3.up, 100f);//起始位置、方向、距离

                            #region 获取碰撞到的所有物体

                            for (int i1 = 0; i1 < hit.Length; i1++)
                            {
                                //当碰撞到的物体为地面时
                                if (hit[i1].transform.tag == "Map_ground")
                                {
                                    //计算当前路标点与地面之间的距离
                                    float temDis = Vector3.Distance(WaypointsModelAll[i].Position, hit[i1].point);

                                    //调整距离
                                    Selection.activeTransform.position = new Vector3(
                                            WaypointsModelAll[i].Position.x,
                                            WaypointsModelAll[i].Position.y - (temDis - disGround),
                                            WaypointsModelAll[i].Position.z);

                                    //Debug.Log(temDis);

                                    //绘制高度线
                                    Debug.DrawRay(WaypointsModelAll[i].Position, WaypointsModelAll[i].Rotation * -Vector3.up * temDis, Color.red);
                                    break;
                                }
                            }

                            #endregion
                        }
                        break;
                    }
                }
            }
        }

        #endregion

        WaypointsModelAll.Clear();

        Transform lastTransform = null;//上次路标点

        foreach (Transform child in transform)
        {
            //上次路标点不为null时注视本次路标点
            if (lastTransform != null)
                lastTransform.LookAt(child.position);

            lastTransform = child;
            WaypointsModel temWM = new WaypointsModel();
            temWM.Index = int.Parse(child.transform.name);
            temWM.Position = child.position;
            temWM.Rotation = child.rotation;
            temWM.Scale = child.localScale;
            WaypointsModelAll.Add(temWM);
        }

        Gizmos.color = lineColor;
        for (int i = 0; i < WaypointsModelAll.Count; i++)
        {
            //Gizmos.DrawIcon(wayPointAll[i].position, "Waypoint.png");
            //Gizmos.DrawCube(wayPointAll[i].position, new Vector3(1f, 1f, 1f));

            if (i != 0)
            {
                //绘制一条从当前路标点到下个路标点的线
                if (showWaypoint)
                    Gizmos.DrawLine(WaypointsModelAll[i - 1].Position, WaypointsModelAll[i].Position);

                //是否绘制方向标识线
                if (showWaypointDir)
                    DrawDirLine(WaypointsModelAll[i - 1], WaypointsModelAll[i], lineWidth);
            }
            else if (isAroundCircle)
            {
                //如果绕圈则首尾相连(多圈和单圈区分)

                //路标点尾首相连
                if (showWaypoint)
                    Gizmos.DrawLine(WaypointsModelAll[WaypointsModelAll.Count - 1].Position, WaypointsModelAll[0].Position);

                //是否绘制方向标识线
                if (showWaypointDir)
                    DrawDirLine(WaypointsModelAll[WaypointsModelAll.Count - 1], WaypointsModelAll[0], lineWidth);
            }
        }
    }

    /// 绘制方向标识线 <summary>
    /// 绘制方向标识线
    /// </summary>
    /// <param name="wp1">路标点1</param>
    /// <param name="wp2">路标点2</param>
    /// <param name="_lineWidth">标识线宽度</param>
    private void DrawDirLine(WaypointsModel wm1, WaypointsModel wm2, float _lineWidth)
    {
        //计算方向标识线左边的点
        Vector3 dirLineLeft = wm1.Position + (wm1.Rotation * Vector3.right * (_lineWidth / 2f) * -1);

        //计算方向标识线右边的点
        Vector3 dirLineRight = wm1.Position + (wm1.Rotation * Vector3.right * (_lineWidth / 2f));

        //绘制一条连接左右两点的线
        Gizmos.DrawLine(dirLineLeft, dirLineRight);

        //绘制方向箭头(左右两点分别绘制一条连接下个路标点的线呈三角形)
        Gizmos.DrawLine(dirLineLeft, wm2.Position);
        Gizmos.DrawLine(dirLineRight, wm2.Position);
    }

    /// 加载XML至路标点 <summary>
    /// 加载XML至路标点
    /// </summary>
    /// <param name="xmlFileName">xml文件名(不包含路径)</param>
    /// <param name="all">路标点集合(父物体)</param>
    public void LoadXmlToWaypoints(WaypointMessage all, string xmlPath = null, string xmlString = null)
    {
        WaypointsXML temWaypointsXML = new WaypointsXML();
        WaypointsModel temWM = new WaypointsModel();

        int number = 0;

        all.WaypointsModelAll.Clear();

        //销毁子物体
        DestroyChild(all.transform);

        //获取XML数据至集合
        temWaypointsXML.GetXmlData(all.WaypointsModelAll, xmlPath, xmlString);
        for (int i = 0; i < all.WaypointsModelAll.Count; i++)
        {
            number++;

            //在编辑器中则创建
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                GameObject go = new GameObject();
                go.transform.parent = all.transform;
                go.name = all.WaypointsModelAll[i].Index.ToString();
                go.transform.position = all.WaypointsModelAll[i].Position;
                go.transform.rotation = all.WaypointsModelAll[i].Rotation;
                go.transform.localScale = all.WaypointsModelAll[i].Scale;
            }
        }

        if (Debug.isDebugBuild)
            Debug.Log("【" + all.WaypointsModelAll.Count.ToString() + "】加载完成：" + all.curWaypointsXMLPath);
    }

    /// 保存路标点至XML<summary>
    /// 保存路标点至XML
    /// </summary>
    /// <param name="xmlFileName">xml文件名(不包含路径)</param>
    /// <param name="all">路标点集合(父物体)</param>
    public void SaveWaypointsToXml(WaypointMessage all, string xmlPath)
    {
        WaypointsXML temWaypointsXML = new WaypointsXML();

        int number = 0;

        //xml是否存在,如果存在就删除
        //否则会叠加
        if (File.Exists(xmlPath))
            File.Delete(xmlPath);

        foreach (Transform child in all.transform)
        {
            number++;

            WaypointsModel temWM = new WaypointsModel();
            temWM.Index = int.Parse(child.transform.name);
            temWM.Position = child.position;
            temWM.Rotation = child.rotation;
            temWM.Scale = child.localScale;

            temWaypointsXML.AddXmlData(temWM, xmlPath);
        }

        //保存后刷新路标点
        LoadXmlToWaypoints(all, xmlPath);

        if (Debug.isDebugBuild)
            Debug.Log("【" + all.WaypointsModelAll.Count.ToString() + "】保存完成：" + all.curWaypointsXMLPath);
    }

    /// 添加路标点 <summary>
    /// 添加路标点
    /// </summary>
    /// <param name="all">路标点集合(父物体)</param>
    public void AddWaypoint(WaypointMessage all)
    {
        GameObject go = new GameObject();
        go.transform.parent = all.transform;
        Transform[] tt = all.transform.GetComponentsInChildren<Transform>();
        go.name = (tt.Length - 2).ToString();

        Selection.activeTransform = go.transform;
        //EditorApplication.ExecuteMenuItem("GameObject/Move To View");
        //go.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        if (all.WaypointsModelAll != null)
        {
            if (all.WaypointsModelAll.Count <= 0)
            {
                //生成的路标点移动到视窗内
                EditorApplication.ExecuteMenuItem("GameObject/Move To View");
            }
            else
            {
                Vector3 pos = all.WaypointsModelAll[all.WaypointsModelAll.Count - 1].Position + Vector3.up * 50f;
                Quaternion rota = all.WaypointsModelAll[all.WaypointsModelAll.Count - 1].Rotation;

                //生成的路标点在最后一个路标点的前方
                //当前位置 = 上个路标点位置 + 上个路标点旋转 * 世界位置前 * （最大两点距离 - 3f）
                go.transform.position = pos + rota * Vector3.forward * (maxWaypointDis - 3f);
                go.transform.rotation = all.WaypointsModelAll[all.WaypointsModelAll.Count - 1].Rotation;
            }
        }

        WaypointsModel wm = new WaypointsModel();
        wm.Index = int.Parse(go.name);
        wm.Position = go.transform.position;
        wm.Rotation = go.transform.rotation;
        wm.Scale = go.transform.localScale;
        WaypointsModelAll.Add(wm);
    }

    /// 刷新路标点 <summary>
    /// 刷新路标点
    /// </summary>
    /// <param name="all">路标点集合(父物体)</param>
    public void RefreshWaypoints(WaypointMessage all)
    {
        if (all.curWaypointsXMLText == null)
        {
            //置空路径
            all.curWaypointsXMLPath = null;

            //清空数据
            all.WaypointsModelAll.Clear();

            //销毁子物体
            DestroyChild(all.transform);
        }
        else
        {
            //获取XML文件路径
            all.curWaypointsXMLPath = AssetDatabase.GetAssetPath(all.curWaypointsXMLText);

            //重新加载以刷新数据
            all.LoadXmlToWaypoints(all, all.curWaypointsXMLPath, all.curWaypointsXMLText.text);
        }

        if (Debug.isDebugBuild)
            Debug.Log("【" + all.WaypointsModelAll.Count.ToString() + "】刷新完成：" + all.curWaypointsXMLPath);
    }

    /// 销毁所有子物体 <summary>
    /// 销毁所有子物体
    /// </summary>
    /// <param name="parent">父物体</param>
    private void DestroyChild(Transform parent)
    {
        //怪哉，非要多删除几次才能删除干净。。。
        for (int i = 0; i < 10; i++)
        {
            foreach (Transform child in parent)
            {
                DestroyImmediate(child.gameObject);
            }
        }
    }

    /// 帮助/联系作者 <summary>
    /// 帮助/联系作者
    /// </summary>
    public static void Help()
    {
        Application.OpenURL("http://www.cnblogs.com/shenggege");
        Application.OpenURL("tencent://message/?uin=6087537&Site=YS168&Menu=yes");
    }
}
