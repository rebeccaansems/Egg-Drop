using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class UIEndGame : UIPanel
{
    public Text FinalGameScoreText, MoreGameDataText;
    public UIStatsPanel StatsPanel;

    public new void ShowPanel()
    {
        if (GameData.k_ScoresUpdated == false)
        {
            base.ShowPanel();

            if (GameData.k_GameInSessionNumber % 4 == 0 && GameData.k_GameInSessionNumber != 0)
            {
                Advertisement.Show();
            }

            UpdateGameStats();
            this.GetComponent<PlayAudio>().PlayRandom(0, 3);

            FinalGameScoreText.text = GameData.k_Score.ToString();
            if (IsHighscore())
            {
                FinalGameScoreText.text = "~" + FinalGameScoreText.text + "~";
            }

            MoreGameDataText.text = string.Format("EGGS: {0}\nBOUNCES: {1}", GameData.k_Eggs, GameData.k_Bounces);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowStatsPanel()
    {
        HidePanel(true);
        StatsPanel.ShowPanel(this);
    }

    private void UpdateGameStats()
    {
        GameData.k_ScoresUpdated = true;
        GameData.k_GameNumber += 1;
        GameData.k_GameInSessionNumber += 1;

        PlayerPrefs.SetInt("GameNumber", GameData.k_GameNumber);
        PlayerPrefs.SetInt("Eggs", GameData.k_EggsAllTime + GameData.k_Eggs);
        PlayerPrefs.SetInt("Bounces", GameData.k_BouncesAllTime + GameData.k_Bounces);

        GameData.l_HighScores.Add(new Tuple<int, int>(GameData.k_GameNumber, GameData.k_Score));
        GameData.l_HighScores.Sort((x, y) => y.Second.CompareTo(x.Second));
        GameData.l_HighScores.RemoveAt(3);

        PlayerPrefs.SetInt("Highscore_Date0", GameData.l_HighScores[0].First);
        PlayerPrefs.SetInt("Highscore_Date1", GameData.l_HighScores[1].First);
        PlayerPrefs.SetInt("Highscore_Date2", GameData.l_HighScores[2].First);

        PlayerPrefs.SetInt("Highscore_Score0", GameData.l_HighScores[0].Second);
        PlayerPrefs.SetInt("Highscore_Score1", GameData.l_HighScores[1].Second);
        PlayerPrefs.SetInt("Highscore_Score2", GameData.l_HighScores[2].Second);
    }

    private bool IsHighscore()
    {
        return GameData.l_HighScores.Count(x => x.First == GameData.k_GameNumber) == 1;
    }
}
