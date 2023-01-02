using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameModeManager : MonoBehaviour {

    public GameObject TimeDisplayUI;
    public GameObject[] TimeModeUI;

    public GameObject[] TimeModePanel;

    public GameObject[] ScoreModeUI;

    public GameObject[] ScoreModePanel;

    public GameObject ScoreModeObject;
    private int ModeSelection;

    public GameObject LapRequireDisplay;

    public GameObject[] Car;

    public GameObject[] CarMiniMap;

    private int PlayerNum;

    private void RaceInitialize(int playerNum)
    {
        for(int i = 0;i < playerNum; i++)
        {
            DamageDisplay.ExtentOfDamage[i] = 0f;
            DamageDisplay.CollisionNum[i] = 0;
            ScoreDisplay.Score[i] = 0;
        }
    }

    void Start () {
        
        PlayerNum = GameSetting.NumofPlayer;
        RaceInitialize(PlayerNum);

        //CurrentScore = 0;
        ModeSelection = GameSetting.RaceMode;

        if (ModeSelection == 2) { //Score Mode
            //开启部分SocreMode的对象
            ScoreModeObject.SetActive (true);
            if(PlayerNum <= 4)ScoreModePanel[PlayerNum-1].SetActive(true);
            else ScoreModePanel[3].SetActive(true);

            //设置Score模式下的圈数
            LapRequireDisplay.GetComponent<TextMeshProUGUI>().text = "1" ;
            
            //根据参与人数设置UI
            for (int i = 0;i < PlayerNum; i++)
            {
                Car[i].SetActive(true);
                if (i > 3) continue;//第5~8辆车没有对应的UI
                ScoreModeUI[i].SetActive(true);
                CarMiniMap[i].SetActive(true);
            }
        }
        else{ // Time Mode
            //开启部分RaceMode的UI
            TimeDisplayUI.SetActive(true);
            TimeModePanel[PlayerNum - 1].SetActive(true);
            //设置RaceMode的圈数
            LapRequireDisplay.GetComponent<TextMeshProUGUI>().text = "1";
            //根据参与人数开启UI
            for (int i = 0; i < PlayerNum; i++)
            {
                Car[i].SetActive(true);
                TimeModeUI[i].SetActive(true);
                if (i > 3) continue;//第5~8辆车没有对应的UI
                CarMiniMap[i].SetActive(true);
            }
        }
    }
}
