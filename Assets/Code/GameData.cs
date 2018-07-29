﻿using System.Collections;
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
    public static bool k_GameRunning = true, k_ScoresUpdated, k_GravitySlowDown;
    public static float k_SpeedAdjustment;

    public GameObject EndGamePanel;
    public ParticleSystem SnowMachine;
    public Text ScoreText;

    void Start()
    {
        k_ScoresUpdated = false;
        k_GravitySlowDown = false;
        k_Score = 0;
        k_Bounces = 0;
        k_Eggs = 0;
        k_SpeedAdjustment = 1;
        k_GameNumber = PlayerPrefs.GetInt("GameNumber", 1);
        k_BouncesAllTime = PlayerPrefs.GetInt("Bounces", 0);
        k_EggsAllTime = PlayerPrefs.GetInt("Eggs", 0);
        l_AllEggs = new List<GameObject>();

        Physics2D.gravity = new Vector2(0, -9.8f);

        l_HighScores = new List<Tuple<int, int>>();
        l_HighScores.Add(new Tuple<int, int>(PlayerPrefs.GetInt("Highscore_Date0", 0), PlayerPrefs.GetInt("Highscore_Score0", 0)));
        l_HighScores.Add(new Tuple<int, int>(PlayerPrefs.GetInt("Highscore_Date1", 0), PlayerPrefs.GetInt("Highscore_Score1", 0)));
        l_HighScores.Add(new Tuple<int, int>(PlayerPrefs.GetInt("Highscore_Date2", 0), PlayerPrefs.GetInt("Highscore_Score2", 0)));

        Time.timeScale = 1;

        ScoreText.fontSize = 180;

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

        if (k_GravitySlowDown)
        {
            StartCoroutine(SlowDownGravity(4));
            k_GravitySlowDown = false;
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
        EndGamePanel.GetComponent<UIEndGame>().ShowPanel();
    }

    public IEnumerator SlowDownGravity(int slowRate)
    {
        SnowMachine.Play();
        Physics2D.gravity = Physics2D.gravity / slowRate;
        k_SpeedAdjustment = k_SpeedAdjustment / (slowRate / 2);
        this.GetComponent<SnowOver>().Snow();

        yield return new WaitForSeconds(10f);
        this.GetComponent<SnowOver>().Thaw();
        Physics2D.gravity = Physics2D.gravity * slowRate;
        k_SpeedAdjustment = k_SpeedAdjustment * (slowRate / 2);
    }
}
