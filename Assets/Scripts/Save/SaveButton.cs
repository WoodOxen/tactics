using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Car;

public class SaveButton : MonoBehaviour
{
    public GameObject TheCar;
    public GameObject LapCompleteTrigger;

    public GameObject pausePanel;
    public GameObject SavePanel;

    public void SaveGame(ref SaveTactic save)
    {
        save.AngleX = TheCar.GetComponent<Transform>().eulerAngles.x;
        save.AngleY = TheCar.GetComponent<Transform>().eulerAngles.y;
        save.AngleZ = TheCar.GetComponent<Transform>().eulerAngles.z;
        save.PositionX = TheCar.GetComponent<Transform>().position.x;
        save.PositionY = TheCar.GetComponent<Transform>().position.y;
        save.PositionZ = TheCar.GetComponent<Transform>().position.z;
        save.SpeedX = TheCar.GetComponent<Rigidbody>().velocity.x;
        save.SpeedY = TheCar.GetComponent<Rigidbody>().velocity.y;
        save.SpeedZ = TheCar.GetComponent<Rigidbody>().velocity.z;
        save.CarColor = GameSetting.CarType;
        save.GameMode = GameSetting.RaceMode;
        save.TrackNum = GameSetting.trackNum;
        save.steer = CarUserControl.h;
        save.accel = CarUserControl.v;
        save.footbrake = CarUserControl.v;
        save.handbrake = CarUserControl.handbrake;
        save.HalfFlag = LapCompleteTrigger.activeSelf;
        save.lapNum = LapComplete.LapCount;
        save.ExtentOfDamage = DamageDisplay.ExtentOfDamage;
        save.CollisionNum = DamageDisplay.CollisionNum;
        save.ControlMethod = GameSetting.ControlMethod;
        
        if (save.GameMode == 2)
        {
            save.score = GameModeManager.CurrentScore;
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
