/**
 * @file SceneData.cs
 * @brief Define the data types to save for a simulation case.
 * @author Yueyuan Li
 * @date 2023-04-23
 * @copyright GNU Public License
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tactics.Scene
{
    [System.Serializable]
    public class SceneData
    {
        public int ScenarioID;
        public int EvaluationMode;
        public int MapID;
        public int AgentNumber;
        public AgentData[] AgentsData;
    }
}
