using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CombatBehavior
{
    void attack(Unit self, Unit target);
}
