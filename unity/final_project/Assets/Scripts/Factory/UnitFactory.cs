using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory
{
    public Unit produce(string type, Civilization civ, Cell cell_, GraphicsObserver graphicsObserver_)
    {
        Unit unit = null;

        if (type == "city")
        {
            unit = new UnitCity(civ, cell_, graphicsObserver_);

            if (civ is CivilizationConqueror)
            {
                unit.setHP(375);
            }
            else if (civ is CivilizationDefender)
            {
                unit.setHP(1000);
                unit.setDamage(40);
            }
        }
        else
        {
            switch (type)
            {
                case "melee":
                    unit = new UnitMelee(civ, cell_, graphicsObserver_);
                    break;
                case "ranged":
                    unit = new UnitRanged(civ, cell_, graphicsObserver_);
                    break;
                case "airborne":
                    unit = new UnitAirborne(civ, cell_, graphicsObserver_);
                    break;
            }

            if (civ is CivilizationBarbarian)
            {
                unit.setHP(70);
            }
        }

        return unit;
    }
}
