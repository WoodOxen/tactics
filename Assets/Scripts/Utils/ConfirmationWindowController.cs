using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationWindowController : MonoBehaviour
{
    [SerializeField] private ConfirmationWindow myConfirmationWindow;

    void Start()
    {
        OpenConfirmationWindow("Are you sure to exit the game?");
    }

    private void OpenConfirmationWindow(string message)
    {
        myConfirmationWindow.gameObject.SetActive(true);
        myConfirmationWindow.yesButton.onClick.AddListener(YesClicked);
        myConfirmationWindow.noButton.onClick.AddListener(NoClicked);
        myConfirmationWindow.messageText.text = message;
    }

    private void YesClicked()
    {
        myConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("Yes clicked.");
    }

    private void NoClicked()
    {
        myConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("No clicked.");
    }
}