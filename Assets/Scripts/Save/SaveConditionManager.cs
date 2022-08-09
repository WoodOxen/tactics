using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

public class SaveConditionManager : MonoBehaviour
{
    public static int Save1Track = 0;
    public static int Save2Track = 0;
    public static int Save3Track = 0;
    public static int Save4Track = 0;

    public GameObject Save1TrackDisplay;
    public GameObject Save2TrackDisplay;
    public GameObject Save3TrackDisplay;
    public GameObject Save4TrackDisplay;

    public GameObject Save1button;
    public GameObject Save2button;
    public GameObject Save3button;
    public GameObject Save4button;

    void Start()
    {
        SaveCondition saveCondition = new SaveCondition();
        if (!File.Exists(Application.dataPath + "/saveCondition.txt"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Create(Application.dataPath + "/saveCondition.txt");
            binaryFormatter.Serialize(fileStream, saveCondition);
            fileStream.Close();
        }
        else
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(Application.dataPath + "/saveCondition.txt", FileMode.Open);
            saveCondition = (SaveCondition)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
        }

        Save1Track = saveCondition.Save1Track;
        Save2Track = saveCondition.Save2Track;
        Save3Track = saveCondition.Save3Track;
        Save4Track = saveCondition.Save4Track;
    }


    void Update()
    {
        if (Save1Track == 0)
        {
            Save1TrackDisplay.GetComponent<TextMeshProUGUI>().text = "None";
            Save1button.SetActive(false);
        }
        else
        {
            Save1TrackDisplay.GetComponent<TextMeshProUGUI>().text = "Track0" + Save1Track;
            Save1button.SetActive(true);
        }

        if (Save2Track == 0)
        {
            Save2TrackDisplay.GetComponent<TextMeshProUGUI>().text = "None";
            Save2button.SetActive(false);
        }
        else
        {
            Save2TrackDisplay.GetComponent<TextMeshProUGUI>().text = "Track0" + Save1Track;
            Save2button.SetActive(true);
        }

        if (Save3Track == 0)
        {
            Save3TrackDisplay.GetComponent<TextMeshProUGUI>().text = "None";
            Save3button.SetActive(false);
        }
        else
        {
            Save3TrackDisplay.GetComponent<TextMeshProUGUI>().text = "Track0" + Save1Track;
            Save3button.SetActive(true);
        }

        if (Save4Track == 0)
        {
            Save4TrackDisplay.GetComponent<TextMeshProUGUI>().text = "None";
            Save4button.SetActive(false);
        }
        else
        {
            Save4TrackDisplay.GetComponent<TextMeshProUGUI>().text = "Track0" + Save1Track;
            Save4button.SetActive(true);
        }


    }
    
}
