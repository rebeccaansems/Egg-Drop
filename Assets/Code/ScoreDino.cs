using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDino : MonoBehaviour
{
    public GameObject StarterEgg;

    void Start()
    {
        GameData.l_AllEggs = new List<GameObject>();
        GameData.l_AllEggs.Add(StarterEgg);
    }

    void Update()
    {
        if (GameData.l_AllEggs.Count == 0 && this.GetComponent<Animator>().GetBool("IsDead") == false)
        {
            this.GetComponent<Animator>().SetBool("IsDead", true);
            GameData.k_GameRunning = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Egg")
        {
            GameData.k_Score += GameData.l_AllEggs.Count;
            GameData.k_Bounces += 1;
        }
    }
}
