using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Civilization
{
    protected string name;
    protected int productionCooldown = 3;
    protected Unit city;
    protected List<Unit> fighters = new List<Unit>();
    protected bool playerCiv = false;
    protected Color civColor;
    protected int currentCooldown;


    /// <summary>
    /// Get the civilization's capital city
    /// </summary>
    /// <returns>city</returns>
    public Unit getCity() => city;

    /// <summary>
    /// Add a new unit to the civilization's fighter roster
    /// </summary>
    /// <param name="unit_">New unit</param>
    public void addFighter(Unit unit_) => fighters.Add(unit_);

    /// <summary>
    /// Remove a unit from the civilization's fighter roster
    /// </summary>
    /// <param name="unit_"></param>
    public void removeFighter(Unit unit_) => fighters.Remove(unit_);

    /// <summary>
    /// Set civilization's capital city
    /// </summary>
    /// <param name="city_"></param>
    public void setCity(Unit city_) => city = city_;

    /// <summary>
    /// Designates this civilization as the player civ
    /// </summary>
    public void setPlayerCiv() => playerCiv = true;

    /// <summary>
    /// Return true if this civilization is player-controlled
    /// </summary>
    /// <returns></returns>
    public bool isPlayerCiv() => playerCiv;

    /// <summary>
    /// Set a new color for this civ
    /// </summary>
    /// <param name="color_"></param>
    public void setCivColor(Color color_) => civColor = color_;

    public List<Unit> getFighters() => fighters;
    public Color getColor() => civColor;
    public void removeCity() => city = null;
    
    public void defeat() {
       List<Unit> fighters_ = new List<Unit>(fighters);

        foreach (Unit fighter in fighters_)
        {
            // make every unit despawn
            fighter.reduceHP(1000);
        }
    }
}
