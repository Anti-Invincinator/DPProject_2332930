using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiver : MonoBehaviour
{
    public int maxArrows = 10;
    private int currentArrows;

    void Start()
    {
        currentArrows = maxArrows;
    }

    public bool HasArrows()
    {
        return currentArrows > 0;
    }

    public void UseArrow()
    {
        if (currentArrows > 0)
        {
            currentArrows--;
        }
    }

    public void AddArrows(int amount)
    {
        currentArrows += amount;
        if (currentArrows > maxArrows)
        {
            currentArrows = maxArrows; // Ensure we don't exceed the max arrows
        }
    }

    public void RefillArrows()
    {
        currentArrows = maxArrows;
    }

    public int GetCurrentArrows()
    {
        return currentArrows;
    }
}
