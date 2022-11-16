using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : Subject
{
    protected int damage = 30;
    protected int hp = 100;
    protected bool alive = true;
    protected bool turnComplete = false;

    protected Cell cell; // location of the unit

    protected MoveBehavior mb;
    protected CombatBehavior cb;
    protected Civilization civ;

    protected string type;

    public void reduceHP(int reduction)
    {
        hp -= reduction;
        computeAlive();

        if (!alive)
        {
            notifyObservers(new Event(2, null, cell.getCoordinates(), new string[2]{"fighter", type}, new Color())); // unit died, notify observers
            

            if (this is not UnitCity) {
                civ.removeFighter(this);
            } else {
                civ.removeCity();
            }
            cell.setUnit(null); // vacate the cell this unit was in
        }
    }

    public void attack(Unit target) => cb.attack(this, target);
    public void move(Cell cell_) => mb.move(this, cell_);
    void computeAlive() => alive = hp < 1 ? false : true;
    public int getDamage() => damage;
    public Civilization getCiv() => civ;
    public string getUnitType() => type;
    public void setHP(int hp_) => hp = hp_;
    public void setDamage(int damage_) => damage = damage_;
    public Cell getCell() => cell;
    public void setCell(Cell cell_) => cell = cell_;
    public bool isTurnComplete() => turnComplete;
    public void flipTurnComplete() => turnComplete = !turnComplete;
}
