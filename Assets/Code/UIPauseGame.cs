using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseGame : MonoBehaviour {

    public void Start()
    {
        HidePanel();
    }

    public void ShowPanel()
    {
        this.GetComponent<CanvasGroup>().alpha = 1;
        this.GetComponent<CanvasGroup>().interactable = true;
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void HidePanel()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().interactable = false;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void PauseGame()
    {
        ShowPanel();
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        HidePanel();
        Time.timeScale = 1;
    }

    public void ShareTwitter()
    {
        Debug.Log("SHARE");
    }

    public void ShowHighScorePanel()
    {
        Debug.Log("HIGHSCORE");
    }

    public void ChangeSFXVolume(float volume)
    {
        Debug.Log(volume);
    }

    public void ChangeMusicVolume(float volume)
    {
        Debug.Log(volume);
    }
}
