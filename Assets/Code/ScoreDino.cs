using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDino : MonoBehaviour
{
    public GameObject StarterEgg;

    private List<GameObject> AllEggs;

    void Start()
    {
        AllEggs = new List<GameObject>();
        AllEggs.Add(StarterEgg);
    }

    void Update()
    {
        AllEggs.RemoveAll(item => item == null);

        if (AllEggs.Count == 0 && this.GetComponent<Animator>().GetBool("IsDead") == false)
        {
            this.GetComponent<Animator>().SetBool("IsDead", true);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Egg")
        {
            GameData.k_Score += 1;
        }
    }
}
