using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowOver : MonoBehaviour
{
    public SpriteRenderer[] SnowableObjects;
    public Sprite[] NormalGrass, SnowGrass;

    public void Snow()
    {
        for (int i = 0; i < SnowableObjects.Length; i++)
        {
            SnowableObjects[i].sprite = SnowGrass[i];
        }
    }

    public void Thaw()
    {
        for (int i = 0; i < SnowableObjects.Length; i++)
        {
            SnowableObjects[i].sprite = NormalGrass[i];
        }
    }
}
