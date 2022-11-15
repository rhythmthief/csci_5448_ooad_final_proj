using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : Subject
{
    int[] coords; //[x, y, z] coordinates in the world
    Unit unit = null;
    List<Cell> adjacent;

    /// <summary>
    /// Default cell constructor
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public Cell(int x, int y, int z)
    {
        setCoordinates(x, y, z);
        adjacent = new List<Cell>();
    }

    /// <summary>
    /// Set coordinates of the cell
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public void setCoordinates(int x, int y, int z) => coords = new int[3] { x, y, z };

    /// <summary>
    /// Add a new adjacent cell to the list
    /// </summary>
    /// <param name="adj">Cell to add</param>
    public void addAdjacent(Cell adj) => adjacent.Add(adj);

    /// <summary>
    /// Get the list of adjacent cells
    /// </summary>
    /// <returns>adjacent cells</returns>
    public List<Cell> getAdjacent() => adjacent;

    /// <summary>
    /// Get coordinates of the cell
    /// </summary>
    /// <returns>x,y,z coordinates stored in an int array</returns>
    public int[] getCoordinates() => coords;

    /// <summary>
    /// Check if the cell is occupied by another unit
    /// </summary>
    /// <returns>true if cell is occupied, false otherwise</returns>
    public bool isFree() => unit == null ? true : false;


    /// <summary>
    /// Set a new unit to occupy the cell
    /// </summary>
    /// <param name="unit_">New unit</param>
    public void setUnit(Unit unit_) => unit = unit_; 

    public Unit getUnit() => unit;
}
