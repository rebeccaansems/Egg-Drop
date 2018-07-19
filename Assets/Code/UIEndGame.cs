using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIEndGame : UIPanel
{
    public Text FinalGameScoreText, MoreGameDataText;
    public UIStatsPanel StatsPanel;

    public new void ShowPanel()
    {
        base.ShowPanel();

        FinalGameScoreText.text = GameData.k_Score.ToString();
        MoreGameDataText.text = string.Format("EGGS: {0}\nBOUNCES: {1}", GameData.k_Eggs, GameData.k_Bounces);
    }

    public void RestartGame()
    {
        PlayerPrefs.SetInt("GameData", GameData.k_GameNumber);
        PlayerPrefs.SetInt("Eggs", GameData.k_EggsAllTime + GameData.k_Eggs);
        PlayerPrefs.SetInt("Bounces", GameData.k_BouncesAllTime + GameData.k_Bounces);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        GameData.k_GameNumber += 1;
    }

    public void ShareTwitter()
    {
        Debug.Log("SHARE");
    }

    public void ShowStatsPanel()
    {
        StatsPanel.ShowPanel(this);
        HidePanel();
    }
}
