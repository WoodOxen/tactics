/// CarWaypoints v1.0 (赛车路标点插件) <summary>
/// 作者：阿升哥哥
/// 博客：http://www.cnblogs.com/shenggege
/// 联系方式：6087537@qq.com
/// 最后修改：2015/2/14 23:20
/// </summary>

using UnityEngine;

/// 路标点实体类 <summary>
/// 路标点实体类
/// </summary>
public class WaypointsModel
{
    private int _index;
    public int Index
    {
        get { return _index; }
        set { _index = value; }
    }

    private Vector3 _position;
    public Vector3 Position
    {
        get { return _position; }
        set { _position = value; }
    }

    private Quaternion _rotation;
    public Quaternion Rotation
    {
        get { return _rotation; }
        set { _rotation = value; }
    }

    private Vector3 _scale;
    public Vector3 Scale
    {
        get { return _scale; }
        set { _scale = value; }
    }

    private bool _show = false;
    public bool Show
    {
        get { return _show; }
        set { _show = value; }
    }
}
