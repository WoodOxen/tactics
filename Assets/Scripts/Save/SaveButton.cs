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

    public static int WhoCalloutSavePanel;
    public GameObject pausePanel;
    public GameObject completePanel;
    public GameObject SavePanel;

    public void SaveGame(ref SaveTactic save)
    {
        
        save.PlayNum = GameSetting.NumofPlayer;

        int length = RecordControllerOutput.steer[0].Count;
        save.steer = new float[GameSetting.NumofPlayer, length];
        save.accel = new float[GameSetting.NumofPlayer, length];
        save.footbrake = new float[GameSetting.NumofPlayer, length];
        save.handbrake = new float[GameSetting.NumofPlayer, length];
        save.count = length;

        save.CarColor = new int[GameSetting.NumofPlayer];
        save.ControlMethod = new int[GameSetting.NumofPlayer];

        for (int i = 0; i < GameSetting.NumofPlayer; i++)
        {
            save.CarColor[i] = GameSetting.CarType[i];
            save.ControlMethod[i] = GameSetting.ControlMethod[i];

            float[] steer_tmp = (float[])RecordControllerOutput.steer[i].ToArray(typeof(float));
            float[] accel_tmp = (float[])RecordControllerOutput.accel[i].ToArray(typeof(float));
            float[] footbrake_tmp = (float[])RecordControllerOutput.footbrake[i].ToArray(typeof(float));
            float[] handbrake_tmp = (float[])RecordControllerOutput.handbrake[i].ToArray(typeof(float));
            for (int j = 0; j < length; j++)
            {
                save.steer[i,j] = steer_tmp[j];
                save.accel[i,j] = accel_tmp[j];
                save.footbrake[i,j] = footbrake_tmp[j];
                save.handbrake[i,j] = handbrake_tmp[j];
            }

            //历史残留代码
            //存档功能由“在仿真中途存档，读档后从该状态继续运行”改为“读档时复现存档中的仿真内容”
            //因此下列代码暂时废弃
            //save.Angle[i, 0] = TheCar[i].GetComponent<Transform>().eulerAngles.x;
            //save.Angle[i, 1] = TheCar[i].GetComponent<Transform>().eulerAngles.y;
            //save.Angle[i, 2] = TheCar[i].GetComponent<Transform>().eulerAngles.z;
            //save.Position[i, 0] = TheCar[i].GetComponent<Transform>().position.x;
            //save.Position[i, 1] = TheCar[i].GetComponent<Transform>().position.y;
            //save.Position[i, 2] = TheCar[i].GetComponent<Transform>().position.z;
            //save.Speed[i, 0] = TheCar[i].GetComponent<Rigidbody>().velocity.x;
            //save.Speed[i, 1] = TheCar[i].GetComponent<Rigidbody>().velocity.y;
            //save.Speed[i, 2] = TheCar[i].GetComponent<Rigidbody>().velocity.z;
            //save.ExtentOfDamage[i] = DamageDisplay.ExtentOfDamage[i];
            //save.CollisionNum[i] = DamageDisplay.CollisionNum[i];

            //save.HalfFlag[i] = HalfPointTrigger.HalfFlag[i];
            //save.lapNum[i] = LapComplete.LapCount[i];
        }

        save.GameMode = GameSetting.RaceMode;
        save.TrackNum = GameSetting.trackNum;
        
        /*
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
        */
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
        if (WhoCalloutSavePanel == 1) completePanel.SetActive(true);
        else if (WhoCalloutSavePanel == 2) pausePanel.SetActive(true);
    }

}
