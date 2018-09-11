using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float Speed;

    void Start()
    {
        Speed = Random.Range(0.1F, 0.5f);
    }

    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x + Speed * Time.deltaTime,
            this.transform.position.y);
    }

    void OnBecameInvisible()
    {
        if (this.transform.position.x > 0)
        {
            this.transform.position = new Vector2(-8f, this.transform.position.y);
            Speed = Random.Range(0.1F, 0.5f);
        }
    }
}
