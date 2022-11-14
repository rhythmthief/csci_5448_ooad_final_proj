using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStationary : MoveBehavior
{
    bool moved = false; // stationary units only "move" once -- when they are spawned into a cell

    public void move(Unit self, Cell cell_)
    {
        // ensure that the cell is not occupied
        if (cell_.isFree() && !moved)
        {
            cell_.setUnit(self);
            moved = true;
            self.notifyObservers(new Event(0, cell_.getCoordinates(), new string[1] { "city" }));
        }
    }
}
