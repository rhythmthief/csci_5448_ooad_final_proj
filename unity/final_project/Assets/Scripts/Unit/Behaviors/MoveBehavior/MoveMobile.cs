using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMobile : MoveBehavior
{
    public void move(Unit self, Cell cell_)
    {
        // ensure that the cell is not occupied
        if (cell_.isFree())
        {
            cell_.setUnit(self);
            self.notifyObservers(new Event(0, cell_.getCoordinates(), new string[1] { "unit" }));
        }
    }
}
