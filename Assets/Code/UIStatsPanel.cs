using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatsPanel : UIPanel
{
    public Text HighScoreText, StatsText;

    private UIPanel PrvePanel;

    public void ShowPanel(UIPanel prevPanel)
    {
        base.ShowPanel();

        PrvePanel = prevPanel;

        HighScoreText.text = string.Format("GAME {0}: {1}\nGAME {2}: {3}\nGAME {4}: {5}\n",
            GameData.l_HighScores[0].First, GameData.l_HighScores[0].Second,
            GameData.l_HighScores[1].First, GameData.l_HighScores[1].Second,
            GameData.l_HighScores[2].First, GameData.l_HighScores[2].Second);

        StatsText.text = string.Format("TOTAL EGGS: {0}\nTOTAL BOUNCES: {1}",
            GameData.k_EggsAllTime + GameData.k_Eggs, 
            GameData.k_BouncesAllTime + GameData.k_Bounces);
    }

    public new void HidePanel()
    {
        base.HidePanel();
        PrvePanel.ShowPanel();
    }
}
