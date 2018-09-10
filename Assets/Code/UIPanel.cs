using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VoxelBusters.NativePlugins;

public class UIPanel : MonoBehaviour
{
    public Button PauseButton;
    public Countdown CountdownTimer;

    private SocialShareSheet SocialShare;

    public void Start()
    {
        HidePanel(true);
    }

    public void ShowPanel()
    {
        Time.timeScale = 0;
        PauseButton.interactable = false;

        this.GetComponent<CanvasGroup>().alpha = 1;
        this.GetComponent<CanvasGroup>().interactable = true;
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void HidePanel()
    {
        HidePanel(false);
    }

    public void HidePanel(bool hideTimer)
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().interactable = false;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;

        if (CountdownTimer != null && hideTimer == false)
        {
            StartCoroutine(CountdownTimer.StartCountdown(PauseButton));
        }
        else
        {
            Time.timeScale = 1;
            PauseButton.interactable = true;
        }
    }

    public void ShareTwitter()
    {
        SocialShare = new SocialShareSheet();
#if UNITY_IOS
        SocialShare.URL = "https://itunes.apple.com/us/app/f-in-the-b/id1328718409?ls=1&mt=8";
#elif UNITY_ANDROID
        SocialShare.URL = "https://play.google.com/store/apps/details?id=com.rebeccaansems.fintheb";
#endif
        SocialShare.Text = "My highscore on Egg Drop is " + GameData.l_HighScores[0].Second + " can you beat it? " + SocialShare.URL;

        // Show composer
        NPBinding.UI.SetPopoverPointAtLastTouchPosition(); // To show popover at last touch point on iOS. On Android, its ignored.
        NPBinding.Sharing.ShowView(SocialShare, FinishedSharing);
    }

    private void FinishedSharing(eShareResult _result)
    {
    }
}
