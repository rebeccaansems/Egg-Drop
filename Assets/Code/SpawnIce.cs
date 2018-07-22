using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIce : MonoBehaviour
{
    public GameObject Parachute;
    public Sprite[] AllParachutes;

    void Start()
    {
        Parachute.GetComponent<SpriteRenderer>().sprite = AllParachutes[Random.Range(0, AllParachutes.Length - 1)];
        this.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 25));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Egg")
        {
            PowerupHit();
        }
    }

    void PowerupHit()
    {
        Parachute.transform.parent = this.transform.parent;
        GameData.k_GravitySlowDown = true;
        Destroy(this.gameObject);
    }
}

