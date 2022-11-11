using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    int[] coords; //x-y coordinates in the game board
    Unit occupant;
    List<Cell> adjacent;
}
