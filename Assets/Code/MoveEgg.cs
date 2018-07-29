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
            Destroy(this.gameObject);
        }
    }
}
