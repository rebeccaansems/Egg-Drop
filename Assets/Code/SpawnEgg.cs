using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEgg : MonoBehaviour
{
    public GameObject Parachute;
    public Sprite[] AllEggs, AllParachutes;
    public Vector2 DropHeightExtrema;

    private bool ParachuteHooked;
    private float DropHeight;

    void Start()
    {
        ParachuteHooked = true;
        this.GetComponent<SpriteRenderer>().sprite = AllEggs[Random.Range(0, AllEggs.Length - 1)];

        Parachute.GetComponent<SpriteRenderer>().sprite = AllParachutes[Random.Range(0, AllParachutes.Length - 1)];
        this.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 25));
        DropHeight = Random.Range(DropHeightExtrema.x, DropHeightExtrema.y);
    }

    void Update()
    {
        if (this.transform.position.y < DropHeight && Parachute != null && ParachuteHooked)
        {
            ReleaseEgg();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Egg" && Parachute != null && ParachuteHooked)
        {
            ReleaseEgg();
        }
    }

    void ReleaseEgg()
    {
        Parachute.transform.parent = this.transform.parent;
        Destroy(this.GetComponent<FixedJoint2D>());

        this.GetComponents<PlayAudio>()[1].PlayRandom();

        GameData.l_AllEggs.Add(this.gameObject);
        GameData.k_Eggs += 1;

        ParachuteHooked = false;
    }
}
