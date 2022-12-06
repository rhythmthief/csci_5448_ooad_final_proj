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
            // prompt for move
            foreach (Unit fighter in fighters)
            {
                // TODO add UI for highlighting fighters
                // fighter.highlight();
                // Debug.Log("human moves units");
                // yield return waitForKeyPress(KeyCode.Space);
            }

            // prompt for unit production
            // TODO reference client to produce units
            
            if (hasSpawned == false) 
            {
                Debug.Log("human spawns units");
                yield return waitForKeyPress(KeyCode.Space);
                hasSpawned = true;
                isTurn = false;
            }
            
            // fuck it button

            yield return null;
        }
        
        
    }

    private IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;
        while(!done) // essentially a "while true", but with a bool to break out naturally
        {
            if(Input.GetKeyDown(key))
            {
                done = true; // breaks the loop
            }
            // yield return null; // wait until next frame, then continue execution from here (loop continues)
            yield return null;
        }
        // now this function returns
    }

    public bool getTurnStatus()
    {
        return isTurn;
    }
}