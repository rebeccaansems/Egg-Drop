using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static List<GameObject> k_AllEggs;
    public static int k_Score = 0;
    public static bool k_GameRunning = true;

    void Update()
    {
        GameData.k_AllEggs.RemoveAll(item => item == null);
    }
}
