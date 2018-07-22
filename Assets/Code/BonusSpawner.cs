using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject BaseEgg, IceCube;
    public int MinSpawnTime, MaxSpawnTime;
    public Vector2 NewEggSpawnLocation;

    void Start()
    {
        StartCoroutine(SpawnNewEgg());
    }

    IEnumerator SpawnNewEgg()
    {
        while (GameData.k_GameRunning)
        {
            yield return new WaitForSeconds(Random.Range(MinSpawnTime, MaxSpawnTime));
            if (GameData.k_GameRunning)
            {
                int spawnNumber = Random.Range(0, 100);
                if (spawnNumber > 90)
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
