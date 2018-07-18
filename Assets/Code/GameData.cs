using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    public static List<GameObject> k_AllEggs;
    public static int k_Score = 0;
    public static bool k_GameRunning = true;

    public GameObject EndGamePanel;
    public Text ScoreText;

    void Start()
    {
        k_Score = 0;
        Time.timeScale = 1;
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
            GameData.k_AllEggs.RemoveAll(item => item == null);
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
