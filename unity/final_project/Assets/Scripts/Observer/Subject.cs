using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject
{
    List<Observer> observers = new List<Observer>();

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

    public void registerObserver(Observer o)
    {
        observers.Add(o);
    }

    public void deregisterObserver(Observer o)
    {
        observers.Remove(o);
    }
}
