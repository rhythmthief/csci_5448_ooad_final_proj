using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static Cell[][] generateBoard()
    {
        Cell[][] cells = new Cell[20][];

        // generate cells
        for (int i = 0; i < 20; i++)
        {
            Cell[] cellLine = new Cell[20];

            for (int j = 0; j < 20; j++)
            {
                cellLine[j] = new Cell(i, 0, j);
            }

            cells[i] = cellLine;
        }

        // link into a graph, set coords
        // generate cells
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                //normal case
                if (i != 0 && i != 19 && j != 0 && j != 19)
                {
                    cells[i][j].addAdjacent(cells[i][j - 1]);
                    cells[i][j].addAdjacent(cells[i][j + 1]);
                    cells[i][j].addAdjacent(cells[i - 1][j]);
                    cells[i][j].addAdjacent(cells[i + 1][j]);
                }
                else
                {
                    // edge cases

                    // corners
                    if (i == 0 && j == 0)
                    {
                        cells[i][j].addAdjacent(cells[i][j + 1]);
                        cells[i][j].addAdjacent(cells[i + 1][j]);
                    }

                    if (i == 19 && j == 0)
                    {
                        cells[i][j].addAdjacent(cells[i][j + 1]);
                        cells[i][j].addAdjacent(cells[i - 1][j]);
                    }

                    if (i == 19 && j == 19)
                    {
                        cells[i][j].addAdjacent(cells[i][j - 1]);
                        cells[i][j].addAdjacent(cells[i - 1][j]);
                    }

                    if (i == 0 && j == 19)
                    {
                        cells[i][j].addAdjacent(cells[i][j - 1]);
                        cells[i][j].addAdjacent(cells[i + 1][j]);
                    }

                    // non-corner edges
                    if (i == 0 && j != 0 && j != 19)
                    {
                        cells[i][j].addAdjacent(cells[i + 1][j]);
                        cells[i][j].addAdjacent(cells[i][j - 1]);
                        cells[i][j].addAdjacent(cells[i][j + 1]);
                    }

                    if (i == 19 && j != 0 && j != 19)
                    {
                        cells[i][j].addAdjacent(cells[i - 1][j]);
                        cells[i][j].addAdjacent(cells[i][j - 1]);
                        cells[i][j].addAdjacent(cells[i][j + 1]);
                    }

                    if (j == 0 && i != 0 && i != 19)
                    {
                        cells[i][j].addAdjacent(cells[i][j + 1]);
                        cells[i][j].addAdjacent(cells[i - 1][j]);
                        cells[i][j].addAdjacent(cells[i + 1][j]);
                    }

                    if (j == 19 && i != 0 && i != 19)
                    {
                        cells[i][j].addAdjacent(cells[i][j - 1]);
                        cells[i][j].addAdjacent(cells[i - 1][j]);
                        cells[i][j].addAdjacent(cells[i + 1][j]);
                    }
                }
            }
        }

        return cells;
    }

    /// <summary>
    /// Use BFS to locate a spawn location for a new unit relative to the player's capital
    /// This will traverse the entire game board -- anything is fair game!
    /// </summary>
    /// <param name="civ">Civilization to find a spawn location for</param>
    /// <returns></returns>
    public static Cell findSpawnLocation(Civilization civ)
    {
        // get location of the civilization's city
        Cell startingCell = civ.getCity().getCell();
        List<Cell> cells = new List<Cell>();
        cells.Add(startingCell);
        Cell choice = null;

        // scan every cell in the list
        foreach (Cell cell_ in cells)
        {
            List<Cell> neighbors = cell_.getAdjacent();
            List<Cell> newCells = new List<Cell>();

            // scan every neighbor of a cell from the list
            foreach (Cell n in neighbors)
            {
                if (!n.isFree())
                {
                    // if neighbor isn't free, it'll be in the new traversal list
                    newCells.Add(n);
                }
                else
                {
                    // if neighbor is free, we pick it and terminate
                    choice = n;
                    break;
                }
            }

            // check if a cell has been selected for spawn
            if (choice != null)
                break;
        }

        return choice;
    }
}
