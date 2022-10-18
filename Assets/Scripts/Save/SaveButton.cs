using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Car;

public class SaveButton : MonoBehaviour
{
    public GameObject[] TheCar;
    //public GameObject LapCompleteTrigger;

    public GameObject pausePanel;
    public GameObject SavePanel;

    public void SaveGame(ref SaveTactic save)
    {
        
        save.PlayNum = GameSetting.NumofPlayer;
        for(int i = 0; i < 4; i++)
        {
            save.Angle[i, 0] = TheCar[i].GetComponent<Transform>().eulerAngles.x;
            save.Angle[i, 1] = TheCar[i].GetComponent<Transform>().eulerAngles.y;
            save.Angle[i, 2] = TheCar[i].GetComponent<Transform>().eulerAngles.z;
            save.Position[i, 0] = TheCar[i].GetComponent<Transform>().position.x;
            save.Position[i, 1] = TheCar[i].GetComponent<Transform>().position.y;
            save.Position[i, 2] = TheCar[i].GetComponent<Transform>().position.z;
            save.Speed[i, 0] = TheCar[i].GetComponent<Rigidbody>().velocity.x;
            save.Speed[i, 1] = TheCar[i].GetComponent<Rigidbody>().velocity.y;
            save.Speed[i, 2] = TheCar[i].GetComponent<Rigidbody>().velocity.z;

            save.ExtentOfDamage[i] = DamageDisplay.ExtentOfDamage[i];
            save.CollisionNum[i] = DamageDisplay.CollisionNum[i];

            save.CarColor[i] = GameSetting.CarType[i];

            save.ControlMethod[i] = GameSetting.ControlMethod[i];

            save.HalfFlag[i] = HalfPointTrigger.HalfFlag[i];
            save.lapNum[i] = LapComplete.LapCount[i];

            save.steer[i] = CarUserControl.h[i];
            save.accel[i] = CarUserControl.v[i];
            save.footbrake[i] = CarUserControl.v[i];
            save.handbrake[i] = CarUserControl.handbrake[i];
        }

        save.GameMode = GameSetting.RaceMode;
        save.TrackNum = GameSetting.trackNum;
        
        if (save.GameMode == 2)
        {
            save.score[0] = CurrentScore.Score[0];
            save.score[1] = CurrentScore.Score[1];
            save.score[2] = CurrentScore.Score[2];
            save.score[3] = CurrentScore.Score[3];
        }
        else
        {
            save.min = LapTimeManager.MinuteCount;
            save.sec = LapTimeManager.SecondCount;
            save.milli = LapTimeManager.MilliCount;
        }
        //BinaryFormatter binaryFormatter = new BinaryFormatter();
        //FileStream fileStream = File.Create(Application.dataPath + "/Save" +"/Save1.txt");
        //binaryFormatter.Serialize(fileStream, save);
        //fileStream.Close();


    }

    public static void ResaveCondition()
    {
        SaveCondition saveCondition = new SaveCondition
        {
            Save1Track = SaveConditionManager.Save1Track,
            Save2Track = SaveConditionManager.Save2Track,
            Save3Track = SaveConditionManager.Save3Track,
            Save4Track = SaveConditionManager.Save4Track
        };

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.dataPath + "/saveCondition.txt");
        binaryFormatter.Serialize(fileStream, saveCondition);
        fileStream.Close();
    }

    public void Save1()
    {
        SaveTactic save = new SaveTactic();
        SaveGame(ref save);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.dataPath  + "/Save1.txt");
        binaryFormatter.Serialize(fileStream, save);
        fileStream.Close();

        SaveConditionManager.Save1Track = GameSetting.trackNum;
        ResaveCondition();
    }
    public void Save2()
    {
        SaveTactic save = new SaveTactic();
        SaveGame(ref save);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.dataPath +  "/Save2.txt");
        binaryFormatter.Serialize(fileStream, save);
        fileStream.Close();

        SaveConditionManager.Save2Track = GameSetting.trackNum;
        ResaveCondition();
    }
    public void Save3()
    {
        SaveTactic save = new SaveTactic();
        SaveGame(ref save);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.dataPath +  "/Save3.txt");
        binaryFormatter.Serialize(fileStream, save);
        fileStream.Close();

        SaveConditionManager.Save3Track = GameSetting.trackNum;
        ResaveCondition();
    }
    public void Save4()
    {
        SaveTactic save = new SaveTactic();
        SaveGame(ref save);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.dataPath +  "/Save4.txt");
        binaryFormatter.Serialize(fileStream, save);
        fileStream.Close();

        SaveConditionManager.Save4Track = GameSetting.trackNum;
        ResaveCondition();
    }
    public void Back()
    {
        SavePanel.SetActive(false);
        pausePanel.SetActive(true);
    }

}
