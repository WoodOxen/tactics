/**
 * @file SaveSystem.cs
 * @brief The save-and-load system of Tactics.
 * @author Yueyuan Li
 * @author Yuhang Li
 * @date 2023-04-23
 */

using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/**
 */
public static class SaveSystem
{
    /**
     * @fn GetTimeStamp
     * @brief Get the current time as a string in the format of "yyyy-MM-dd-HH-mm-ss".
     */
    private static string GetTimeStamp()
    {
        return System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
    }

    /**
     * @fn FindSavedFiles
     * @brief Find all the saved game files in the GameSave folder.
     * @return An array of file names. If the GameSave folder does not exist, return null.
     */
    private static string[] FindSavedFiles ()
    {
        string path = Application.dataPath + "/GameSave/";
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

    /**
     * @fn DeleteSavedFile
     * @brief Delete a saved game file.
     * @param fileName The name of the file to be deleted.
     * @details If the file does not exist, a warning will be printed.
     */
    private static void DeleteSavedFile (string fileName)
    {
        string path = Application.dataPath + "/GameSave/" + fileName + ".bin";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Debug.LogWarning(fileName + " is not deleted because it does not exist.");
        }
    }

    /**
     * @fn AutoControlFileNumber
     * @brief Automatically control the number of saved game files based on the 
     * MaxFileNumber property in PlayerPrefs.
     * @details When the number of saved game files is larger than the MaxFileNumber,
     * the earlier game files will be automatically deleted. If the MaxFileNumber is undefined
     * or invalid, the auto deletion will not be performed.
     */
    private static void AutoControlFileNumber ()
    {
        if (PlayerPrefs.HasKey("MaxFileNumber") && PlayerPrefs.GetInt("MaxFileNumber") > 0)
        {
            int maxFileNumber = PlayerPrefs.GetInt("MaxFileNumber");
            string[] files = FindSavedFiles();

            if (files.Length > maxFileNumber)
            {
                // Sort the files by their creation time.
                DateTime[] createTimes = new DateTime[files.Length];
                string path = Application.dataPath + "/GameSave/";
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
     * @fn SaveGame
     * @brief Save a game.
     * @param game The game to be saved.
     * @param fileName The name of the file to be saved. If it is null, the file name will be the current time.
     */
    public static void SaveGame (Game game, string fileName = null)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.dataPath;
        FileStream fileStream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(game);

        if (fileName == null)
        {
            path += "/GameSave/" + GetTimeStamp() + ".bin";
        }
        else
        {
            path += "/GameSave/" + fileName + ".bin";
        }

        binaryFormatter.Serialize(fileStream, gameData);
        fileStream.Close();
        AutoControlFileNumber();
    }

    /**
     * @fn LoadGame
     * @brief Load a game.
     * @param fileName The name of the file to be loaded.
     * @return The loaded game. If the file does not exist, return null and print a warning.
     */
    public static GameData LoadGame (string fileName)
    {
        string path = Application.dataPath + "/GameSave/" + fileName + ".bin";

        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            GameData gameData = binaryFormatter.Deserialize(fileStream) as GameData;
            fileStream.Close();

            return gameData;
        }
        else
        {
            Debug.LogWarning("Save file not found in " + path);
            return null;
        }
    }
}