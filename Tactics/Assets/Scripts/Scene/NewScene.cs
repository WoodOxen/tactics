/**
 * @file NewScene.cs
 * @brief
 * @author Yueyuan Li
 * @date 2023-04-23
 * @copyright GNU Public License
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tactics.Scene
{
    public class NewScene : MonoBehaviour
    {
        [SerializeField] private TMP_Text scenarioLabel;
        [SerializeField] private TMP_Text evaluationModeLabel;
        [SerializeField] private Slider agentNumberSlider;
        private string[] _scenarios = {"Racing", "Parking", "Highway", "Intersection", "Roundabout", "Custom"};
        private int _scenarioIndex = 0;
        private string[] _evaluationMode;
        private int _evaluationModeIndex = 0;
        private int _agentNumber = 1;
        private List<AgentData> _agentsData = new List<AgentData>();

        void Start()
        {
            UpdateScenarioLabel();
            GetEvaluationMode();
            UpdateEvaluationModeLabel();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        /// @fn SwitchScenario
        /// @brief Switch the scenario to the next or previous one.
        /// @param switchDirection 1 for next, -1 for previous.
        /// @details The evaluation mode will be reset to the first one once the scenario is
        /// switched.
        public void SwitchScenario(int switchDirection)
        {
            _scenarioIndex += switchDirection;
            if (_scenarioIndex < 0)
            {
                _scenarioIndex = _scenarios.Length - 1;
            }
            else if (_scenarioIndex >= _scenarios.Length)
            {
                _scenarioIndex = 0;
            }
            UpdateScenarioLabel();
            GetEvaluationMode();
            UpdateEvaluationModeLabel();
        }

        /// @fn UpdateScenarioLabel
        /// @brief Update the scenario label.
        private void UpdateScenarioLabel()
        {
            scenarioLabel.text = _scenarios[_scenarioIndex];
        }

        /// @fn GetEvaluationMode
        /// @brief Update the evaluation mode array based on the scenario.
        /// @todo Add more evaluation modes.
        /// @todo Allow auto detect of custom evaluation modes.
        private void GetEvaluationMode()
        {
            switch (_scenarioIndex)
            {
                case 0:
                    _evaluationMode = new string[2] {"Lane following", "Speed racing"};
                    break;
                default:
                    _evaluationMode = new string[] {};
                    break;
            }
            _evaluationModeIndex = 0;
        }

        /// @fn SwitchEvaluationMode
        /// @brief Switch the evaluation mode to the next or previous one.
        public void SwitchEvaluationMode(int switchDirection)
        {
            if (_evaluationMode.Length == 0) return;

            _evaluationModeIndex += switchDirection ;

            if (_evaluationModeIndex < 0)
            {
                _evaluationModeIndex = _evaluationMode.Length - 1;
            }
            else if (_evaluationModeIndex >= _evaluationMode.Length)
            {
                _evaluationModeIndex = 0;
            }

            UpdateEvaluationModeLabel();
        }

        /// @fn UpdateEvaluationModeLabel
        /// @brief Update the evaluation mode label.
        private void UpdateEvaluationModeLabel()
        {
            if (_evaluationMode.Length == 0)
            {
                evaluationModeLabel.text = "Null";
            }
            else
            {
                evaluationModeLabel.text = _evaluationMode[_evaluationModeIndex];
            }
        }

        /// @fn GetAgentNumber
        /// @brief Get the number of agent from the slider.
        public void GetAgentNumber()
        {
            _agentNumber = (int) agentNumberSlider.value;
        }

        public void ConfirmSceneConfiguration()
        {

        }

        public void SkipSceneConfiguration()
        {
            
        }
    }
}
