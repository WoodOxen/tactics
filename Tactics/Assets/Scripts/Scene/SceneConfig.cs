/**
 * @file SceneConfig.cs
 * @brief
 * @author Yueyuan Li
 * @date 2023-05-01
 * @copyright GNU Public License
 */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Tactics.Scene
{
    /// @class SceneConfig
    /// @brief This class defines the data types to save for reloading a scene.
    [System.Serializable]
    public class SceneConfig
    {
        public List<string> sceneTypes;
        public int sceneTypeIndex;
        public Dictionary<string, List<string>> evaluationModes;
        public int evaluationModeIndex;
        public Dictionary<string, List<string>> maps;
        public int mapIndex;
        public int agentNumber;

        /// @fn GetSceneConfig
        /// @brief This function detects the scene types, evaluation modes, and maps in the
        /// project and the users' customized folders.
        /// @todo load project-defined scene types, evaluation modes, and maps
        /// @todo load user-defined scene types, evaluation modes, and maps
        public void GetSceneConfig()
        {
            // Get Tactics-defined and user-defined scene types.
            sceneTypes = new List<string>{"Race", "Park", "Highway", "Intersection", "Roundabout"};

            // Get Tactics-defined and user-defined evaluation modes.
            evaluationModes = new Dictionary<string, List<string>>();
            evaluationModes.Add("Race", new List<string>{"Lane Following", "Speed Racing"});

            // Get Tactics-built and user-built maps.
            maps = new Dictionary<string, List<string>>();
            for (int i = 0; i < sceneTypes.Count; i++)
            {
                string sceneType = sceneTypes[i];
                List<string> mapList = new List<string>{"Empty Map"};

                if (maps.ContainsKey(sceneType))
                {
                    maps[sceneType] = mapList;
                }
                else
                {
                    maps.Add(sceneType, mapList);
                }
            }
        }

        /// @fn Save
        /// @brief Save the scene configuration to a file.
        /// @details The file is saved in the persistent data path of the application. If the
        /// file exists, it will be overwritten. Otherwise, a new file will be created.
        public void Save()
        {
            string path = Application.persistentDataPath + "/SceneConfig.dat";
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = (
                File.Exists(path) ?
                new FileStream(path, FileMode.Open) : new FileStream(path, FileMode.Create)
            );

            binaryFormatter.Serialize(fileStream, this);
            fileStream.Close();
        }

        /// @fn Load
        /// @brief Load the scene configuration from a file.
        public void Load()
        {
            string path = Application.persistentDataPath + "/SceneConfig.dat";
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            SceneConfig sceneConfig = binaryFormatter.Deserialize(fileStream) as SceneConfig;
            fileStream.Close();

            sceneTypes = sceneConfig.sceneTypes;
            sceneTypeIndex = sceneConfig.sceneTypeIndex;
            evaluationModes = sceneConfig.evaluationModes;
            evaluationModeIndex = sceneConfig.evaluationModeIndex;
            maps = sceneConfig.maps;
            mapIndex = sceneConfig.mapIndex;
            agentNumber = sceneConfig.agentNumber;
        }
    }
}
