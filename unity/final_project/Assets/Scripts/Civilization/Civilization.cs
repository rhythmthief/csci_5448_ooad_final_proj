using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Civilization
{
    protected string name;
    protected int productionCooldown = 3;
    protected Unit city;
    protected List<Unit> fighters;


    /// <summary>
    /// Get the civilization's capital city
    /// </summary>
    /// <returns>city</returns>
    public Unit getCity() => city;
}
