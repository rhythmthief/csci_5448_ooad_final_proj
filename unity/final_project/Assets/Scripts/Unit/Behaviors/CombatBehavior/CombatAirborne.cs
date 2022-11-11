using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAirborne : CombatBehavior
{
    public CombatAirborne()
    {
        strongAgainst = "melee";
        weakAgainst = "ranged";
    }
}
