using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEgg : MonoBehaviour
{
    public float MaxSpeed = 15f;

    void FixedUpdate()
    {
        if (this.GetComponent<Rigidbody2D>().velocity.magnitude > (MaxSpeed * GameData.k_SpeedAdjustment))
        {
            this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * (MaxSpeed * GameData.k_SpeedAdjustment);
        }
    }

    void OnBecameInvisible()
    {
        if (this.transform.position.y < 0)
        {
            this.GetComponents<PlayAudio>()[3].PlayRandom();
            Destroy(this.gameObject);
        }
    }

    void OnBecameVisible()
    {
        if (Time.deltaTime != 0)
        {
            this.GetComponents<PlayAudio>()[2].PlayRandom();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponents<PlayAudio>()[0].PlayRandom();
    }
}
