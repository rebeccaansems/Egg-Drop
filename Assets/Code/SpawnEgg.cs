using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEgg : MonoBehaviour {

    public Sprite[] AllEggs;

	void Start () {
        this.GetComponent<SpriteRenderer>().sprite = AllEggs[Random.Range(0, AllEggs.Length - 1)];
	}
}
