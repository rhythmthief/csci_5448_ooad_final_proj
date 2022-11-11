using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMelee : CombatBehavior
{
    public CombatMelee()
    {
        strongAgainst = "ranged";
        weakAgainst = "airborne";
    }
}
