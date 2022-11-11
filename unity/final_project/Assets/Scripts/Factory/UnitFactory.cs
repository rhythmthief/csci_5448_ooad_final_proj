using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory
{
    public Unit produce(string type, Civilization civ)
    {
        Unit unit = null;

        if (type == "city")
        {
            unit = new UnitCity();

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
                    unit = new UnitMelee();
                    break;
                case "ranged":
                    unit = new UnitRanged();
                    break;
                case "airborne":
                    unit = new UnitAirborne();
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
