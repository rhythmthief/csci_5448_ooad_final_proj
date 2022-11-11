using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRanged : Unit
{
    public UnitRanged()
    {
        cb = new CombatRanged();
        mb = new MoveMobile();
    }
}
