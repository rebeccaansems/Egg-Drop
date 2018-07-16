using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    public static List<GameObject> k_AllEggs;
    public static int k_Score = 0;
    public static bool k_GameRunning = true;

    void Update()
    {
        GameData.k_AllEggs.RemoveAll(item => item == null);

        if (k_GameRunning == false)
        {
            StartCoroutine(Restart());
        }
    }

    //temp
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
