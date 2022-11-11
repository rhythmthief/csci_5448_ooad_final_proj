using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCity : Unit
{
    public UnitCity() 
    {
        damage = 0;
        hp = 0;
        mb = new MoveStationary();
    }
}
