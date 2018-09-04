using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBird : MonoBehaviour
{
    public GameObject Parachute;
    public Sprite[] AllParachutes;

    public int NumberColors;

    void Start()
    {
        Parachute.GetComponent<SpriteRenderer>().sprite = AllParachutes[Random.Range(0, AllParachutes.Length - 1)];
        this.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 25));

        this.GetComponent<Animator>().SetInteger("birdColor", Random.Range(0, NumberColors));
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
        GameData.k_EggRain = true;
        this.GetComponent<Animator>().SetBool("isDead", true);
    }

    public void DisconnectParachute()
    {
        this.GetComponent<PlayAudio>().PlayRandom();
        Parachute.transform.parent = this.transform.parent;
        Destroy(this.GetComponent<FixedJoint2D>());
        Destroy(this.GetComponent<CircleCollider2D>());
    }
}
