using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseGame : UIPanel
{
    public UIStatsPanel StatsPanel;
    public Slider SfxSlider, MusicSlider;
    public AudioSource UIAudio;

    public new void ShowPanel()
    {
        base.ShowPanel();

        SfxSlider.value = GameData.k_VolumeSFX;
        MusicSlider.value = GameData.k_VolumeMusic;
    }

    public void ShowStatsPanel()
    {
        HidePanel(true);
        StatsPanel.ShowPanel(this);
    }

    public void ChangeSFXVolume(float volume)
    {
        GameData.k_VolumeSFX = volume;
        PlayerPrefs.SetFloat("SFX", GameData.k_VolumeSFX);
        UIAudio.volume = GameData.k_VolumeSFX;
    }

    public void ChangeMusicVolume(float volume)
    {
        GameData.k_VolumeMusic = volume;
        PlayerPrefs.SetFloat("Music", GameData.k_VolumeMusic);
    }
}
