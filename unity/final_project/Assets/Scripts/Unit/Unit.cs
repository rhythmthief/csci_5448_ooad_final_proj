using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : Subject
{
    protected int damage = 30;
    protected int hp = 100;
    protected bool alive = true;

    protected MoveBehavior mb;
    protected CombatBehavior cb;
    protected Civilization civ;

    protected string type;

    void attack(Unit target)
    {
        cb.attack(this, target);
    }

    public void reduceHP(int reduction)
    {
        hp -= reduction;
        checkAlive();
    }

    void checkAlive()
    {
        if (hp < 1)
        {
            alive = false;
        }
    }

    public int getDamage()
    {
        return damage;
    }

    public Civilization getCiv()
    {
        return civ;
    }

    public string getUnitType()
    {
        return type;
    }

    public void setHP(int hp_)
    {
        hp = hp_;
    }

    public void setDamage(int damage_)
    {
        damage = damage_;
    }
}
