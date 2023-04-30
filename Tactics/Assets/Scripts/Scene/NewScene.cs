/**
 * @file NewScene.cs
 * @brief
 * @author Yueyuan Li
 * @date 2023-04-23
 * @copyright GNU Public License
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewScene : MonoBehaviour
{
    [HideInInspector] public Scene scene;
    [SerializeField] private TMP_Text scenarioLabel;
    [SerializeField] private TMP_Text evaluationModeLabel;
    private string[] scenarios = {"Racing", "Parking", "Highway", "Intersection", "Roundabout", "Custom"};
    private int scenarioIndex = 0;
    private string[] evaluationMode;
    private int evaluationModeIndex = 0;
    private int agentNumber = 0;

    void Start()
    {
        UpdateScenarioLabel();
        UpdateEvaluationMode();
        UpdateEvaluationModeLabel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchScenario(int switchDirection)
    {
        scenarioIndex += switchDirection;
        if (scenarioIndex < 0)
        {
            scenarioIndex = scenarios.Length - 1;
        }
        else if (scenarioIndex >= scenarios.Length)
        {
            scenarioIndex = 0;
        }
        UpdateScenarioLabel();
        UpdateEvaluationMode();
        UpdateEvaluationModeLabel();
    }

    private void UpdateScenarioLabel()
    {
        scenarioLabel.text = scenarios[scenarioIndex];
    }

    private void UpdateEvaluationMode()
    {
        switch (scenarioIndex)
        {
            case 0:
                evaluationMode = new string[2] {"Lane following", "Speed racing"};
                break;
            default:
                evaluationMode = new string[] {};
                break;
        }
        evaluationModeIndex = 0;
    }

    public void SwitchEvaluationMode (int switchDirection)
    {
        if (evaluationMode.Length == 0) return;

        evaluationModeIndex += switchDirection ;

        if (evaluationModeIndex < 0)
        {
            evaluationModeIndex = evaluationMode.Length - 1;
        }
        else if (evaluationModeIndex >= evaluationMode.Length)
        {
            evaluationModeIndex = 0;
        }

        UpdateEvaluationModeLabel();
    }

    private void UpdateEvaluationModeLabel ()
    {
        if (evaluationMode.Length == 0)
        {
            evaluationModeLabel.text = "Null";
        }
        else
        {
            evaluationModeLabel.text = evaluationMode[evaluationModeIndex];
        }
    }

    public void ConfirmScene ()
    {
        scene.ScenarioID = scenarioIndex;
        scene.EvaluationMode = evaluationModeIndex;
    }

}
