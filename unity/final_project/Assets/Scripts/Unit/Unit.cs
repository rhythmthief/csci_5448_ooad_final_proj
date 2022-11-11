using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit
{
    protected int damage = 30;
    protected int hp = 100;
    protected bool alive = true;

    protected MoveBehavior mb;
    protected CombatBehavior cb;

    void attack(Unit target) {
        cb.attack(this, target);
    }

    public void reduceHP(int reduction) 
    {
        hp -= reduction;
        checkAlive();
    }

    void checkAlive() 
    {
        if (hp < 1) {
            alive = false;
        }
    }

    public int getDamage() 
    {
        return damage;
    }
}
