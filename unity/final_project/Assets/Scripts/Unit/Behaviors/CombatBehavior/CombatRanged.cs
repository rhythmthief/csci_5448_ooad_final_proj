using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRanged : CombatBehavior
{
    public CombatRanged()
    {
        strongAgainst = "airborne";
        weakAgainst = "melee";
    }
}
