using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivFactory
{
    /// <summary>
    /// Adds a new civilization to the game with a given capital city cell
    /// </summary>
    /// <param name="type"></param>
    /// <param name="cell_"></param>
    /// <returns></returns>
    public Civilization produce(string type, Color color_)
    {
        Civilization civ = null;

        switch (type)
        {
            case "barbarian":
                civ = new CivilizationBarbarian();
                break;

            case "conqueror":
                civ = new CivilizationConqueror();
                break;

            case "defender":
                civ = new CivilizationDefender();
                break;
        }

        civ.setCivColor(color_);

        return civ;
    }
}
