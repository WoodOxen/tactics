using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameModeManager : MonoBehaviour {

    public GameObject TimeDisplayUI;
    public GameObject TimeModeUIP1;
    public GameObject TimeModeUIP2;
    public GameObject TimeModeUIP3;
    public GameObject TimeModeUIP4;
    public GameObject TimeModePanelP1;
    public GameObject TimeModePanelP2;
    public GameObject TimeModePanelP3;
    public GameObject TimeModePanelP4;

    public GameObject ScoreModeUI1;
    public GameObject ScoreModeUI2;
    public GameObject ScoreModeUI3;
    public GameObject ScoreModeUI4;

    public GameObject ScoreModePanel1;
    public GameObject ScoreModePanel2;
    public GameObject ScoreModePanel3;
    public GameObject ScoreModePanel4;

    //public GameObject AIcar;
	public GameObject ScoreModeObject;
	public int ModeSelection;
	//public GameObject ScoreValue;
	//public GameObject PositionDisplay;

	public static int CurrentScore1;
    public static int CurrentScore2;
    public static int CurrentScore3;
    public static int CurrentScore4;

    public GameObject LapRequireDisplay;
    public GameObject MinimapAIcarMark;

    public GameObject Car2;
    public GameObject Car3;
    public GameObject Car4;

    public GameObject Car2MiniMap;
    public GameObject Car3MiniMap;
    public GameObject Car4MiniMap;

    private int PlayerNum;

    void Start () {
        DamageDisplay1.ExtentOfDamage = 0f;
        DamageDisplay1.CollisionNum = 0;
        DamageDisplay2.ExtentOfDamage = 0f;
        DamageDisplay2.CollisionNum = 0;
        DamageDisplay3.ExtentOfDamage = 0f;
        DamageDisplay3.CollisionNum = 0;
        DamageDisplay4.ExtentOfDamage = 0f;
        DamageDisplay4.CollisionNum = 0;
        PlayerNum = GameSetting.NumofPlayer;
        //CurrentScore = 0;
        ModeSelection = GameSetting.RaceMode;
		if (ModeSelection == 2) { //Score Mode
            //关闭TimeMode的一切UI(如果一开始就是关闭的，这部分即注释掉）
            
			TimeModeUIP1.SetActive (false);
            TimeModeUIP2.SetActive(false);
            TimeModeUIP3.SetActive(false);
            TimeModeUIP4.SetActive(false);

            TimeModePanelP1.SetActive(false);
            TimeModePanelP2.SetActive(false);
            TimeModePanelP3.SetActive(false);
            TimeModePanelP4.SetActive(false);

            TimeDisplayUI.SetActive(false);
            

            //开启部分SocreMode的物体
            ScoreModeObject.SetActive (true);
			//AIcar.SetActive (false);
            //MinimapAIcarMark.SetActive(false);
			//PositionDisplay.SetActive (false);
            LapRequireDisplay.GetComponent<TextMeshProUGUI>().text = "1" ;
            if (PlayerNum == 2)//2Players
            {
                ScoreModeUI1.SetActive(false);
                ScoreModeUI2.SetActive(true);
                ScoreModeUI3.SetActive(false);
                ScoreModeUI4.SetActive(false);

                ScoreModePanel2.SetActive(true);

                Car2.SetActive(true);
                Car3.SetActive(false);
                Car4.SetActive(false);

                Car2MiniMap.SetActive(true);
                Car3MiniMap.SetActive(false);
                Car4MiniMap.SetActive(false);
            }
            else if(PlayerNum == 3)
            {
                ScoreModeUI1.SetActive(false);
                ScoreModeUI2.SetActive(true);
                ScoreModeUI3.SetActive(true);
                ScoreModeUI4.SetActive(false);

                ScoreModePanel3.SetActive(true);

                Car2.SetActive(true);
                Car3.SetActive(true);
                Car4.SetActive(false);

                Car2MiniMap.SetActive(true);
                Car3MiniMap.SetActive(true);
                Car4MiniMap.SetActive(false);
            }
            else if (PlayerNum == 4)
            {
                ScoreModeUI1.SetActive(false);
                ScoreModeUI2.SetActive(true);
                ScoreModeUI3.SetActive(true);
                ScoreModeUI4.SetActive(true);

                ScoreModePanel4.SetActive(true);

                Car2.SetActive(true);
                Car3.SetActive(true);
                Car4.SetActive(true);

                Car2MiniMap.SetActive(true);
                Car3MiniMap.SetActive(true);
                Car4MiniMap.SetActive(true);
            }
            else
            {
                ScoreModeUI1.SetActive(true);
                ScoreModeUI2.SetActive(false);
                ScoreModeUI3.SetActive(false);
                ScoreModeUI4.SetActive(false);

                ScoreModePanel1.SetActive(true);

                Car2.SetActive(false);
                Car3.SetActive(false);
                Car4.SetActive(false);

                Car2MiniMap.SetActive(false);
                Car3MiniMap.SetActive(false);
                Car4MiniMap.SetActive(false);
            }
        }
		else{ // Time Mode
            //关闭ScoreMode的一切UI
            
            ScoreModeUI1.SetActive(false);
            ScoreModeUI2.SetActive(false);
            ScoreModeUI3.SetActive(false);
            ScoreModeUI4.SetActive(false);

            ScoreModePanel1.SetActive(false);
            ScoreModePanel2.SetActive(false);
            ScoreModePanel3.SetActive(false);
            ScoreModePanel4.SetActive(false);

            //开启部分RaceMode的UI
            TimeDisplayUI.SetActive(true);
            ScoreModeObject.SetActive(false);
            LapRequireDisplay.GetComponent<TextMeshProUGUI>().text = "1";
            if(PlayerNum == 2)
            {
                TimeModeUIP1.SetActive(false);
                TimeModeUIP2.SetActive(true);
                TimeModeUIP3.SetActive(false);
                TimeModeUIP4.SetActive(false);

                TimeModePanelP2.SetActive(true);

                Car2.SetActive(true);
                Car3.SetActive(false);
                Car4.SetActive(false);

                Car2MiniMap.SetActive(true);
                Car3MiniMap.SetActive(false);
                Car4MiniMap.SetActive(false);
            }
            else if (PlayerNum == 3)
            {
                TimeModeUIP1.SetActive(false);
                TimeModeUIP2.SetActive(true);
                TimeModeUIP3.SetActive(true);
                TimeModeUIP4.SetActive(false);

                TimeModePanelP3.SetActive(true);

                Car2.SetActive(true);
                Car3.SetActive(true);
                Car4.SetActive(false);

                Car2MiniMap.SetActive(true);
                Car3MiniMap.SetActive(true);
                Car4MiniMap.SetActive(false);
            }
            else if (PlayerNum == 4)
            {
                TimeModeUIP1.SetActive(false);
                TimeModeUIP2.SetActive(true);
                TimeModeUIP3.SetActive(true);
                TimeModeUIP4.SetActive(true);

                TimeModePanelP4.SetActive(true);

                Car2.SetActive(true);
                Car3.SetActive(true);
                Car4.SetActive(true);

                Car2MiniMap.SetActive(true);
                Car3MiniMap.SetActive(true);
                Car4MiniMap.SetActive(true);
            }
            else
            {
                TimeModeUIP1.SetActive(true);
                TimeModeUIP2.SetActive(false);
                TimeModeUIP3.SetActive(false);
                TimeModeUIP4.SetActive(false);

                TimeModePanelP1.SetActive(true);

                Car2.SetActive(false);
                Car3.SetActive(false);
                Car4.SetActive(false);

                Car2MiniMap.SetActive(false);
                Car3MiniMap.SetActive(false);
                Car4MiniMap.SetActive(false);
            }
        }

        /*
        if(PlayerNum == 2)
        {
            Car2.SetActive(true);
            Car3.SetActive(false);
            Car4.SetActive(false);
        }
        else if(PlayerNum == 3)
        {
            Car2.SetActive(true);
            Car3.SetActive(true);
            Car4.SetActive(false);
        }
        else if (PlayerNum == 4)
        {
            Car2.SetActive(true);
            Car3.SetActive(true);
            Car4.SetActive(true);
        }*/
    }
	
}
