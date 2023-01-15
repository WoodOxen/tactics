/**
  * @file RaceFinish.cs
  * @brief 巡线结束时执行的代码
  * @details
  * 挂载该脚本的对象：RaceArea → RaceFinish\n
  * 主要功能为关闭车辆控制相关的代码，并呼出巡线结束的UI。\n
  * 其中ScoreMode和TimeMode的结束UI不完全相同。
  * @author 李雨航
  * @date 2022-01-06
  */

using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

//当巡线结束时，会调用该代码
public class RaceFinish : MonoBehaviour {
    /// 各车辆
    public GameObject[] PlayerCar;

    /// 终点触发器
    public GameObject CompleteTrig;
    /// 结束音效
    public AudioSource FinishBGM;

    public GameObject levelBGM;

    /// 计时的GameObject
    public GameObject TimeManager;

    /// 结束窗口UI
    public GameObject CompletePanel;

    public GameObject ScoreModeLabel;
    public GameObject TimeModeLabel;
    public GameObject ScoreDisplayBox;
    public GameObject TimeDisplay;
    public GameObject CollisionNumDisplay;
    public GameObject TotalDamageDisplay;
    public GameObject GradeDisplay;
    public GameObject CallCppControl;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;

    private int RaceMode;
    private int PlayerNum;

    void Start() {

        //关闭车辆控制相关的代码
        PlayerNum = GameSetting.NumofPlayer;
        for(int i = 0;i < PlayerNum; i++)
        {
            PlayerCar[i].SetActive(false);
        }   
        CompleteTrig.SetActive (false);

        for (int i = 0; i < PlayerNum; i++)
        {
            PlayerCar[i].GetComponent<CarAudio>().enabled = false;
            PlayerCar[i].GetComponent<CarController>().enabled = false;
            PlayerCar[i].GetComponent<LoadControl>().enabled = false;
            if (i < 4) PlayerCar[i].GetComponent<CarControlKeyBoard>().enabled = false;
        }
        CallCppControl.SetActive(false);

        for (int i = 0; i < PlayerNum; i++)
        {
            PlayerCar[i].SetActive(true);
        }

        //关闭关卡音乐（如果有的话），播放巡线结束的提示音
        levelBGM.SetActive (false);
        FinishBGM.Play ();

        //巡线完成的UI
        CompletePanel.SetActive(true);
        RaceMode = GameSetting.RaceMode;
        CollisionNumDisplay.GetComponent<TextMeshProUGUI>().text = "" + DamageDisplay.CollisionNum[0];
        TotalDamageDisplay.GetComponent<TextMeshProUGUI>().text = "" + DamageDisplay.ExtentOfDamage[0];
        GradeDisplay.GetComponent<TextMeshProUGUI>().text = "coming soon";//we need a algorithm to calculate the grade
        
        if (RaceMode == 2)
        {
            //若为ScoreMode，额外显示车辆所得分数
            //暂时只显示第一辆车的分数
            ScoreModeLabel.SetActive(true);
            ScoreDisplayBox.SetActive(true);
            ScoreDisplayBox.GetComponent<TextMeshProUGUI>().text = "" + ScoreDisplay.Score[0];
        }
        else
        {
            //若为TimeMode，额外显示巡线时间，并停止计时
            //暂时只显示第一辆车的巡线时间
            TimeModeLabel.SetActive(true);
            TimeDisplay.SetActive(true);
            TimeDisplay.GetComponent<TextMeshProUGUI>().text = ""
                + MinuteBox.GetComponent<TextMeshProUGUI>().text 
                + SecondBox.GetComponent<TextMeshProUGUI>().text 
                + MilliBox.GetComponent<TextMeshProUGUI>().text;
            LapTimeManager.MinuteCount = 0;
            LapTimeManager.SecondCount = 0;
            LapTimeManager.MilliCount = 0;
            TimeManager.SetActive(false);
        }
    }
}
