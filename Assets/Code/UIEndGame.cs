using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIEndGame : MonoBehaviour
{
    public Text FinalGameScoreText, MoreGameDataText;

    public void Start()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().interactable = false;
    }

    public void ShowPanel()
    {
        this.GetComponent<CanvasGroup>().alpha = 1;
        this.GetComponent<CanvasGroup>().interactable = true;

        FinalGameScoreText.text = GameData.k_Score.ToString();
        MoreGameDataText.text = string.Format("Eggs: {0}\nBounces: {1}\nSeconds: {2}", 0, 0, 0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShareTwitter()
    {
        Debug.Log("SHARE");
    }

    public void ShowHighScorePanel()
    {
        Debug.Log("HIGHSCORE");
    }



}
