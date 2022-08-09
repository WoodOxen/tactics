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

            save.CarColor[i] = GameSetting.CarType[i];

            save.ControlMethod[i] = GameSetting.ControlMethod[i];
        }

        save.GameMode = GameSetting.RaceMode;
        save.TrackNum = GameSetting.trackNum;

        save.steer[0] = CarUserControl.h;
        save.accel[0] = CarUserControl.v;
        save.footbrake[0] = CarUserControl.v;
        save.handbrake[0] = CarUserControl.handbrake;
        save.steer[1] = CarUserControl2.h;
        save.accel[1] = CarUserControl2.v;
        save.footbrake[1] = CarUserControl2.v;
        save.handbrake[1] = CarUserControl2.handbrake;
        save.steer[2] = CarUserControl3.h;
        save.accel[2] = CarUserControl3.v;
        save.footbrake[2] = CarUserControl3.v;
        save.handbrake[2] = CarUserControl3.handbrake;
        save.steer[3] = CarUserControl4.h;
        save.accel[3] = CarUserControl4.v;
        save.footbrake[3] = CarUserControl4.v;
        save.handbrake[3] = CarUserControl4.handbrake;

        save.HalfFlag[0] = HalfPointTrigger.HalfFlag1;
        save.HalfFlag[1] = HalfPointTrigger.HalfFlag2;
        save.HalfFlag[2] = HalfPointTrigger.HalfFlag3;
        save.HalfFlag[3] = HalfPointTrigger.HalfFlag4;

        save.lapNum[0] = LapComplete.LapCount1;
        save.lapNum[1] = LapComplete.LapCount2;
        save.lapNum[2] = LapComplete.LapCount3;
        save.lapNum[3] = LapComplete.LapCount4;

        save.ExtentOfDamage[0] = DamageDisplay1.ExtentOfDamage;
        save.CollisionNum[0] = DamageDisplay1.CollisionNum;
        save.ExtentOfDamage[1] = DamageDisplay2.ExtentOfDamage;
        save.CollisionNum[1] = DamageDisplay2.CollisionNum;
        save.ExtentOfDamage[2] = DamageDisplay3.ExtentOfDamage;
        save.CollisionNum[2] = DamageDisplay3.CollisionNum;
        save.ExtentOfDamage[3] = DamageDisplay4.ExtentOfDamage;
        save.CollisionNum[3] = DamageDisplay4.CollisionNum;
        
        if (save.GameMode == 2)
        {
            save.score[0] = GameModeManager.CurrentScore1;
            save.score[1] = GameModeManager.CurrentScore2;
            save.score[2] = GameModeManager.CurrentScore3;
            save.score[3] = GameModeManager.CurrentScore4;
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
