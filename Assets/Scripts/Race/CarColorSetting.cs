using UnityEngine;
using System.Collections;

public class CarColorSetting : MonoBehaviour {
    public Material[] material;
    public GameObject[] CarBody;

    Renderer rend;
    int CarImport;
    int PlayerNum;

    void Start () {
        if (!GameSetting.InitializeFlag)
        {
            //正常运行时GameSetting.InitializeFlag均为true
            //在调试时可能直接在巡线场景开始运行，因此需要在这里进行部分初始化操作
            Debug.Log("InitializeFlag=true");
            GameSetting.InitializeFlag = true;
            GameSetting.CarType = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            GameSetting.ControlMethod = new int[8] { 0, 0, 0, 0, 2, 2, 2, 2};

            //根据用户上次的设置，对部分参数进行初始化；如果没有用户上次设置的记录，则使用默认值
            if (PlayerPrefs.HasKey("NumofPlayer")) GameSetting.NumofPlayer = PlayerPrefs.GetInt("NumofPlayer");
            else GameSetting.NumofPlayer = 1;

            for (int i = 0; i < 8; i++)
            {
                if (PlayerPrefs.HasKey("SavedCarType" + i.ToString())) GameSetting.CarType[i] = PlayerPrefs.GetInt("SavedCarType" + i.ToString());
                else GameSetting.CarType[i] = 0;
            }
            for (int i = 0; i < 4; i++)
            {
                if (PlayerPrefs.HasKey("SavedContorlMethod" + i.ToString())) GameSetting.ControlMethod[i] = PlayerPrefs.GetInt("SavedContorlMethod" + i.ToString());
                else GameSetting.ControlMethod[i] = 1;
            }

            if (PlayerPrefs.HasKey("SavedRaceMode")) GameSetting.RaceMode = PlayerPrefs.GetInt("SavedRaceMode");
            else GameSetting.RaceMode = 1;
            if (PlayerPrefs.HasKey("SavedTrackNum")) GameSetting.trackNum = PlayerPrefs.GetInt("SavedTrackNum");
            else GameSetting.trackNum = 3;
        }

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
