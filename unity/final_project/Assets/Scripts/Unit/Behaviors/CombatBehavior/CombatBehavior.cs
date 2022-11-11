using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatBehavior
{
    protected string weakAgainst;
    protected string strongAgainst;

    public void attack(Unit self, Unit target)
    {
        int damage_output = self.getDamage();
        int damage_input = target.getDamage();
        string enemyType = target.getUnitType();

        // check if any modifiers against specific enemy types apply
        if (enemyType == strongAgainst)
        {
            damage_output = (int)(damage_output * 1.5);
            damage_input = (int)(damage_input * 0.5);
        }
        else if (enemyType == weakAgainst)
        {
            damage_output = (int)(damage_output * 0.5);
            damage_input = (int)(damage_input * 1.5);
        }
        else if (enemyType == "city" && self.getCiv() is CivilizationConqueror)
        {
            // conquerors deal extra damage to enemy cities
            damage_output = (int)(damage_output * 1.5);
        }

        // when two units fight, they both take damage from one another
        target.reduceHP(damage_output);
        self.reduceHP(damage_input);
    }}
