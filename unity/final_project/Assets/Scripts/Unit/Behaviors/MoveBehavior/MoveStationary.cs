using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStationary : MoveBehavior
{
    bool spawned = false; // flag for whether the unit has already spawned

    public void move(Unit self, Cell cell_)
    {
        // ensure that the cell is not occupied
        if (cell_.isFree() && !spawned)
        {
            //Debug.Log();

            cell_.setUnit(self);
            self.setCell(cell_);
            spawned = true;
            self.notifyObservers(new Event(1, null, cell_.getCoordinates(), new string[1] { "city" }));
        }
    }
}
