/**
 * @file ControlSetting.cs
 * @brief This scrips allows the user to custom the control settings of the game.
 * @author Yueyuan Li
 * @date 2023-04-27
 * @copyright GNU Public License
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Tactics.Settings{
    public class ControlSetting : MonoBehaviour
    {
        [SerializeField] private TMP_Text inputSourceLabel;
        private string[] _inputSources = {"Keyboard and mouse", "Joystick"};
        private int _inputSourceIndex = 0;

        void Start()
        {
            UpdateInputSourceLabel();
        }

        public void SwitchInput(int switchDirection)
        {
            _inputSourceIndex += switchDirection;

            if (_inputSourceIndex < 0)
            {
                _inputSourceIndex = _inputSources.Length - 1;
            }
            else if (_inputSourceIndex >= _inputSources.Length)
            {
                _inputSourceIndex = 0;
            }

            UpdateInputSourceLabel();
        }

        private void UpdateInputSourceLabel ()
        {
            inputSourceLabel.text = _inputSources[_inputSourceIndex];
        }
    }
}
