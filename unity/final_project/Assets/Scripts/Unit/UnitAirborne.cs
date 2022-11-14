using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAirborne : Unit
{
    public UnitAirborne(Cell cell_)
    {
        cb = new CombatAirborne();
        mb = new MoveMobile();

        // move into a new location when spawned
        mb.move(this, cell_);
        cell = cell_;
    }
}
