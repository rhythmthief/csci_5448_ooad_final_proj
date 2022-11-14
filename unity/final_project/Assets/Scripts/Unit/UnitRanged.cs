using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRanged : Unit
{
    public UnitRanged(Cell cell_)
    {
        cb = new CombatRanged();
        mb = new MoveMobile();

        // move into a new location when spawned
        mb.move(this, cell_);
        cell = cell_;
    }
}
