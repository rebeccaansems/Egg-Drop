using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePowerup : MonoBehaviour
{
    void OnBecameInvisible()
    {
        if (this.transform.position.y < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
