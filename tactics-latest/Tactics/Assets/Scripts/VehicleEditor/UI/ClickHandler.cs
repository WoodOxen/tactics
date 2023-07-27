using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

class ClickHandler : MonoBehaviour
{
    private float Scale = 0.3f;

    private double lastKickTime;

    [Serializable]
    /// <summary>
    /// Function definition for a double click event.
    /// </summary>
    public class ButtonDoubleClickedEvent : UnityEvent { }

    // Event delegates triggered on click.
    [SerializeField]
    private ButtonDoubleClickedEvent m_OnDoubleClick = new ButtonDoubleClickedEvent();
    [SerializeField]
    private ButtonDoubleClickedEvent m_OnSingleClick = new ButtonDoubleClickedEvent();

    public void DetectClick()
    {
        if (Time.realtimeSinceStartup - lastKickTime < Scale)
        {
            m_OnDoubleClick.Invoke();
        }
        else
        {
            m_OnSingleClick.Invoke();
        }

        lastKickTime = Time.realtimeSinceStartup;//重新设置上次点击的时间
    }

    void Start()
    {
        lastKickTime = Time.realtimeSinceStartup;
    }

    void Update()
    {

    }
}   
