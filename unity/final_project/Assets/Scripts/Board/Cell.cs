using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    int[] coords; //[x, y, z] coordinates in the world
    Unit unit;
    List<Cell> adjacent;

    public Cell(int x, int y, int z)
    {
        setCoordinates(x, y, z);
        adjacent = new List<Cell>();
    }

    public void setCoordinates(int x, int y, int z)
    {
        coords = new int[3];
        coords[0] = x;
        coords[1] = y;
        coords[2] = z;
    }

    public void addAdjacent(Cell adj)
    {
        adjacent.Add(adj);
    }

    public int[] getCoordinates()
    {
        return coords;
    }
}
