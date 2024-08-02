using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private List<IObserver> observers = new List<IObserver>();
    public int health;
    public int maxHealth = 100;

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

    public void ResetHealth()
    {
        Health = maxHealth;
        Notify();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
        }

        EnhancedLogger.Log("Took " + damage + " damage!", EnhancedLogger.LogLevel.Error);

        // Trigger the screen flash
        FindObjectOfType<DamageFlash>().Flash();

        //Shake Screen
        ScreenShaker._instance.TriggerShake(0.23f, .5f);
    }

    public void Heal(int amount)
    {
        Health += amount;
    }
}
