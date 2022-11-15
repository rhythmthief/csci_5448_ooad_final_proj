using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCity : Unit
{
    public UnitCity(Civilization civ_, Cell cell_, GraphicsObserver graphicsObserver_)
    {
        damage = 20;
        hp = 500;
        mb = new MoveStationary();

        // set reference to the unit's civ and give civ reference to the unit
        civ = civ_;
        civ_.setCity(this);
        
        // register its new graphics observer
        registerObserver(graphicsObserver_);

        // move into a new location when spawned
        mb.move(this, cell_);
        cell = cell_;
    }
}
