/**
  * @file LapTimeManager.cs
  * @brief 在TimeMode中巡线计时，并在窗口左上角显示巡线时间
  * @details
  * 挂载该脚本的对象：RaceArea → LapTimeManager\n
  * @author 李雨航
  * @date 2022-01-06
  */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class LapTimeManager : MonoBehaviour {
    /// 分
    public static int MinuteCount;
    /// 秒U
    public static int SecondCount;
    /// 毫秒
    public static float MilliCount;
    /// 用于显示的毫秒
    public static string MilliDisplay;

    /// 分UI
    public GameObject MinuteBox;
    /// 秒UI
    public GameObject SecondBox;
    /// 毫秒UI
    public GameObject MilliBox;


    void Start()
    {
        MilliCount = 0;
        SecondCount = 0;
        MinuteCount = 0;
    }

    // Update is called once per frame
    void Update () {
        //计时
        MilliCount += Time.deltaTime * 10;

        if (MilliCount >= 10) {
            SecondCount += 1;
            MilliCount = 0;
        }
        if (SecondCount >= 60)
        {
            MinuteCount += 1;
            SecondCount = 0;
        }

        //显示时间
        MilliDisplay = MilliCount.ToString ("F0");
        MilliBox.GetComponent<TextMeshProUGUI>().text = "" + MilliDisplay;

        if (SecondCount <= 9) {
            SecondBox.GetComponent<TextMeshProUGUI> ().text = "0" + SecondCount + ".";
        } else {
            SecondBox.GetComponent<TextMeshProUGUI> ().text = "" + SecondCount + ".";
        }

        if (MinuteCount <= 9) {
            MinuteBox.GetComponent<TextMeshProUGUI> ().text = "0" + MinuteCount + ":";
        } else {
            MinuteBox.GetComponent<TextMeshProUGUI> ().text = "" + MinuteCount + ":";
        }
    }
}
