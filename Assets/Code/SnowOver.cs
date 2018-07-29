﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowOver : MonoBehaviour
{
    public Animator[] SnowableAnim;

    public void Snow()
    {
        foreach(Animator anim in SnowableAnim)
        {
            anim.SetBool("isSnow", true);
        }
    }

    public void Thaw()
    {
        foreach (Animator anim in SnowableAnim)
        {
            anim.SetBool("isSnow", false);
        }
    }
}
