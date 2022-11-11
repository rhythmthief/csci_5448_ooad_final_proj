using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMelee : Unit
{
    public UnitMelee()
    {
        cb = new CombatMelee();
        mb = new MoveMobile();
    }
}
