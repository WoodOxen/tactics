/**
  * @file CruiseData.cs
  * @brief 计算小车距离中心线的距离、赛道曲率等
  * @details
  * 挂载该脚本的对象：：RaceArea → Car\n
  * WaypointsData为当前赛道中心点的数据，数据为xml格式，是通过CarWaypoints插件生成的。\n
  * 该插件可以很方便地获取赛道中心路标点。\n
  * 使用该插件时，需要将Editor文件夹中的CarWaypoints文件夹移动到Editor文件夹外；\n
  * 而使用完该插件后，需要将CarWaypoints文件夹放回Editor文件夹。\n
  * 该插件的使用教程可以在CarWaypoints文件夹中找到。\n
  * 计算小车距离中心线的距离的方法：\n
  * 获取距离小车最近的两个路标点，以这两点作直线，求小车距离该直线的距离。\n
  * 计算小车当前位置赛道中心线曲率的方法：\n
  * 获取离小车最近的一个路标点以及之后的第一个、第三个路标点，\n
  * 过这三个点做圆，该圆半径的倒数就为当前曲率。\n
  * @param CarNum 当前小车的编号，不同Car中CruiseData组分的CarNum数值不同
  * @param DistanceError 小车距离中心线的距离
  * @param Curvature 当前位置赛道中心线曲率
  * @param AngleError 小车方向和赛道中心线方向的差距
  * @param WaypointsData 当前赛道中心点的数据，数据为xml格式
  * @author 李雨航
  * @date 2022-01-06
  */


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CruiseData : MonoBehaviour
{
    public int closestWP_id = -1;

    private int last_closestWP_id = -1;
    private bool in_front_of_closestWP = true;
    private int numWP;
    /// 各车辆的巡线误差
    //public static float[] DistanceError = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public float distance_error = 0;
    /// 各车辆前方的赛道曲率
    //public static float[] Curvature = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public float curvature = 0;
    /// 各车辆的角度误差
    //public static float[] AngleError = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    //public float angle_error = 0;
    public float yaw = 0;//车头朝向与车辆中心到道路中心线最近点的切线夹角;弧度
    /// 该脚本计算的是几号车的巡线误差、赛道曲率、角度误差
    //[SerializeField] public int CarNum;

    //public GameObject ErrorDisplay;
    //public GameObject RadiusDisplay;


    /// 路标点数据文件 <summary>
    /// </summary>
    public TextAsset waypointsData = null;
    /// 路标点专用XML操作 <summary>
    /// </summary>
    private WaypointsXML _WaypointsXML = new WaypointsXML();
    /// 所有路标点 <summary>
    /// </summary>
    public List<WaypointsModel> WaypointsModelAll = new List<WaypointsModel>();
    void Start()
    {
        //获取路标点数据
        _WaypointsXML.GetXmlData(WaypointsModelAll, null, waypointsData.text);
        last_closestWP_id = -1;
        closestWP_id = GetClosestWP(transform.position);
        numWP = WaypointsModelAll.Count;
        //获取距离最近的路标点
        //WaypointsModel ClosestWP = GetClosestWP(WaypointsModelAll, transform.position);
    }

    void FixedUpdate()
    {
        //获取距离最近的路标点
        closestWP_id = GetClosestWP(transform.position);
        WaypointsModel closestWP = WaypointsModelAll[closestWP_id];
        //获取距离第二近的路标点
        /*float angle1 = Mathf.Atan2((transform.position.z - closestWP.Position.z) , (transform.position.x - closestWP.Position.x));
        float angle2 = closestWP.Rotation.eulerAngles.y * Mathf.Deg2Rad;
        while(angle2 > Mathf.PI || angle2 < -Mathf.PI){
            if (angle2 > Mathf.PI) angle2 -= 2 * Mathf.PI;
            else angle2 += 2 * Mathf.PI;
        }*/
        int tmp1 = closestWP_id + 1;
        int tmp2 = closestWP_id - 1;
        if (tmp1 >= numWP) tmp1 = 0;
        if (tmp2 < 0) tmp2 = numWP - 1;
        float dist1 = Mathf.Pow(WaypointsModelAll[tmp1].Position.x - transform.position.x, 2)+ Mathf.Pow(WaypointsModelAll[tmp1].Position.z - transform.position.z, 2);
        float dist2 = Mathf.Pow(WaypointsModelAll[tmp2].Position.x - transform.position.x, 2)+ Mathf.Pow(WaypointsModelAll[tmp2].Position.z - transform.position.z, 2);
        if (dist1 <= dist2)//即ClosestWP和ClosestWP+1号路标点是离车最近的两点  
        //if (Mathf.Abs(angle1 - angle2) < Mathf.PI/2)
        {
            in_front_of_closestWP = true;
            distance_error = GetCruiseError(WaypointsModelAll[closestWP_id].Position, WaypointsModelAll[tmp1].Position, transform.position);
        }
        else//即ClosestWP-1和ClosestWP号路标点是离车最近的两点  
        {
            in_front_of_closestWP = false;
            distance_error = GetCruiseError(WaypointsModelAll[tmp2].Position, WaypointsModelAll[closestWP_id].Position, transform.position);
        }

        //取出后两个坐标点，用于计算曲率
        tmp1 = closestWP_id;
        tmp2 = closestWP_id + 3;
        int tmp3 = closestWP_id + 5;
        //if (tmpNum1 < 0) tmpNum1 += NumofWP;
        if (tmp2 >= numWP) tmp2 -= numWP;
        if (tmp3 >= numWP) tmp3 -= numWP;
        curvature = GetCurvature(tmp1, tmp2, tmp3);
        //RadiusDisplay.GetComponent<TextMeshProUGUI>().text = "" + Curvature.ToString("#0.00");
        yaw = (WaypointsModelAll[closestWP_id].Rotation.y - transform.eulerAngles.y)* Mathf.Deg2Rad;
        //Debug.Log(string.Format("CruiseData{0} {1}:{2}", CallCppControl.a,CarNum, DistanceError[CarNum]));
        //ErrorDisplay.GetComponent<TextMeshProUGUI>().text = "" + DistanceError.ToString("#0.00");
        if(this.TryGetComponent<ShowMidline>(out ShowMidline showMidline)){
            Vector3 pos = GetWPk(10);
            ShowMidline show = this.GetComponent<ShowMidline>();
            show.Mark.GetComponent<Transform>().position = pos;
        }
    }
    /**
    * @fn GetCurvature
    * @brief 根据三个路标点获取前方道路曲率
    */
    private float GetCurvature(int WP1, int WP2, int WP3)
    {
        Vector2 pos1 = new Vector2(WaypointsModelAll[WP1].Position.x, WaypointsModelAll[WP1].Position.z);
        Vector2 pos2 = new Vector2(WaypointsModelAll[WP2].Position.x, WaypointsModelAll[WP2].Position.z);
        Vector2 pos3 = new Vector2(WaypointsModelAll[WP3].Position.x, WaypointsModelAll[WP3].Position.z);
        //判断共线
        if (Mathf.Abs(WaypointsModelAll[WP1].Rotation.y - WaypointsModelAll[WP2].Rotation.y)<0.01) return 0;
        //不共线：
        float radius;//曲率半径
        float dis, dis1, dis2, dis3;//距离
        float cosA;//ab确定的边所对应的角A的cos值
        dis1 = Vector2.Distance(pos1, pos2);
        dis2 = Vector2.Distance(pos1, pos3);
        dis3 = Vector2.Distance(pos2, pos3);
        dis = dis1 * dis1 + dis3 * dis3 - dis2 * dis2;
        cosA = dis / (2 * dis1 * dis3);//余弦定理
        radius = dis2 / (Mathf.Sqrt(1-cosA*cosA)*2);

        float cur = 1 / radius;
        return cur;
    }
    /**
    * @fn GetCruiseError
    * @brief 计算myPositon到直线pos1-pos2的距离
    * @details 方法参考https://zhuanlan.zhihu.com/p/176996694
    * @param[in] myPositon 车辆当前位置
    * @param[in] pos1 路标点1
    * @param[in] pos2 路标点2
    */
    private float GetCruiseError(Vector3 pos1, Vector3 pos2, Vector3 myPosition)
    {
        //y分量统一设为0
        Vector3 vec1 = new Vector3(pos2.x - pos1.x,0,pos2.z - pos1.z);
        Vector3 vec2 = new Vector3(myPosition.x - pos1.x,0,myPosition.z - pos1.z);
        //向量叉乘后y分量的正负性可以判断myposition在向量pos1~pos2的哪侧
        Vector3 tmp1 = Vector3.Cross(vec1, vec2);
        float WhichSide = Mathf.Sign(Vector3.Cross(vec1, vec2).y);
        float Area = tmp1.magnitude;
        float tmp2 = vec1.magnitude;
        float CruiseError = -WhichSide * Area / tmp2;//偏左为正，偏右为负；
        return CruiseError;
    }

    /// 获取距离最近的路径点 <summary>
    /// 获取距离最近的路径点
    /// </summary>
    /// <param name="DPs">路径点集合</param>
    /// <param name="myPosition">当前坐标</param>
    /// <returns>返回最近距离的路标点编号</returns>
    /// 
    private int GetClosestWP(Vector3 my_position,int search_range = 5)
    {
        //WaypointsModel tMin = null;
        float min_dist = Mathf.Infinity;//正无穷
        int closestWP = -1;

        if (last_closestWP_id == -1)//没有上一次调用的数据
        {
            int i = 0;
            for (i = 0; i < numWP; i++)
            {
                //忽略y轴上的距离（不考虑垂直地面方向的差别）
                float dist = Mathf.Pow((WaypointsModelAll[i].Position.x - my_position.x), 2) + Mathf.Pow((WaypointsModelAll[i].Position.z - my_position.z), 2);
                //float dist = Vector3.Distance(all[i].Position, myPosition);
                if (dist < min_dist)
                {
                    closestWP = i;
                    min_dist = dist;
                }
            }
            //tMin = all[closestWP];
        }
        else//有上一次调用的数据,只处理最近的（2*search_range + 1）个路标点
        {
            int j;
            int i;
            for(i = last_closestWP_id - search_range; i < last_closestWP_id + search_range; i++)
            {
                if (i < 0) j = i + numWP;
                else if (i >= numWP) j = i - numWP;
                else j = i;
                float dist = Mathf.Pow((WaypointsModelAll[j].Position.x - my_position.x), 2) + Mathf.Pow((WaypointsModelAll[j].Position.z - my_position.z), 2);
                //float dist = Vector3.Distance(all[j].Position, myPosition);
                if (dist < min_dist)
                {
                    closestWP = j;
                    min_dist = dist;
                }
            }
            //tMin = all[closestWP];
        }
        last_closestWP_id = closestWP;
        return closestWP;
    }
    /**
    * @fn GetDistance
    * @brief 计算两点距离
    */
    private float GetDistance(Vector3 pos1,Vector3 pos2)
    {
        float dist = Mathf.Pow(pos1.x - pos2.x, 2) + Mathf.Pow(pos1.y - pos2.y, 2) + Mathf.Pow(pos1.z - pos2.z, 2);
        return Mathf.Sqrt(dist);
    }
    /**
    * @fn GetDistance
    * @brief 计算两点距离平方
    */
    private float GetDistanceSquare(Vector3 pos1, Vector3 pos2)
    {
        float dist_square = Mathf.Pow(pos1.x - pos2.x, 2) + Mathf.Pow(pos1.y - pos2.y, 2) + Mathf.Pow(pos1.z - pos2.z, 2);
        return dist_square;
    }

    /**
    * @fn GetWPk
    * @brief 获取车辆沿道路中线k米处的点的坐标值
    * @param[in] k_dist 要获取车辆沿道路中线前方多少米处的点
    */
    public Vector3 GetWPk(float k_dist)
    {
        if (closestWP_id == -1) return new Vector3(0, 0, 0);
        float dist = 0;
        float tmpdist1 = GetDistanceSquare(WaypointsModelAll[closestWP_id].Position, this.GetComponent<Transform>().position);
        float tmpdist2 = distance_error * distance_error;
        float tmpdist3 = Mathf.Sqrt(tmpdist1 - tmpdist2);
        if (in_front_of_closestWP) dist -= tmpdist3;
        else dist += tmpdist3;

        int i = closestWP_id - 1;
        if (i < 0) i = numWP - 1;
        while(dist < k_dist)
        {
            i += 1;
            if (i >= numWP) i = 0;
            dist += GetWaypointsDistance.Waypoints_distance[i];
        }
        Vector3 pos1 = WaypointsModelAll[i].Position;
        Vector3 pos2;
        if (i+1 >= numWP)
            pos2 = WaypointsModelAll[0].Position;
        else
            pos2 = WaypointsModelAll[i + 1].Position;
        float dist_delt = dist - k_dist;
        
        //x坐标
        float x = pos2.x - (pos2.x - pos1.x) * dist_delt / GetWaypointsDistance.Waypoints_distance[i];
        //z坐标
        float z = pos2.z - (pos2.z - pos1.z) * dist_delt / GetWaypointsDistance.Waypoints_distance[i];
        //y坐标(竖直方向)
        float y = pos2.y - (pos2.y - pos1.y) * dist_delt / GetWaypointsDistance.Waypoints_distance[i];
        
        Vector3 ans = new Vector3(x, y, z);
        return ans;
    }

    /**
    * @fn GetWPkRelative
    * @brief 获取车辆沿道路中线k米处的相对于当前车辆坐标系的坐标值
    * @param[in] k_dist 要获取车辆沿道路中线前方多少米处的点
    */
    public Vector3 GetWPkRelative(float k_dist)
    {
        Vector3 position = GetWPk(k_dist);
        Transform car_coordinate_system = this.GetComponent<Transform>();
        Vector3 distance = position - car_coordinate_system.position;
        Vector3 relativePosition = Vector3.zero;
        relativePosition.x = Vector3.Dot(distance, car_coordinate_system.right.normalized);
        relativePosition.y = Vector3.Dot(distance, car_coordinate_system.up.normalized);
        relativePosition.z = Vector3.Dot(distance, car_coordinate_system.forward.normalized);
        return relativePosition;
    }
}
