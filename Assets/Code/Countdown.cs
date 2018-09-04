using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    public Text CountdownText;
    public CanvasGroup CountdownPanel;
	
    public void Start()
    {
        Hide();
    }

    private void Show()
    {
        CountdownPanel.alpha = 1;
    }

    private void Hide()
    {
        CountdownPanel.alpha = 0;
    }

    public IEnumerator StartCountdown(Button button)
    {
        Show();
        Time.timeScale = 0;
        CountdownText.text = "3";
        this.GetComponent<PlayAudio>().Play(1);
        yield return new WaitForSecondsRealtime(1);

        CountdownText.text = "2";
        this.GetComponent<PlayAudio>().Play(1);
        yield return new WaitForSecondsRealtime(1);

        CountdownText.text = "1";
        this.GetComponent<PlayAudio>().Play(1);
        yield return new WaitForSecondsRealtime(1);

        CountdownText.text = "";
        button.interactable = true;
        Time.timeScale = 1;
        Hide();
    }
}
