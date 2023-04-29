/**
 * @file SaveSystem.cs
 * @brief The save-and-load system of Tactics.
 * @author Yueyuan Li
 * @author Yuhang Li
 * @date 2023-04-23
 * @copyright GNU Public License
 */

using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoadSystem
{
    /// @fn GetTimeStamp
    /// @brief Get the current time as a string in the format of "yyyy-MM-dd-HH-mm-ss".
    private static string GetTimeStamp()
    {
        return System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
    }

    /// @fn FindSavedFiles
    /// @brief Find all the saved scene files in the SceneSave folder.
    /// @return An array of file names. If the SceneSave folder does not exist, return null.
    private static string[] FindSavedFiles ()
    {
        string path = Application.dataPath + "/SceneSave/";

        if (Directory.Exists(path))
        {
            string[] files = Directory.GetFiles(path, "*.bin");
            return files;
        }
        else
        {
            return null;
        }
    }

    /// @fn DeleteSavedFile
    /// @brief Delete a saved file.
    /// @param fileName The name of the file to be deleted.
    /// @details If the file does not exist, a warning will be printed.
    private static void DeleteSavedFile (string fileName)
    {
        string path = Application.dataPath + "/SceneSave/" + fileName + ".bin";

        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Debug.LogWarning(fileName + " is not deleted because it does not exist.");
        }
    }

    /// @fn ControlFileNumber
    /// @brief Automatically control the number of saved files based on the 
    /// MaxFileNumber property in PlayerPrefs.
    /// @details When the number of saved files is larger than the MaxFileNumber,
    /// the earlier files will be automatically deleted. If the MaxFileNumber is 
    /// undefined or invalid, the auto deletion will not be performed.
    private static void ControlFileNumber ()
    {
        if (PlayerPrefs.HasKey("MaxFileNumber") && PlayerPrefs.GetInt("MaxFileNumber") > 0)
        {
            int maxFileNumber = PlayerPrefs.GetInt("MaxFileNumber");
            string[] files = FindSavedFiles();

            if (files.Length > maxFileNumber)
            {
                // Sort the files by their creation time.
                DateTime[] createTimes = new DateTime[files.Length];
                string path = Application.dataPath + "/SceneSave/";
                for (int i = 0; i < files.Length; i++)
                {
                    createTimes[i] = new FileInfo(path + files[i]).CreationTime;
                }
                Array.Sort(files, createTimes);

                // Delete the earlier files.
                for (int i = 0; i < files.Length - maxFileNumber; i++)
                {
                    DeleteSavedFile(files[i]);
                }
            }
        }
    }

    /**
     * @fn SaveScene
     * @brief Save a scene.
     * @param scene The scene to be saved.
     * @param fileName The name of the file to be saved. If it is null, the file name will be the current time.
     */
    public static void SaveScene (Scene scene, string fileName = null)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.dataPath;
        FileStream fileStream = new FileStream(path, FileMode.Create);

        SceneData sceneData = new SceneData(scene);

        if (fileName == null)
        {
            path += "/SceneSave/" + GetTimeStamp() + ".bin";
        }
        else
        {
            path += "/SceneSave/" + fileName + ".bin";
        }

        binaryFormatter.Serialize(fileStream, sceneData);
        fileStream.Close();
        ControlFileNumber();
    }

    /**
     * @fn LoadScene
     * @brief Load a scene.
     * @param fileName The name of the file to be loaded.
     * @return The loaded scene. If the file does not exist, return null and print a warning.
     */
    public static SceneData LoadScene (string fileName)
    {
        string path = Application.dataPath + "/SceneSave/" + fileName + ".bin";

        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            SceneData sceneData = binaryFormatter.Deserialize(fileStream) as SceneData;
            fileStream.Close();

            return sceneData;
        }
        else
        {
            Debug.LogWarning("Save file not found in " + path);
            return null;
        }
    }
}