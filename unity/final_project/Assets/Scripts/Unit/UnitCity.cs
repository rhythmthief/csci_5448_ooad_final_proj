using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCity : Unit
{
    public UnitCity(Cell cell_) 
    {
        damage = 20;
        hp = 500;
        mb = new MoveStationary();

        // move into a new location when spawned
        mb.move(this, cell_);
        cell = cell_;
    }
}
