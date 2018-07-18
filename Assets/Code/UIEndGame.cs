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
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void ShowPanel()
    {
        this.GetComponent<CanvasGroup>().alpha = 1;
        this.GetComponent<CanvasGroup>().interactable = true;
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;

        FinalGameScoreText.text = GameData.k_Score.ToString();
        MoreGameDataText.text = string.Format("EGGS: {0}\nBOUNCES: {1}\nSECONDS: {2}", 0, 0, 0);
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
