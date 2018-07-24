using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject BaseEgg, IceCube;
    public int MinSpawnTime, MaxSpawnTime;
    public Vector2 NewEggSpawnLocation;

    public int PercentSpawnChanceIce = 10;

    void Start()
    {
        StartCoroutine(SpawnNewEgg());

        PercentSpawnChanceIce = 100 - PercentSpawnChanceIce;
    }

    IEnumerator SpawnNewEgg()
    {
        while (GameData.k_GameRunning)
        {
            yield return new WaitForSeconds(Random.Range(MinSpawnTime, MaxSpawnTime));
            if (GameData.k_GameRunning)
            {
                int spawnNumber = Random.Range(0, 100);
                if (spawnNumber > PercentSpawnChanceIce)
                {
                    GameObject iceCube = Instantiate(IceCube, this.transform);
                    iceCube.transform.position = new Vector2(Random.Range(NewEggSpawnLocation.x - 0.5f, NewEggSpawnLocation.x + 1.5f), NewEggSpawnLocation.y);
                }
                else
                {
                    GameObject newEgg = Instantiate(BaseEgg, this.transform);
                    newEgg.transform.position = new Vector2(Random.Range(NewEggSpawnLocation.x - 0.5f, NewEggSpawnLocation.x + 1.5f), NewEggSpawnLocation.y);
                }
            }
        }
    }
}
