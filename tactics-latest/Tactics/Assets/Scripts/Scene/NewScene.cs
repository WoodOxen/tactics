/**
 * @file NewScene.cs
 * @brief
 * @author Yueyuan Li
 * @author Yuhang Li
 * @date 2023-05-01
 * @copyright GNU Public License
 */

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tactics.Scene
{
    /// @class NewScene
    /// @brief This class defines the functions to setup a new scene.
    public class NewScene : MonoBehaviour
    {
        [SerializeField] private TMP_Text sceneTypeLabel;
        [SerializeField] private TMP_Text evaluationModeLabel;
        [SerializeField] private TMP_Dropdown mapDropdown;
        [SerializeField] private Slider agentNumberSlider;
        private List<string> _sceneTypes;
        private int _sceneTypeIndex = 0;
        private Dictionary<string, List<string>> _evaluationModes;
        private int _evaluationModeIndex = 0;
        private Dictionary<string, List<string>> _maps;
        private int _mapIndex = 0;
        private int _agentNumber = 1;
        private SceneConfig _sceneConfig = new SceneConfig();

        void Start()
        {
            string sceneConfigPath = Application.persistentDataPath + "/SceneConfig.dat";
            if (File.Exists(sceneConfigPath))
            {
                _sceneConfig.Load();
                _sceneTypeIndex = _sceneConfig.sceneTypeIndex;
                _evaluationModeIndex = _sceneConfig.evaluationModeIndex;
                _mapIndex = _sceneConfig.mapIndex;
                _agentNumber = _sceneConfig.agentNumber;
            }
            else
            {
                _sceneConfig.GetSceneConfig();
            }

            _sceneTypes = _sceneConfig.sceneTypes;
            _evaluationModes = _sceneConfig.evaluationModes;
            _maps = _sceneConfig.maps;

            UpdateSceneTypeLabel();
            UpdateEvaluationModeLabel();
            UpdateMapOption();
        }

        /// @fn SwitchScenario
        /// @brief Switch the scene type to the next or previous one.
        /// @param switchDirection 1 for next, -1 for previous.
        /// @details The evaluation mode will be reset to the first one once the scene type is
        /// switched.
        public void SwitchSceneType(int switchDirection)
        {
            _sceneTypeIndex += switchDirection;

            if (_sceneTypeIndex < 0)
            {
                _sceneTypeIndex = _sceneTypes.Count - 1;
            }
            else if (_sceneTypeIndex >= _sceneTypes.Count)
            {
                _sceneTypeIndex = 0;
            }

            UpdateSceneTypeLabel();
            UpdateEvaluationModeLabel();
        }

        /// @fn UpdateSceneTypeLabel
        /// @brief Update the scene type label.
        private void UpdateSceneTypeLabel()
        {
            sceneTypeLabel.text = _sceneTypes[_sceneTypeIndex];
        }

        /// @fn SwitchEvaluationMode
        /// @brief Switch the evaluation mode to the next or previous one.
        public void SwitchEvaluationMode(int switchDirection)
        {
            if (!_evaluationModes.ContainsKey(_sceneTypes[_sceneTypeIndex]))
            {
                return;
            }

            List<string> evaluationModes = _evaluationModes[_sceneTypes[_sceneTypeIndex]];

            _evaluationModeIndex += switchDirection ;

            if (_evaluationModeIndex < 0)
            {
                _evaluationModeIndex = evaluationModes.Count - 1;
            }
            else if (_evaluationModeIndex >= evaluationModes.Count)
            {
                _evaluationModeIndex = 0;
            }

            UpdateEvaluationModeLabel();
        }

        /// @fn UpdateEvaluationModeLabel
        /// @brief Update the evaluation mode label.
        private void UpdateEvaluationModeLabel()
        {
            if (_evaluationModes.ContainsKey(_sceneTypes[_sceneTypeIndex]))
            {
                List<string> evaluationModes = _evaluationModes[_sceneTypes[_sceneTypeIndex]];
                evaluationModeLabel.text = evaluationModes[_evaluationModeIndex];
            }
            else
            {
                evaluationModeLabel.text = "Null";
            }
        }

        /// @fn UpdateMapOption
        /// @brief Update the map options in the dropdown menu based on the scene type.
        private void UpdateMapOption()
        {
            List<string> maps = _maps[_sceneTypes[_sceneTypeIndex]];

            mapDropdown.ClearOptions();
            mapDropdown.AddOptions(maps);
        }

        /// @fn GetMapOption
        /// @brief Record the selected map index.
        /// @details The index is temporarily recorded. It will only be saved when the user
        /// confirms the scene configuration.
        public void GetMapOption()
        {
            _mapIndex = (int) mapDropdown.value;
        }

        /// @fn GetAgentNumber
        /// @brief Get the number of agent from the slider.
        /// @details The number is temporarily recorded. It will only be saved when the user
        /// confirms the scene configuration.
        public void GetAgentNumber()
        {
            _agentNumber = (int) agentNumberSlider.value;
        }

        /// @fn ConfirmSceneConfiguration
        /// @brief Save the scene configuration to the SceneConfig object.
        public void ConfirmSceneConfiguration()
        { 
            _sceneConfig.sceneTypeIndex = _sceneTypeIndex;
            _sceneConfig.evaluationModeIndex = _evaluationModeIndex;
            _sceneConfig.mapIndex = _mapIndex;
            _sceneConfig.agentNumber = _agentNumber;

            _sceneConfig.Save();
        }
    }
}
