using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSetting : MonoBehaviour {

	public static int[] CarType;//1=red,2=blue,3=yellow,4=green
    public static int RaceMode;//1=time,2=score
    public static int trackNum;
    public static int []ControlMethod;
    public static int NumofPlayer;

    public static int PlayerNumofCarSelect;
    public static int PlayerNumofControlMethod;

    public GameObject CSDropDown1;
    public GameObject CSDropDown2;
    public GameObject CSDropDown3;
    public GameObject CSDropDown4;

    public GameObject CMDropDown1;
    public GameObject CMDropDown2;
    public GameObject CMDropDown3;
    public GameObject CMDropDown4;

    public GameObject NumofPlayerDisplay1;
    public GameObject NumofPlayerDisplay2;


    void Start()
    {
        CarType = new int[5];
        ControlMethod = new int[5];
        PlayerNumofCarSelect = 0;
        PlayerNumofControlMethod = 0;

        NumofPlayer = PlayerPrefs.GetInt("NumofPlayer");

        CarType[0] = PlayerPrefs.GetInt("SavedCarType0");
        CarType[1] = PlayerPrefs.GetInt("SavedCarType1");
        CarType[2] = PlayerPrefs.GetInt("SavedCarType2");
        CarType[3] = PlayerPrefs.GetInt("SavedCarType3");

        ControlMethod[0] = PlayerPrefs.GetInt("SavedContorlMethod0");
        ControlMethod[1] = PlayerPrefs.GetInt("SavedContorlMethod1");
        ControlMethod[2] = PlayerPrefs.GetInt("SavedContorlMethod2");
        ControlMethod[3] = PlayerPrefs.GetInt("SavedContorlMethod3");

        if (NumofPlayer != 2 && NumofPlayer != 3 && NumofPlayer != 4) NumofPlayer = 1;
    }
    void Update()
    {
        /*
        if(NumofPlayer == 1)
        {
            NumofPlayerDisplay1.GetComponent<TextMeshProUGUI>().text = "(1 player)";
            NumofPlayerDisplay2.GetComponent<TextMeshProUGUI>().text = "(1 player)";
        }
        else
        {
            NumofPlayerDisplay1.GetComponent<TextMeshProUGUI>().text = "(" + NumofPlayer + " players)";
            NumofPlayerDisplay2.GetComponent<TextMeshProUGUI>().text = "(" + NumofPlayer + " players)";
        }
        */
        if (NumofPlayer == 2)
        {
            CSDropDown1.SetActive(false);
            CSDropDown2.SetActive(true);
            CSDropDown3.SetActive(false);
            CSDropDown4.SetActive(false);
            CMDropDown1.SetActive(false);
            CMDropDown2.SetActive(true);
            CMDropDown3.SetActive(false);
            CMDropDown4.SetActive(false);
        }
        else if (NumofPlayer == 3)
        {
            CSDropDown1.SetActive(false);
            CSDropDown2.SetActive(false);
            CSDropDown3.SetActive(true);
            CSDropDown4.SetActive(false);
            CMDropDown1.SetActive(false);
            CMDropDown2.SetActive(false);
            CMDropDown3.SetActive(true);
            CMDropDown4.SetActive(false);
        }
        else if (NumofPlayer == 4)
        {
            CSDropDown1.SetActive(false);
            CSDropDown2.SetActive(false);
            CSDropDown3.SetActive(false);
            CSDropDown4.SetActive(true);
            CMDropDown1.SetActive(false);
            CMDropDown2.SetActive(false);
            CMDropDown3.SetActive(false);
            CMDropDown4.SetActive(true);
        }
        else
        {
            CSDropDown1.SetActive(true);
            CSDropDown2.SetActive(false);
            CSDropDown3.SetActive(false);
            CSDropDown4.SetActive(false);
            CMDropDown1.SetActive(true);
            CMDropDown2.SetActive(false);
            CMDropDown3.SetActive(false);
            CMDropDown4.SetActive(false);
        }
    }

    // Use this for initialization
    public void RedCar(){
        Debug.Log(PlayerNumofCarSelect.ToString() + ":1");
        CarType[PlayerNumofCarSelect] = 1;
        PlayerPrefs.SetInt("SavedCarType"+PlayerNumofCarSelect.ToString(), 1);
	}

	public void BlueCar(){
        Debug.Log(PlayerNumofCarSelect.ToString() + ":2");
        CarType[PlayerNumofCarSelect] = 2;
        PlayerPrefs.SetInt("SavedCarType" + PlayerNumofCarSelect.ToString(), 2);

    }

    public void YellowCar(){
        Debug.Log(PlayerNumofCarSelect.ToString() + ":3");
        CarType[PlayerNumofCarSelect] = 3;
        PlayerPrefs.SetInt("SavedCarType" + PlayerNumofCarSelect.ToString(), 3);

    }

    public void GreenCar(){
        Debug.Log(PlayerNumofCarSelect.ToString() + ":4");
        CarType[PlayerNumofCarSelect] = 4;
        PlayerPrefs.SetInt("SavedCarType" + PlayerNumofCarSelect.ToString(), 4);

    }
    public void WhiteCar()
    {
        Debug.Log(PlayerNumofCarSelect.ToString() + ":0");
        CarType[PlayerNumofCarSelect] = 0;
        PlayerPrefs.SetInt("SavedCarType" + PlayerNumofCarSelect.ToString(), 0);
    }
    public void BlackCar()
    {
        Debug.Log(PlayerNumofCarSelect.ToString() + ":5");
        CarType[PlayerNumofCarSelect] = 5;
        PlayerPrefs.SetInt("SavedCarType" + PlayerNumofCarSelect.ToString(), 5);
    }

    public void TimeMode(){
		RaceMode = 1;
        PlayerPrefs.SetInt("SavedRaceMode", RaceMode);

	}
	public void ScoreMode(){
		RaceMode = 2;
        PlayerPrefs.SetInt("SavedRaceMode", RaceMode);

	}

    public void OnePlayer()
    {
        NumofPlayer = 1;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
    }
    public void TwoPlayer()
    {
        NumofPlayer = 2;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
    }
    public void ThreePlayer()
    {
        NumofPlayer = 3;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
    }
    public void FourPlayer()
    {
        NumofPlayer = 4;
        PlayerPrefs.SetInt("NumofPlayer", NumofPlayer);
    }

    public void High()
    {
        QualitySettings.SetQualityLevel(5, true);
    }
    public void Medium()
    {
        QualitySettings.SetQualityLevel(3, true);
    }
    public void Low()
    {
        QualitySettings.SetQualityLevel(0, true);
    }

    public void Keyboard()
    {
        ControlMethod[PlayerNumofControlMethod] = 1;
        PlayerPrefs.SetInt("SavedContorlMethod" + PlayerNumofControlMethod.ToString(), 1);
    }

    public void Script()
    {
        ControlMethod[PlayerNumofControlMethod] = 2;
        PlayerPrefs.SetInt("SavedContorlMethod" + PlayerNumofControlMethod.ToString(), 2);
    }

    public void Play(){
        trackNum = PlayerPrefs.GetInt("SavedTrackNum");
        if (trackNum == 1)
            SceneManager.LoadScene(2);
        else if (trackNum == 2)
            SceneManager.LoadScene(3);
        else if (trackNum == 3)
            SceneManager.LoadScene(5);
        else
            SceneManager.LoadScene(5);

    }
}
