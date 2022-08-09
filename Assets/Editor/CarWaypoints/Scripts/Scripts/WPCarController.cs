using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WPCarController : MonoBehaviour
{
    /// 路标点数据文件 <summary>
    /// 路标点数据文件
    /// </summary>
    public TextAsset waypointsData = null;

    /// 路标点专用XML操作 <summary>
    /// 路标点专用XML操作
    /// </summary>
    private WaypointsXML _WaypointsXML = new WaypointsXML();

    /// 所有路标点 <summary>
    /// 所有路标点
    /// </summary>
    public List<WaypointsModel> WaypointsModelAll = new List<WaypointsModel>();

    /// 检测路标点 <summary>
    /// 用来保存已通过的路标点
    /// 同样的路标点则不加入
    /// 冲过终点线时取数量
    /// 大于最少数量则算通过一圈
    /// </summary>
    private List<WaypointsModel> CheckPoints = new List<WaypointsModel>();

    //完成圈数最少检查点
    private int minCheckPoints = 35;
    private int totalCircleNumber = 3;//总圈数
    private int currentCircleNumber = 1;//当前圈数

    void Start()
    {
        //获取路标点数据
        _WaypointsXML.GetXmlData(WaypointsModelAll, null, waypointsData.text);

        Debug.Log("赛道总长度:" + CalcTotalDis().ToString());//计算赛道长度
    }

    void FixedUpdate()
    {
        isReverse();//反向检测
        CircleNumberCheck();//圈数检测

        if (Input.GetKey(KeyCode.R))
            RecoverCar();//重置赛车
    }

    #region 一些示例，可自行扩展

    /// 重置赛车 <summary>
    /// 重置赛车
    /// </summary>
    private void RecoverCarA()
    {
        //获取距离最近的路标点
        WaypointsModel ClosestWP = GetClosestWP(WaypointsModelAll, transform.position);

        //置赛车位置
        transform.position = ClosestWP.Position;

        //置车头朝向
        transform.rotation = Quaternion.LookRotation(ClosestWP.Rotation * Vector3.forward);

        //移动速度归零
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        //角速度归零
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }


    /// 重置赛车 <summary>
    /// 重置赛车
    /// </summary>
    private void RecoverCar()
    {
        //获取距离最近的路标点
        WaypointsModel ClosestWP = GetClosestWP(WaypointsModelAll, transform.position);

        //下个路标点索引
        int nextIndex = ClosestWP.Index + 1;

        //最近路标点
        Vector3 nearestPoint;

        //下一个复位点索引 小于 路标点数量 - 1
        if (nextIndex < WaypointsModelAll.Count - 1)
        {
            //获取两个路标点间离赛车最近的点
            nearestPoint = NearestPoint(
                ClosestWP.Position,
                WaypointsModelAll[nextIndex].Position, 
                transform.position);
        }
        else
        {
            //最后一个点和起点之间时取最后一个点的位置
            nearestPoint = WaypointsModelAll[WaypointsModelAll.Count - 1].Position;
        }


        #region 新添加

        RaycastHit[] hit;

        //是否碰撞到地面
        bool isColliderGround = false;

        //向下发送射线
        hit = Physics.RaycastAll(nearestPoint, ClosestWP.Rotation * -Vector3.up, 100f);
        
        for (int i1 = 0; i1 < hit.Length; i1++)
        {
            //当碰撞到的物体为地面时
            if (hit[i1].transform.tag == "Map_ground")
            {
                isColliderGround = true;

                //计算当前路标点与地面之间的距离
                float temDis = Vector3.Distance(nearestPoint, hit[i1].point);

                //调整距离
                nearestPoint.y = nearestPoint.y - (temDis - 0.5f);

                //Debug.Log(temDis);

                //绘制高度线
                //Debug.DrawRay(WaypointsModelAll[i].Position, WaypointsModelAll[i].Rotation * -Vector3.up * temDis, Color.red);
                break;
            }
        }

        //如果没有碰撞到地面
        //则说明赛车下面没有地面，处于悬空状态
        //取最近路标点为复位点
        if (!isColliderGround)
            nearestPoint = WaypointsModelAll[ClosestWP.Index].Position;

        #endregion


        transform.position = nearestPoint;
        transform.rotation = Quaternion.LookRotation(ClosestWP.Rotation * Vector3.forward);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    /// 获取两点之间离赛车的最近点 <summary>
    /// 获取两点之间离赛车的最近点
    /// </summary>
    /// <param name="lineStart">最近路标点</param>
    /// <param name="lineEnd">下一个路标点</param>
    /// <param name="point">赛车位置</param>
    /// <returns></returns>
    private Vector3 NearestPoint(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
    {
        //线方向
        Vector3 lineDirection = Vector3.Normalize(lineEnd - lineStart);

        //最近点
        float closestPoint = Vector3.Dot((point - lineStart), lineDirection);

        //返回最近点
        return lineStart + (closestPoint * lineDirection);
    }


    /// 检测反向移动 <summary>
    /// 检测反向移动
    /// 思路如下：
    /// 通过Waypoint检测到离赛车最近的点
    /// 然后通过计算点的距离而得出是否反向
    /// </summary>
    private void isReverse()
    {

        WaypointsModel ClosestWP = GetClosestWP(WaypointsModelAll, transform.position);//获取距离最近的路径点

        //角度偏移 = 最近路径点的角度 - 赛车的角度
        float angleOffset = ClosestWP.Rotation.eulerAngles.y - transform.eulerAngles.y;

        /* 理论上来说
         * 完全可以只写成 if(Mathf.Abs(angleOffset) >= 90f)
         * 则判断为反向！但是实际运用时会出现问题
         * 因为赛道是围成圈形的(首尾相连)
         * 当赛车移动到下半圈的时候
         * 明明是正确的方向，但是却提示反向了
         * 所以为了避免这种情况发生，我们要用360-90=270
         * 如果还是不理解的话debug路径点角度和赛车的角度就会发现端倪了*/

        Debug.Log(angleOffset);
        //角度偏移<=270f && 角度偏移>=90f && 刚体速度>8f
        if (Mathf.Abs(angleOffset) <= 270f && Mathf.Abs(angleOffset) >= 90f)
            Debug.Log("反向移动了:" + Mathf.Abs(angleOffset).ToString());
    }

    /// 圈数检测 <summary>
    /// 圈数检测
    /// 思路如下：
    /// 每一帧计算距离最近的检查点
    /// 检查点存在则不添加，不存在则添加
    /// 冲过终点线时取数量
    /// 大于最少数量则算通过一圈
    /// 然后清零 CheckPoints
    /// </summary>
    private void CircleNumberCheck()
    {
        WaypointsModel ClosestWP = GetClosestWP(WaypointsModelAll, transform.position);//获取距离最近的路径点

        //判断当前最近路标点是否已存在
        for (int i = 0; i < CheckPoints.Count; i++)
        {
            //存在则返回
            if (ClosestWP.Position == CheckPoints[i].Position)
                return;
        }

        //不存在则添加
        CheckPoints.Add(ClosestWP);
        //Debug.Log(ClosestWP.Index);
    }

    /// 计算赛道长度 <summary>
    /// 计算赛道长度
    /// </summary>
    /// <returns>返回赛道长度</returns>
    private float CalcTotalDis()
    {
        //把所有点和点的距离相加而得出

        float temTotalDis = 0f;//临时总距离
        for (int i = 0; i < WaypointsModelAll.Count; i++)
        {
            if (i >= WaypointsModelAll.Count - 1)
            { temTotalDis += Vector3.Distance(WaypointsModelAll[i].Position, WaypointsModelAll[0].Position); }
            else
            { temTotalDis += Vector3.Distance(WaypointsModelAll[i].Position, WaypointsModelAll[i + 1].Position); }
        }

        return temTotalDis;
    }

    /// 获取距离最近的路径点 <summary>
    /// 获取距离最近的路径点
    /// </summary>
    /// <param name="DPs">路径点集合</param>
    /// <param name="myPosition">当前坐标</param>
    /// <returns>返回最近距离的路标点</returns>
    private WaypointsModel GetClosestWP(List<WaypointsModel> all, Vector3 myPosition)
    {
        WaypointsModel tMin = null;
        float minDist = Mathf.Infinity;//正无穷

        for (int i = 0; i < all.Count; i++)
        {
            float dist = Vector3.Distance(all[i].Position, myPosition);
            if (dist < minDist)
            {
                tMin = all[i];
                minDist = dist;
            }
        }
        return tMin;
    }



    void OnTriggerEnter(Collider Trigger)
    {
        //检查点数量大于最小检查点数量则算一圈
        if (minCheckPoints <= CheckPoints.Count)
        {
            currentCircleNumber++;

            if (currentCircleNumber > totalCircleNumber)
            {
                Debug.Log("游戏完成");
                return;
            }

            Debug.Log("当前圈数：" + currentCircleNumber.ToString());

            //清空检测点
            CheckPoints.Clear();
        }
    }

    #endregion
}
