using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public Button PauseButton;
    public Countdown CountdownTimer;

    public void Start()
    {
        HidePanel(true);
    }

    public void ShowPanel()
    {
        Time.timeScale = 0;
        PauseButton.interactable = false;

        this.GetComponent<CanvasGroup>().alpha = 1;
        this.GetComponent<CanvasGroup>().interactable = true;
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void HidePanel()
    {
        HidePanel(false);
    }

    public void HidePanel(bool hideTimer)
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().interactable = false;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;

        if (CountdownTimer != null && hideTimer == false)
        {
            StartCoroutine(CountdownTimer.StartCountdown(PauseButton));
        }
        else
        {
            Time.timeScale = 1;
            PauseButton.interactable = true;
        }
    }
}
