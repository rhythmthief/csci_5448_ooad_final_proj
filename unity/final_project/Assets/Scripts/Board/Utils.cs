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
}