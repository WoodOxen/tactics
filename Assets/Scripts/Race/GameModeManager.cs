/**
  * @file GameModeManager.cs
  * @brief 根据用户选择的模式，设置巡线时的UI以及相关GameObject
  * @details
  * 挂载该脚本的对象：RaceArea → ModeManager\n
  * 首先将车辆损伤、车辆得分等数据置零。\n
  * 若选择TimeMode（也即RaceMode），则需要将TimeMode相关的UI开启，显示巡线时间和车辆损伤。\n
  * 若选择ScoreMode，则需要将ScoreMode相关的UI开启，显示每辆车所得分数和损伤。同时，还要将赛道上的奖励宝石setActive（也即ScoreObjects）\n
  * 同时还要考虑参与玩家的数量不同导致的UI差别。
  * @author 李雨航
  * @date 2022-01-06
  */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameModeManager : MonoBehaviour {
    /// 显示时间的UI 
    public GameObject TimeDisplayUI;
    /// TimeModeUI[i]为TimeMode下共i辆车参与仿真时显示各车辆demage的文字UI 
    public GameObject[] TimeModeUI;
    /// TimeModePanel[i]为TimeMode下共i辆车参与仿真时显示各车辆demage的框图UI 
    public GameObject[] TimeModePanel;

    /// ScoreModeUI[i]为ScoreMode下共i辆车参与仿真时显示各车辆demage和score的文字UI 
    public GameObject[] ScoreModeUI;
    /// ScoreModePanel[i]为ScoreMode下共i辆车参与仿真时显示各车辆demage和score的框图UI 
    public GameObject[] ScoreModePanel;
    /// ScoreMode下场景中的宝石 
    public GameObject ScoreModeObject;
    private int ModeSelection;

    /// 显示要求圈数的UI 
    public GameObject LapRequireDisplay;

    /// 各车辆 
    public GameObject[] Car;
    /// 各车辆的小地图图标 
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
