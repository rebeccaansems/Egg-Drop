using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject BaseEgg;
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
                GameObject newEgg = Instantiate(BaseEgg, this.transform);
                newEgg.transform.position = new Vector2(Random.Range(NewEggSpawnLocation.x - 0.5f, NewEggSpawnLocation.x + 1.5f), NewEggSpawnLocation.y);
            }
        }
    }
}
