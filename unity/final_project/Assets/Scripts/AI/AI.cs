using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI
{
    public void AITurnProcessor(GameBoard gameBoard, Civilization civ)
    {
        // copy all references as the original list will be modified during the turn
        // when units die
        List<Unit> fighters = new List<Unit>(civ.getFighters());

        // greedily attempt to move all units

        if (fighters.Count != 0)
            foreach (Unit fighter in fighters)
            {
                greedyMove(fighter);
            }

        string unitType = "";
        // produce a random unit
        switch (Random.Range(0, 3))
        {
            case 0: unitType = "melee"; break;
            case 1: unitType = "ranged"; break;
            case 2: unitType = "airborne"; break;
        }

        gameBoard.spawnUnit(civ, unitType);
    }


    /// <summary>
    /// Perform a greedy move with a fighter unit
    /// </summary>
    /// <param name="unit"></param>
    void greedyMove(Unit unit)
    {
        // heuristic: if an enemy is nearby, attack, otherwise move at random

        List<Cell> neighbors = unit.getCell().getAdjacent();
        bool fought = false;

        // scan every neighboring cell
        foreach (Cell n in neighbors)
        {
            // check if neighboring cell has a unit from another civ

            Unit potentialEnemy = n.getUnit(); // get adjacent cell's unit

            // there is somebody in the cell
            if (potentialEnemy != null)
            {
                if (potentialEnemy.getCiv() != unit.getCiv())
                {
                    // that unit is NOT a friend, so the AI attacks
                    unit.attack(potentialEnemy);
                    fought = true;
                    break;
                }
            }
        }

        if (!fought)
        {
            // the unit couldn't find any enemies and will attempt to make a move

            // NOTE
            // for now, set up to move at random, further playtesting will reveal if this is good enough
            // reasoning: units will not immediately go far away from the capital city and will likely spread around in the area

           // BFS to find the nearest enemy city
           // Get coordinates of the city, getCell().getCoordinates() 
           // Look at X and Z of the unit and the city
           // Between the possible moves, look for move that would get theirs and the city's coordinates closer

           // get location of the civilization's city
            Cell startingCell = unit.getCell();
            List<Cell> cells = new List<Cell>();
            cells.Add(startingCell);
            Unit choice = null;

            List<Cell> notConsidered = new List<Cell>();

            while (cells.Count != 0)
            {
                List<Cell> newList = new List<Cell>();
                // scan every cell in the list
                foreach (Cell cell_ in cells)
                {
                    notConsidered.Add(cell_);

                    List<Cell> neighbors2 = cell_.getAdjacent();

                    // scan every neighbor of a cell from the list
                    foreach (Cell n in neighbors2)
                    {
                        if (n.isFree() || n.getUnit() is not UnitCity || (n.getUnit() is UnitCity && n.getUnit().getCiv() == unit.getCiv()))
                        {
                            // if neighbor isn't free and hasn't already been traversed, it'll be in the new traversal list
                            
                            if (!notConsidered.Contains(n) && !newList.Contains(n))
                                newList.Add(n);
                        }
                        else
                        {
                            // if neighbor is free, we pick it and terminate
                            choice = n.getUnit();
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
            // now we know what the closest enemy city is
            // get coordinates for the city
            int[] cityCoords = choice.getCell().getCoordinates();
            int[] unitCoords = unit.getCell().getCoordinates();

            Cell destination = null;
            foreach (Cell n in unit.getCell().getAdjacent()) {
                // look through the cells and find which one will get it closer to the 
                if ((cityCoords[0] > unitCoords[0]) && (n.getCoordinates()[0] > unitCoords[0]) ) {
                    destination = n;
                    break;
                } else if ((cityCoords[2] > unitCoords[2]) && (n.getCoordinates()[2] > unitCoords[2])) {
                    destination = n;
                    break;
                }
                if ((cityCoords[0] < unitCoords[0]) && (n.getCoordinates()[0] < unitCoords[0]) ) {
                    destination = n;
                    break;
                } else if ((cityCoords[2] < unitCoords[2]) && (n.getCoordinates()[2] < unitCoords[2])) {
                    destination = n;
                    break;
                }
            }
            if (destination != null) {
                unit.move(destination);
            }
        
        }
    }
}