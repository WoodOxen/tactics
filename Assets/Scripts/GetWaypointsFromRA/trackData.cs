using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class trackData
{
    public List<Vector3> way_points_pos = new List<Vector3>();
    public List<Vector3> way_points_rot = new List<Vector3>();
    public List<int> node_belonging_to = new List<int>();
}
