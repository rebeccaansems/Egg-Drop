using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    public static List<Tuple<int, int>> l_HighScores;

    public static List<GameObject> l_AllEggs;

    public static int k_Score, k_Bounces, k_Eggs, k_GameNumber;
    public static int k_EggsAllTime, k_BouncesAllTime;
    public static bool k_GameRunning = true, k_ScoresUpdated;

    public GameObject EndGamePanel;
    public Text ScoreText;

    void Start()
    {
        k_ScoresUpdated = false;
        k_Score = 0;
        k_Bounces = 0;
        k_Eggs = 0;
        k_GameNumber = PlayerPrefs.GetInt("GameNumber", 1);
        k_BouncesAllTime = PlayerPrefs.GetInt("Bounces", 0);
        k_EggsAllTime = PlayerPrefs.GetInt("Eggs", 0);
        l_AllEggs = new List<GameObject>();

        l_HighScores = new List<Tuple<int, int>>();
        l_HighScores.Add(new Tuple<int, int>(PlayerPrefs.GetInt("Highscore_Date0", 0), PlayerPrefs.GetInt("Highscore_Score0", 0)));
        l_HighScores.Add(new Tuple<int, int>(PlayerPrefs.GetInt("Highscore_Date1", 0), PlayerPrefs.GetInt("Highscore_Score1", 0)));
        l_HighScores.Add(new Tuple<int, int>(PlayerPrefs.GetInt("Highscore_Date2", 0), PlayerPrefs.GetInt("Highscore_Score2", 0)));

        Time.timeScale = 1;

        PlayerPrefs.Save();
    }

    void Update()
    {
        if (k_GameRunning == false)
        {
            StartCoroutine(GameOver());
            k_GameRunning = true;
        }
        else
        {
            GameData.l_AllEggs.RemoveAll(item => item == null);
            ScoreText.text = k_Score.ToString();
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
        EndGamePanel.GetComponent<UIEndGame>().ShowPanel();
    }
}
