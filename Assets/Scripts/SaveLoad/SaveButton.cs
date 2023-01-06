/**
  * @file SaveButton.cs
  * @brief 实现存档功能
  * @details  
  * 挂载该脚本的对象：RaceArea → Canvas → Panel Save → PanelRoll → Panel → Save Savebutton \n
  * 在存档窗口按下Save按钮后，储存本次仿真过程中对车辆输出的所有操作参数，用于在读档时复现。\n
  * 将存档所需的内容储存为一个SaveTactic类对象，并将其转化为二进制文件储存在相应的文件夹中，并修改存档使用情况。
  * @author 李雨航
  * @date 2022-01-06
  */

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
    /// 区分是在暂停界面呼出的存档窗口还是在结束界面呼出的存档窗口
    public static int WhoCalloutSavePanel;
    /// 暂停窗口
    public GameObject pausePanel;
    /// 结算窗口
    public GameObject completePanel;
    /// 存档窗口
    public GameObject SavePanel;
    /**
    * @fn SaveGame
    * @brief 储存游戏，将所需的数据存入save内
    * @param[in] save 引用传递，将存档所需的数据储存在其中
    */
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
        //释放内存
        for (int i = 0; i < 8; i++)
        {
            RecordControllerOutput.steer[i] = null;
            RecordControllerOutput.accel[i] = null;
            RecordControllerOutput.footbrake[i] = null;
            RecordControllerOutput.handbrake[i] = null;
        }
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
    /**
    * @fn ResaveCondition
    * @brief 刷新记录存档使用情况的文件
    */
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

    /**
    * @fn Save1
    * @brief 一号档位的Save按钮
    */
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

    /**
    * @fn Save2
    * @brief 二号档位的Save按钮
    */
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

    /**
    * @fn Save3
    * @brief 三号档位的Save按钮
    */
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

    /**
    * @fn Save4
    * @brief 四号档位的Save按钮
    */
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

    /**
    * @fn Back
    * @brief 关闭存档窗口
    */
    public void Back()
    {
        SavePanel.SetActive(false);
        if (WhoCalloutSavePanel == 1) completePanel.SetActive(true);
        else if (WhoCalloutSavePanel == 2) pausePanel.SetActive(true);
    }

}
