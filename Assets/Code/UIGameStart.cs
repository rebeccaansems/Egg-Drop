using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameStart : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 0;

        if (GameData.k_GameInSessionNumber != 0)
        {
            this.GetComponent<Animator>().SetInteger("gameStarted", 2);
            this.GetComponent<CanvasGroup>().alpha = 0;
            this.GetComponent<CanvasGroup>().interactable = false;
            this.GetComponent<CanvasGroup>().blocksRaycasts = false;
            Time.timeScale = 1;
        }
    }

    public void StartGame()
    {
        this.GetComponent<Animator>().SetInteger("gameStarted", 1);
        this.GetComponent<CanvasGroup>().interactable = false;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        Time.timeScale = 1;
    }
}
