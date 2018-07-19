using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseGame : UIPanel
{
    public UIStatsPanel StatsPanel;

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

    public void ShowStatsPanel()
    {
        HidePanel();
        StatsPanel.ShowPanel(this);
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
