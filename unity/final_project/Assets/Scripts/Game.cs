using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    GameSettings GS = GameSettings.getGameSettings();

    void Start()
    {
        // set graphic observer's graphicsfactory reference
        GraphicsObserver.getGraphicsObserver().setGraphicsFactory(GetComponent<GraphicsFactory>());

        GS.setPlayerCivSelection("barbarian");
        GameBoard gameBoard = new GameBoard(GS.getPlayerCivSelection());

        // configure the client and assign it to button logic
        Client client = new Client(gameBoard);
        transform.GetChild(0).GetComponent<CreateButtonLogic>().setClient(client);

        //GraphicsFactory graphicsFactory = GetComponent<GraphicsFactory>();
        //Cell[][] cells = gameBoard.getCells();

        // for (int i = 0; i < 20; i++)
        // {
        //     for (int j = 0; j < 20; j++)
        //     {
        //         graphicsFactory.CreateCube(cells[i][j].getCoordinates());
        //     }
        // }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
