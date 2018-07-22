using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEgg : MonoBehaviour
{
    public float MaxSpeed = 200f;

    void FixedUpdate()
    {
        if (this.GetComponent<Rigidbody2D>().velocity.magnitude > MaxSpeed)
        {
            this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * MaxSpeed;
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
