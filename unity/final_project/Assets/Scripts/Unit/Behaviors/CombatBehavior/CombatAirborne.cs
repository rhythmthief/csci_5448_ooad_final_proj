using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAirborne : CombatBehavior
{
    public void attack(Unit self, Unit target)
    {
        int damage_output = self.getDamage();
        int damage_input = target.getDamage();

        // check if any modifiers against specific enemy types apply
        if (target is UnitMelee) {
            damage_output = (int)(damage_output * 1.5);
            damage_input = (int)(damage_input * 0.5);
        } else if (target is UnitRanged) {
            damage_output = (int)(damage_output * 0.5);
            damage_input = (int)(damage_input * 1.5);
        }
        
        // when two units fight, they both take damage from one another
        target.reduceHP(damage_output);
        self.reduceHP(damage_input);
    }
}
