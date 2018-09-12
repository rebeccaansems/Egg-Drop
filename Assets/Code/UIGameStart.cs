using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameStart : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 0;

        //if (GameData.k_GameInSessionNumber != 0)
        //{
        //    Time.timeScale = 1;
        //    this.GetComponent<CanvasGroup>().alpha = 0;
        //    this.GetComponent<CanvasGroup>().interactable = false;
        //    this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        //}
    }

    public void StartGame()
    {
        this.GetComponent<Animator>().SetBool("gameStarted", true);
        this.GetComponent<CanvasGroup>().interactable = false;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        Time.timeScale = 1;
    }
}
