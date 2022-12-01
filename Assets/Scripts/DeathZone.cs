using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : Zone
{
    protected static List<GameObject> _dead;
    protected void Start()
    {
        if (_dead == null) _dead = new List<GameObject>();
    }
    protected override void ZoneTrigger(GameObject marble)
    {
        if (!_dead.Contains(marble)) _dead.Add(marble);
        marble.SetActive(false);
    }
}
