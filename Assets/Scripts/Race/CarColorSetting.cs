using UnityEngine;
using System.Collections;

public class CarColorSetting : MonoBehaviour {

	public GameObject RedBody;
	public GameObject BlueBody;
	public GameObject YellowBody;
	public GameObject GreenBody;
	public GameObject WhiteBody;
    public GameObject BlackBody;

    public GameObject RedBody2;
    public GameObject BlueBody2;
    public GameObject YellowBody2;
    public GameObject GreenBody2;
    public GameObject WhiteBody2;
    public GameObject BlackBody2;

    public GameObject RedBody3;
    public GameObject BlueBody3;
    public GameObject YellowBody3;
    public GameObject GreenBody3;
    public GameObject WhiteBody3;
    public GameObject BlackBody3;

    public GameObject RedBody4;
    public GameObject BlueBody4;
    public GameObject YellowBody4;
    public GameObject GreenBody4;
    public GameObject WhiteBody4;
    public GameObject BlackBody4;

    public int CarImport;
    private int PlayerNum;

	// Use this for initialization
	void Start () {
        PlayerNum = GameSetting.NumofPlayer;
        //Set P1 CarColor
        CarImport = GameSetting.CarType[0];
        if (CarImport == 1) RedBody.SetActive(true);
        else if (CarImport == 2) BlueBody.SetActive(true);
        else if (CarImport == 3) YellowBody.SetActive(true);
        else if (CarImport == 4) GreenBody.SetActive(true);
        else if (CarImport == 5) BlackBody.SetActive(true);
        else WhiteBody.SetActive(true);

        if (PlayerNum > 1)
        {
            //Set P2 CarColor
            CarImport = GameSetting.CarType[1];
            if (CarImport == 1) RedBody2.SetActive(true);
            else if (CarImport == 2) BlueBody2.SetActive(true);
            else if (CarImport == 3) YellowBody2.SetActive(true);
            else if (CarImport == 4) GreenBody2.SetActive(true);
            else if (CarImport == 5) BlackBody2.SetActive(true);
            else WhiteBody2.SetActive(true);
        }
        if (PlayerNum > 2)
        {
            //Set P3 CarColor
            CarImport = GameSetting.CarType[2];
            if (CarImport == 1) RedBody3.SetActive(true);
            else if (CarImport == 2) BlueBody3.SetActive(true);
            else if (CarImport == 3) YellowBody3.SetActive(true);
            else if (CarImport == 4) GreenBody3.SetActive(true);
            else if (CarImport == 5) BlackBody3.SetActive(true);
            else WhiteBody3.SetActive(true);
        }
        if(PlayerNum > 3)
        {
            //Set P3 CarColor
            CarImport = GameSetting.CarType[3];
            if (CarImport == 1) RedBody4.SetActive(true);
            else if (CarImport == 2) BlueBody4.SetActive(true);
            else if (CarImport == 3) YellowBody4.SetActive(true);
            else if (CarImport == 4) GreenBody4.SetActive(true);
            else if (CarImport == 5) BlackBody4.SetActive(true);
            else WhiteBody4.SetActive(true);
        }
    }
}
