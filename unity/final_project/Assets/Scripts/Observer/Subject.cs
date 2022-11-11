using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject
{
    List<Observer> observers;

    void notifyObservers(Event e)
    {
        foreach (Observer o in observers)
        {
            o.update(e);
        }
    }
}
