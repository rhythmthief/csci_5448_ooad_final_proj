using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human
{
    bool isTurn = false;
    bool hasSpawned = false;

    public IEnumerator TurnProcessor(GameBoard gameBoard, Civilization civ)
    {
        isTurn = true;
        List<Unit> fighters = new List<Unit>(civ.getFighters());

        while (isTurn)
        {
            // Run the human's move portion of their turn
            // Possible clicks: up, down, right, left, enter (to skip move)
            foreach (Unit fighter in fighters)
            {
                Debug.Log("human moves units");

                // notify the observer about unit selection

                fighter.notifyObservers(new Event(3, fighter.getCell().getCoordinates(), fighter.getCell().getCoordinates(), new string[2] { "fighter", fighter.getUnitType() }, fighter.getCiv().getColor()));

                yield return promptMove(fighter);

                fighter.notifyObservers(new Event(4, fighter.getCell().getCoordinates(), fighter.getCell().getCoordinates(), new string[2] { "fighter", fighter.getUnitType() }, fighter.getCiv().getColor()));
            }

            // Run the human's spawning portion of their turn
            Debug.Log("human spawns units");

            yield return promptSpawn(gameBoard, civ);
            isTurn = false;

            yield return null;
        }
    }

    private IEnumerator promptMove(Unit unit)
    {
        bool hasMoved = false;

        while (!hasMoved)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                hasMoved = attemptDirectionalAction(unit, "up");
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                hasMoved = attemptDirectionalAction(unit, "right");
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                hasMoved = attemptDirectionalAction(unit, "left");
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                hasMoved = attemptDirectionalAction(unit, "down");
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Pressed Enter");
                hasMoved = true;
            }

            yield return null;
        }
    }

    private IEnumerator promptSpawn(GameBoard gameBoard, Civilization civ)
    {
        bool hasSpawned = false;

        if (civ.canProduceUnit())
            while (!hasSpawned)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    gameBoard.spawnUnit(civ, "melee");
                    hasSpawned = true;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    gameBoard.spawnUnit(civ, "ranged");
                    hasSpawned = true;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    gameBoard.spawnUnit(civ, "airborne");
                    hasSpawned = true;
                }
                else if (Input.GetKeyDown(KeyCode.Return))
                {
                    hasSpawned = true;
                }
                yield return null;
            }
    }

    public bool getTurnStatus()
    {
        return isTurn;
    }


    private bool attemptDirectionalAction(Unit unit, string direction)
    {
        Dictionary<string, int> directionMap = unit.getCell().getDirectionMap();
        Cell destination = null;
        bool hasMoved = false;

        // check if the cell has something in the specified direction
        if (directionMap.ContainsKey(direction))
        {

            // retrieve destination cell
            destination = unit.getCell().getAdjacent()[directionMap[direction]];

            // if the cell is empty, move into it
            if (destination.isFree())
            {
                unit.move(destination);
                hasMoved = true;
            }
            else
            {
                // get the unit that's in the destination cell
                Unit destinationUnit = destination.getUnit();

                // if the cell contains a non-enemy unit, do nothing
                if (unit.getCiv() != destinationUnit.getCiv())
                {
                    // if the cell contains an enemy, fight
                    unit.attack(destinationUnit);
                    hasMoved = true;
                }
            }
        }

        return hasMoved;
    }
}