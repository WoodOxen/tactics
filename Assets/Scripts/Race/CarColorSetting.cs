using UnityEngine;
using System.Collections;

public class CarColorSetting : MonoBehaviour {
    public Material[] material;
    public GameObject[] CarBody;

    Renderer rend;
    int CarImport;
    int PlayerNum;

    void Start () {
        PlayerNum = GameSetting.NumofPlayer;

        for(int i = 0; i < PlayerNum; i++)
        {
            SetCarColor(i);
        }
    }
    void SetCarColor(int Num)
    {
        CarImport = GameSetting.CarType[Num];
        rend = CarBody[Num].GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[CarImport];
    }
}
