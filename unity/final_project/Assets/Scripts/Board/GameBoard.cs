using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    Cell[][] cells;
    List<Civilization> civs;

    public GameBoard()
    {
        // initialize the entire gameboard
        cells = Utils.generateBoard();
    }

    void Start()
    {
        MakeCube makeCube = GetComponent<MakeCube>();

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                makeCube.CreateCube(cells[i][j].getCoordinates());
            }
        }
    }

}
