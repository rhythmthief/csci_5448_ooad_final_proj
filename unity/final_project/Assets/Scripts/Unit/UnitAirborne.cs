using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAirborne : Unit
{
    public UnitAirborne()
    {
        cb = new CombatAirborne();
        mb = new MoveMobile();
    }
}
