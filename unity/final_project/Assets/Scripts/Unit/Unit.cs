using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : Subject
{
    protected int damage = 30;
    protected int hp = 100;
    protected bool alive = true;

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
            civ.removeFighter(this);
            notifyObservers(new Event(1, null,  null, null)); // unit died, notify observers
        }
    }

    void attack(Unit target) => cb.attack(this, target);
    void computeAlive() => alive = hp < 1 ? false : true;
    public int getDamage() => damage;
    public Civilization getCiv() => civ;
    public string getUnitType() => type;
    public void setHP(int hp_) => hp = hp_;
    public void setDamage(int damage_) => damage = damage_;
    public Cell getCell() => cell;
}
