using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard
{
    Cell[][] cells; // actual game board cells, also linked internally into a graph
    List<Civilization> civs = new List<Civilization>();
    UnitFactory unitFactory = new UnitFactory();
    CivFactory civFactory = new CivFactory();
    GraphicsObserver graphicsObserver;

    public GameBoard(string playerCivSelection_)
    {
        graphicsObserver = GraphicsObserver.getGraphicsObserver();

        // initialize the entire gameboard
        cells = Utils.generateBoard(graphicsObserver);

        // add 4 civilizations
        civs.Add(civFactory.produce(playerCivSelection_, Color.magenta));
        civs.Add(civFactory.produce("barbarian", Color.red));
        civs.Add(civFactory.produce("conqueror", Color.cyan));
        civs.Add(civFactory.produce("defender", Color.green));

        // give civilizations their new cities
        civs[0].setCity(unitFactory.produce("city", civs[0], cells[2][2], graphicsObserver));
        civs[1].setCity(unitFactory.produce("city", civs[1], cells[2][17], graphicsObserver));
        civs[2].setCity(unitFactory.produce("city", civs[2], cells[17][17], graphicsObserver));
        civs[3].setCity(unitFactory.produce("city", civs[3], cells[17][2], graphicsObserver));

        // first civ is the player civ
        civs[0].setPlayerCiv();
    }

    public Civilization getCiv(int index) {
        return civs[index];
    }

    public void spawnUnit(Civilization civ, string type)
    {
        Cell cell = Utils.findSpawnLocation(civ);

        // ensure that we were able to find a new spawn location for the unit
        if (cell != null)
            unitFactory.produce(type, civ, cell, graphicsObserver);

    }

    public Cell[][] getCells() => cells;

    public List<Civilization> getCivilizations() => civs;
}
