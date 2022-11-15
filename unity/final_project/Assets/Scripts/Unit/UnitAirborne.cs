using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAirborne : Unit
{
    public UnitAirborne(Civilization civ_, Cell cell_, GraphicsObserver graphicsObserver_)
    {
        cb = new CombatAirborne();
        mb = new MoveMobile();

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
