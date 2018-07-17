using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackground : MonoBehaviour {

    public SpriteRenderer[] LeftLeaf, RightLeaf;
    public Sprite[] LeftLeafSprites, RightLeafSprites;

	void Start () {
        int left = Random.Range(0, LeftLeafSprites.Length - 1);
        int right = Random.Range(0, RightLeafSprites.Length - 1);

        foreach(SpriteRenderer leaf in LeftLeaf)
        {
            leaf.sprite = LeftLeafSprites[left];
        }

        foreach (SpriteRenderer leaf in RightLeaf)
        {
            leaf.sprite = RightLeafSprites[right];
        }
    }
}
