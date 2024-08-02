using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifePickup : MonoBehaviour
{
    public int arrowAmount = 1; // Amount of arrows to add to the quiver

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Quiver playerQuiver = other.GetComponent<Quiver>();
            if (playerQuiver != null)
            {
                playerQuiver.AddArrows(arrowAmount);
                Destroy(gameObject); // Destroy the arrow pickup

                EnhancedLogger.Log("Added " + arrowAmount + " to Quiver!", EnhancedLogger.LogLevel.Warning);
            }
        }
    }
}
