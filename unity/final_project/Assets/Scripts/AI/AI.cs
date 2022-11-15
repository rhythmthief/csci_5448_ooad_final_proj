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

            // scan every neighboring cell
            foreach (Cell n in neighbors)
            {
                // check if neighboring cell has a unit from another civ
                if (n.isFree())
                {
                    // 70% chance to move into the cell
                    if (Random.value < 0.9f)
                    {
                        unit.move(n);
                        break;
                    }
                }
            }
        }
    }
}