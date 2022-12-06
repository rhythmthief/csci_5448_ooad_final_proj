using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // game settings
    GameSettings GS = GameSettings.getGameSettings();
    GameBoard gameBoard;

    void Start()
    {
        MonoHelper monoHelper = transform.GetComponent<MonoHelper>();

        // set graphic observer's graphicsfactory reference
        GraphicsObserver.getGraphicsObserver().setupGraphicsObserver(GetComponent<GraphicsFactory>(), monoHelper);

        GS.setPlayerCivSelection("barbarian");
        gameBoard = new GameBoard(GS.getPlayerCivSelection());

        // configure the client and assign it to button logic
        Client client = new Client(gameBoard);
        transform.GetChild(0).GetComponent<CreateButtonLogic>().setClient(client);

        // start the game loop
        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop()
    {
        AI ai = new AI();
        Human human = new Human();
        List<Civilization> civs = gameBoard.getCivilizations();

        while (true)
        {
            List<Civilization> civs_ = new List<Civilization>(civs);

            

            // process turns for all civs
            foreach (Civilization civ in civs_)
            {
                if (civ.getCity() == null)
                {
                    // civ's city has been destroyed
                    civ.defeat();
                    civs.Remove(civ);
                }
                else
                {
                    // civ is still active and stays in the game
                    if (civ.isPlayerCiv())
                    {
                        // process turn for the player
                        StartCoroutine(human.TurnProcessor(gameBoard, civ));
                        while (human.getTurnStatus())
                            yield return new WaitForSeconds(0.25f);
                    }
                    else
                    {
                        // process turn for the AI
                        ai.AITurnProcessor(gameBoard, civ);
                    }
                }
                
                // wait for 1 second
                yield return new WaitForSeconds(0.25f);
            }

            

            // TODO check for end game conditions
                // TODO display the win or lose screen
        }
        
        
    }

}
