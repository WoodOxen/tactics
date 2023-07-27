using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSlider : MonoBehaviour
{
    public float SlideDist = 800;
    [Tooltip("false:hide, true:display")]
    public bool DefaultState = true;
    [Tooltip("false:left, true:right")]
    public bool SlideDirection = false;

    private bool _state;
    private TMPro.TextMeshProUGUI _arrow;
    private Vector3 _displayPos;
    private Vector3 _hiddenPos;
    

    public void ToggleHidden()
    {
        _state = !_state;
        if (_state != SlideDirection)
        {
            _arrow.text = "<";
        }
        else
        {
            _arrow.text = ">";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _arrow = transform.Find("Hidder").Find("Text (TMP)").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        _state = DefaultState;

        _hiddenPos = transform.localPosition + Vector3.right * SlideDist * (SlideDirection?1:-1);
        _displayPos = transform.localPosition;

        if (!DefaultState)
        {
            transform.localPosition += Vector3.left*SlideDist;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, (_state ? _displayPos : _hiddenPos), 0.1f);
    }
}
