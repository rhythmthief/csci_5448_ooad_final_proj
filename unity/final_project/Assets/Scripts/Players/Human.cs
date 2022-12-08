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
        hasSpawned = false;
        List<Unit> fighters = new List<Unit>(civ.getFighters());

        while (isTurn)
        {
            // Run the human's move portion of their turn
            // Possible clicks: up, down, right, left, enter (to skip move)
            foreach (Unit fighter in fighters)
            {
                Debug.Log("human moves units");

                // notify the observer about unit selection

                fighter.notifyObservers(new Event(3, fighter.getCell().getCoordinates(), fighter.getCell().getCoordinates(), new string[2]{"fighter", fighter.getUnitType()}, fighter.getCiv().getColor()));

                yield return promptMove(fighter);

                fighter.notifyObservers(new Event(4, fighter.getCell().getCoordinates(), fighter.getCell().getCoordinates(), new string[2]{"fighter", fighter.getUnitType()}, fighter.getCiv().getColor()));
            }

            // Run the human's spawning portion of their turn
            // TODO reference client to produce units
            if (hasSpawned == false)
            {
                Debug.Log("human spawns units");
                yield return waitForKeyPress(KeyCode.Space);
                hasSpawned = true;
                isTurn = false;
            }

            yield return null;
        }
    }

    private IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            if (Input.GetKeyDown(key))
            {
                done = true; // breaks the loop
            }
            // yield return null; // wait until next frame, then continue execution from here (loop continues)
            yield return null;
        }
        // now this function returns
    }

    private IEnumerator promptMove(Unit unit)
    {
        bool hasMoved = false;

        List<Cell> neighbors = unit.getCell().getAdjacent();

        while (!hasMoved)
        {
            Cell destination = unit.getCell();

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Pressed Up");
                hasMoved = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Pressed Right");
                hasMoved = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Pressed Left");
                hasMoved = true;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Pressed Down");
                hasMoved = true;
                // if (neighbors[3] != null && neighbors[3].isFree()) {
                //     destination = neighbors[3];
                //     unit.move(destination);
                //     hasMoved = true;
                // } else {
                //     Debug.Log("invalid move");
                // }
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Pressed Enter");
                hasMoved = true;
            }

            yield return null;
        }
    }

    public bool getTurnStatus()
    {
        return isTurn;
    }
}