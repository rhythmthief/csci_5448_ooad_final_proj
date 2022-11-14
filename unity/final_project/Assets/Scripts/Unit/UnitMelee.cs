using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMelee : Unit
{
    public UnitMelee(Cell cell_)
    {
        cb = new CombatMelee();
        mb = new MoveMobile();

        // move into a new location when spawned
        mb.move(this, cell_);
        cell = cell_;
    }
}
