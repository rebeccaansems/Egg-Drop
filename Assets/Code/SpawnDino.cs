using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDino : MonoBehaviour
{
    public int NumDinoColors = 3;

    void Start()
    {
        this.GetComponent<Animator>().SetInteger("Color", Random.Range(0, NumDinoColors));
    }
}
