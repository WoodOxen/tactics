using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.VehicleEditor
{
    static class CommonTool
    {
        public static void ChangeLayer(Transform trans, int layer)
        {
            trans.gameObject.layer = layer;
            foreach (Transform child in trans)
            {
                ChangeLayer(child, layer);
            }
        }
        public static void SetHightlight(Transform t, bool on)
        {
            MeshRenderer mr = t.GetComponent<MeshRenderer>();
            if (mr)
            {
                Material[] mats = mr.materials;
                mats[mr.materials.Length-1] = on? Resources.Load<Material>("Materials/Rimlight"): Resources.Load<Material>("Materials/Transparent");
                mr.materials = mats;
            }
            foreach (Transform child in t)
            {
                SetHightlight(child,on);
            }
        }
    }
}
