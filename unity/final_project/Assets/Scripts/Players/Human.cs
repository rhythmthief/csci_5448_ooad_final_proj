using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Human
{
    public IEnumerator TurnProcessor(GameBoard gameBoard, Civilization civ)
    {
        List<Unit> fighters = new List<Unit>(civ.getFighters());

        // prompt for move
        if (fighters.Count != 0)
            foreach (Unit fighter in fighters)
            {
                // TODO add UI for highlighting fighters
                // fighter.highlight();
                Debug.Log("human moves units");
                yield return waitForKeyPress(KeyCode.Space);
            }

        // prompt for unit production
        // TODO reference client to produce units
        Debug.Log("human spawns units");
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
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }
    
        // now this function returns
    }
}