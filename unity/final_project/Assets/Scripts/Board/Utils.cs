using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static Cell[][] generateBoard(Observer graphicsObserver)
    {
        Cell[][] cells = new Cell[20][];
        Dictionary<string, int> directionMap = new Dictionary<string, int>();



        // generate cells
        for (int i = 0; i < 20; i++)
        {
            Cell[] cellLine = new Cell[20];

            for (int j = 0; j < 20; j++)
            {
                cellLine[j] = new Cell(i, 0, j);
                cellLine[j].registerObserver(graphicsObserver);
                cellLine[j].notifyObservers(new Event(0, null, cellLine[j].getCoordinates(), null, new Color()));
            }

            cells[i] = cellLine;
        }

        // link into a graph, set coords
        // generate cells
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {

                directionMap = new Dictionary<string, int>();

                //normal case
                if (i != 0 && i != 19 && j != 0 && j != 19)
                {
                    cells[i][j].addAdjacent(cells[i][j - 1]);
                    cells[i][j].addAdjacent(cells[i][j + 1]);
                    cells[i][j].addAdjacent(cells[i - 1][j]);
                    cells[i][j].addAdjacent(cells[i + 1][j]);

                    // map directions to neighbor indices
                    directionMap.Add("up", 1);
                    directionMap.Add("down", 0);
                    directionMap.Add("left", 2);
                    directionMap.Add("right", 3);
                }
                else
                {
                    // edge cases

                    // corners
                    if (i == 0 && j == 0)
                    {
                        cells[i][j].addAdjacent(cells[i][j + 1]);
                        cells[i][j].addAdjacent(cells[i + 1][j]);

                        // map directions to neighbor indices
                        directionMap.Add("up", 0);
                        directionMap.Add("right", 1);
                    }

                    if (i == 19 && j == 0)
                    {
                        cells[i][j].addAdjacent(cells[i][j + 1]);
                        cells[i][j].addAdjacent(cells[i - 1][j]);

                        // map directions to neighbor indices
                        directionMap.Add("up", 0);
                        directionMap.Add("left", 1);
                    }

                    if (i == 19 && j == 19)
                    {
                        cells[i][j].addAdjacent(cells[i][j - 1]);
                        cells[i][j].addAdjacent(cells[i - 1][j]);

                        // map directions to neighbor indices
                        directionMap.Add("down", 0);
                        directionMap.Add("left", 1);
                    }

                    if (i == 0 && j == 19)
                    {
                        cells[i][j].addAdjacent(cells[i][j - 1]);
                        cells[i][j].addAdjacent(cells[i + 1][j]);

                        // map directions to neighbor indices
                        directionMap.Add("down", 0);
                        directionMap.Add("right", 1);
                    }

                    // non-corner edges
                    if (i == 0 && j != 0 && j != 19)
                    {
                        cells[i][j].addAdjacent(cells[i + 1][j]);
                        cells[i][j].addAdjacent(cells[i][j - 1]);
                        cells[i][j].addAdjacent(cells[i][j + 1]);

                        // map directions to neighbor indices
                        directionMap.Add("up", 2);
                        directionMap.Add("down", 1);
                        directionMap.Add("right", 0);
                    }

                    if (i == 19 && j != 0 && j != 19)
                    {
                        cells[i][j].addAdjacent(cells[i - 1][j]);
                        cells[i][j].addAdjacent(cells[i][j - 1]);
                        cells[i][j].addAdjacent(cells[i][j + 1]);

                        // map directions to neighbor indices
                        directionMap.Add("up", 2);
                        directionMap.Add("down", 1);
                        directionMap.Add("left", 0);
                    }

                    if (j == 0 && i != 0 && i != 19)
                    {
                        cells[i][j].addAdjacent(cells[i][j + 1]);
                        cells[i][j].addAdjacent(cells[i - 1][j]);
                        cells[i][j].addAdjacent(cells[i + 1][j]);

                        // map directions to neighbor indices
                        directionMap.Add("up", 0);
                        directionMap.Add("left", 1);
                        directionMap.Add("right", 2);
                    }

                    if (j == 19 && i != 0 && i != 19)
                    {
                        cells[i][j].addAdjacent(cells[i][j - 1]);
                        cells[i][j].addAdjacent(cells[i - 1][j]);
                        cells[i][j].addAdjacent(cells[i + 1][j]);

                        // map directions to neighbor indices
                        directionMap.Add("down", 0);
                        directionMap.Add("left", 1);
                        directionMap.Add("right", 2);
                    }
                }


                cells[i][j].setDirectionMap(directionMap);
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

        List<Cell> notConsidered = new List<Cell>();

        while (cells.Count != 0)
        {
            List<Cell> newList = new List<Cell>();
            // scan every cell in the list
            foreach (Cell cell_ in cells)
            {
                notConsidered.Add(cell_);

                List<Cell> neighbors = cell_.getAdjacent();

                // scan every neighbor of a cell from the list
                foreach (Cell n in neighbors)
                {
                    if (!n.isFree())
                    {
                        // if neighbor isn't free and hasn't already been traversed, it'll be in the new traversal list

                        if (!notConsidered.Contains(n) && !newList.Contains(n))
                            newList.Add(n);
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

            if (choice != null)
                break;

            cells = newList;
        }

        return choice;
    }
}
