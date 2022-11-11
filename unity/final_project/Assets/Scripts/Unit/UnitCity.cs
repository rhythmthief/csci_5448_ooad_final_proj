using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCity : Unit
{
    public UnitCity() 
    {
        damage = 20;
        hp = 500;
        mb = new MoveStationary();
    }
}
