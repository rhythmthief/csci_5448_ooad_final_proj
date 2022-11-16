using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMobile : MoveBehavior
{
    bool spawned = false; // flag for whether the unit has already spawned

    public void move(Unit self, Cell cell_)
    {
        Cell cellOld = self.getCell();

        // ensure that the cell is not occupied
        if (cell_.isFree())
        {
            cell_.setUnit(self);
            self.setCell(cell_);

            if (!spawned)
            {
                self.notifyObservers(new Event(1, null, cell_.getCoordinates(), new string[2] { "fighter", self.getUnitType() }, self.getCiv().getColor()));
                spawned = true;
            }
            else
            {
                cellOld.setUnit(null); // vacate the old cell
                self.notifyObservers(new Event(1, cellOld.getCoordinates(), cell_.getCoordinates(), new string[2] { "fighter", self.getUnitType() }, self.getCiv().getColor()));
            }
        }
    }
}
