using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRanged : Unit
{
    public UnitRanged(Civilization civ_, Cell cell_, GraphicsObserver graphicsObserver_)
    {
        cb = new CombatRanged();
        mb = new MoveMobile();
        civ = civ_;

        // set reference to the unit's civ and give civ reference to the unit
        civ = civ_;
        civ_.addFighter(this);

        // register its new graphics observer
        registerObserver(graphicsObserver_);

        // move into a new location when spawned
        mb.move(this, cell_);
        cell = cell_;
    }
}
