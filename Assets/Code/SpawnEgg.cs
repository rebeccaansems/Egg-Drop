using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEgg : MonoBehaviour
{
    public Sprite[] AllEggs;
    public bool isDefaultEgg;

    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = AllEggs[Random.Range(0, AllEggs.Length - 1)];

        if (isDefaultEgg == false)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Egg" && this.GetComponent<Rigidbody2D>().gravityScale == 0)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 1;
            GameData.k_AllEggs.Add(this.gameObject);
            GameData.k_Eggs += 1;
        }
    }
}
