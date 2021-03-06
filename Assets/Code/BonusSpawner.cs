﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject BaseEgg, IceCube, Bird;
    public int MinSpawnTime, MaxSpawnTime;
    public Vector2 NewEggSpawnLocation;

    public int IcePercentSpawnChance = 10, RainPercentSpawnChance = 5;
    private bool LastSpawnEgg = true;

    void Start()
    {
        StartCoroutine(SpawnNewEgg());
        
        RainPercentSpawnChance = RainPercentSpawnChance + IcePercentSpawnChance;
    }

    IEnumerator SpawnNewEgg()
    {
        while (GameData.k_GameRunning)
        {
            yield return new WaitForSeconds(Random.Range(MinSpawnTime, MaxSpawnTime));
            if (GameData.k_GameRunning)
            {
                int spawnNumber = Random.Range(0, 100);
                if (spawnNumber < IcePercentSpawnChance && LastSpawnEgg)
                {
                    GameObject iceCube = Instantiate(IceCube, this.transform);
                    iceCube.transform.position = new Vector2(Random.Range(NewEggSpawnLocation.x - 0.5f, NewEggSpawnLocation.x + 1.5f), NewEggSpawnLocation.y);
                    LastSpawnEgg = false;
                }
                else if (spawnNumber < RainPercentSpawnChance && LastSpawnEgg)
                {
                    GameObject bird = Instantiate(Bird, this.transform);
                    bird.transform.position = new Vector2(Random.Range(NewEggSpawnLocation.x - 0.5f, NewEggSpawnLocation.x + 1.5f), NewEggSpawnLocation.y);
                    LastSpawnEgg = false;
                }
                else
                {
                    GameObject newEgg = Instantiate(BaseEgg, this.transform);
                    newEgg.transform.position = new Vector2(Random.Range(NewEggSpawnLocation.x - 0.5f, NewEggSpawnLocation.x + 1.5f), NewEggSpawnLocation.y);
                    LastSpawnEgg = true;
                }
            }
        }
    }

    public void RainEggs()
    {
        StopCoroutine(SpawnNewEgg());
        StartCoroutine(RainEggs(5));
    }

    IEnumerator RainEggs(int eggRate)
    {
        for (int i = 0; i < eggRate; i++)
        {
            GameObject newEgg = Instantiate(BaseEgg, this.transform);
            newEgg.transform.position = new Vector2(Random.Range(NewEggSpawnLocation.x - 0.5f, NewEggSpawnLocation.x + 1.5f), NewEggSpawnLocation.y);
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine(SpawnNewEgg());
    }
}
