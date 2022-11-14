using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject
{
    List<Observer> observers;


    /// <summary>
    /// Notify all observers of this subject
    /// </summary>
    /// <param name="e">Notification event</param>
    public void notifyObservers(Event e)
    {
        foreach (Observer o in observers)
        {
            o.update(e);
        }
    }

    void registerObservers(Observer o)
    {
        observers.Add(o);
    }

    void deregisterObservers(Observer o)
    {
        observers.Remove(o);
    }
}
