using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip[] AudioClips;

    public void Play()
    {
        AudioSource.PlayClipAtPoint(AudioClips[0], Camera.main.transform.position, GameData.k_VolumeSFX);
    }

    public void Play(int num)
    {
        AudioSource.PlayClipAtPoint(AudioClips[num], Camera.main.transform.position, GameData.k_VolumeSFX);
    }

    public void PlayRandom()
    {
        AudioSource.PlayClipAtPoint(AudioClips[Random.Range(0, AudioClips.Length)], Camera.main.transform.position, GameData.k_VolumeSFX);
    }

    public void PlayRandom(int min, int max)
    {
        AudioSource.PlayClipAtPoint(AudioClips[Random.Range(min, max)], Camera.main.transform.position, GameData.k_VolumeSFX);
    }

}