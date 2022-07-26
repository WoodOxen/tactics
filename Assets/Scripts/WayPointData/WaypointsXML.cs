/// CarWaypoints v1.0 (赛车路标点插件) <summary>
/// 作者：阿升哥哥
/// 博客：http://www.cnblogs.com/shenggege
/// 联系方式：6087537@qq.com
/// 最后修改：2015/2/15 1:00
/// </summary>

using UnityEngine;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System;

/// 路标点专用XML操作 <summary>
/// 路标点专用XML操作
/// </summary>
public class WaypointsXML
{
    /// 添加XML数据 <summary>
    /// 添加XML数据
    /// </summary>
    /// <param name="_path">欲添加路标点实体</param>
    /// <param name="wm">xml文件路径</param>
    public void AddXmlData(WaypointsModel wm, string xmlPath)
    {
        CheckXmlFile(xmlPath);//检测XML文件

        if (File.Exists(xmlPath))
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(xmlPath);

            XmlNode root = xmlDoc.SelectSingleNode("waypoints");
            XmlElement elmNew = xmlDoc.CreateElement("waypoint");
            elmNew.SetAttribute("index", wm.Index.ToString());

            XmlElement position = xmlDoc.CreateElement("position");
            position.InnerText = wm.Position.ToString();

            XmlElement rotation = xmlDoc.CreateElement("rotation");
            rotation.InnerText = wm.Rotation.ToString();
            XmlElement scale = xmlDoc.CreateElement("scale");
            scale.InnerText = wm.Scale.ToString();

            elmNew.AppendChild(position);
            elmNew.AppendChild(rotation);
            elmNew.AppendChild(scale);
            root.AppendChild(elmNew);
            xmlDoc.AppendChild(root);
            xmlDoc.Save(xmlPath);
        }
    }

    /// 获取XML数据 <summary>
    /// 获取XML数据
    /// </summary>
    /// <param name="_Waypoints">保存路标点集合</param>
    /// <param name="xmlPath">xml文件路径</param>
    /// <param name="xmlString">xml文本数据</param>
    public void GetXmlData(List<WaypointsModel> _Waypoints, string xmlPath = null, string xmlString = null)
    {
        if (File.Exists(xmlPath) || xmlPath == null)
        {
            XmlDocument xmlDoc = new XmlDocument();

            if (xmlPath == null)
            {
                xmlDoc.LoadXml(xmlString);
            }
            else
            {
                xmlDoc.Load(xmlPath);
            }

            XmlNodeList nodeList = xmlDoc.SelectSingleNode("waypoints").ChildNodes;

            foreach (XmlElement xml1 in nodeList)
            {
                WaypointsModel temWaypoint = new WaypointsModel();
                temWaypoint.Index = Convert.ToInt32(xml1.GetAttribute("index"));

                foreach (XmlElement xml2 in xml1.ChildNodes)
                {
                    switch (xml2.Name)
                    {
                        case "position":
                            temWaypoint.Position = StringToVector3(xml2.InnerText);
                            break;

                        case "rotation":
                            temWaypoint.Rotation = StringToQuaternion(xml2.InnerText);
                            break;

                        case "scale":
                            temWaypoint.Scale = StringToVector3(xml2.InnerText);
                            break;
                    }
                }

                //添加进路标点集合
                _Waypoints.Add(temWaypoint);
            }
        }
    }

    /// 检测XML文件是否存在，不存在则创建 <summary>
    /// 检测XML文件是否存在，不存在则创建
    /// </summary>
    /// <param name="_path">xml文件路径</param>
    private void CheckXmlFile(string _path)
    {
        //xml是否存在，不存在则创建
        if (!File.Exists(_path))
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("waypoints");

            xmlDoc.AppendChild(root);
            xmlDoc.Save(_path);
        }
    }

    /// string转Vector3 <summary>
    /// string转Vector3
    /// </summary>
    /// <param name="st">字符串</param>
    /// <returns>返回转换后的Vector3</returns>
    private Vector3 StringToVector3(string st)
    {
        string[] splitString = st.Replace("(", "").Replace(")", "").Split(new char[] { ',' });

        //防止智商挫计
        if (splitString.Length != 3)
            return new Vector3(0f, 0f, 0f);

        return new Vector3(
            float.Parse(splitString[0]),
            float.Parse(splitString[1]),
            float.Parse(splitString[2]));
    }

    /// string转Quaternion <summary>
    /// string转Quaternion
    /// </summary>
    /// <param name="st">字符串</param>
    /// <returns>返回转换后的Vector4</returns>
    private Quaternion StringToQuaternion(string st)
    {
        string[] splitString = st.Replace("(", "").Replace(")", "").Split(new char[] { ',' });

        //防止智商挫计
        if (splitString.Length != 4)
            return new Quaternion(0f, 0f, 0f, 0f);

        return new Quaternion(
            float.Parse(splitString[0]),
            float.Parse(splitString[1]),
            float.Parse(splitString[2]),
            float.Parse(splitString[3]));
    }
}
