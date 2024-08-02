using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private List<IObserver> observers = new List<IObserver>();
    private int health;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            Notify();
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in observers)
        {
            observer.UpdateObserver();
        }
    }

    // Example method to change health
    public void TakeDamage(int damage)
    {
        Health -= damage;

        
    }

    public void Heal(int amount)
    {
        Health += amount;
    }
}
