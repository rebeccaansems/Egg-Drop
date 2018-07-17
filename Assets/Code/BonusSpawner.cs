﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject BaseEgg;
    public int MinSpawnTime, MaxSpawnTime;

    void Start()
    {
        StartCoroutine(SpawnNewEgg());
    }

    IEnumerator SpawnNewEgg()
    {
        while (GameData.k_GameRunning)
        {
            yield return new WaitForSeconds(Random.Range(MinSpawnTime, MaxSpawnTime));
            if (GameObject.FindGameObjectsWithTag("Egg").Length == GameData.k_AllEggs.Count && GameData.k_GameRunning)
            {
                GameObject newEgg = Instantiate(BaseEgg, this.transform);
            }
        }
    }
}
