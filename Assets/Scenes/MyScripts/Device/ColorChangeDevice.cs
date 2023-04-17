using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeDevice : BaseDevice
{
    public override void Operate()
    {
        Color random = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        //iTween.ColorTo(gameObject, iTween.Hash("r", random.r, "g", random.g, "b", random.b, "delay", 0.3f, "time", 0.5f));
        GetComponent<Renderer>().material.color = random;
    }
}
