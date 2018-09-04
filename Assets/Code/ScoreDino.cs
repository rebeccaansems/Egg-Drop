using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDino : MonoBehaviour
{
    public GameObject StarterEgg;

    void Update()
    {
        if (GameData.l_AllEggs.Count == 0 && this.GetComponent<Animator>().GetBool("IsDead") == false && StarterEgg == null)
        {
            this.GetComponents<PlayAudio>()[0].PlayRandom();
            this.GetComponent<Animator>().SetBool("IsDead", true);
            Destroy(this.GetComponents<CapsuleCollider2D>()[0]);
            Destroy(this.GetComponents<CapsuleCollider2D>()[1]);
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
