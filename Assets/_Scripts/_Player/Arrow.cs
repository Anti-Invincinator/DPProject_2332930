using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Tooltip("Lesser the value, more the deceleration")]
    public float decelerationRate = 0.25f; // Deceleration rate per second
    public float minSpeed = 0.5f; // Minimum speed before stopping

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Apply deceleration to the arrow's velocity
        if (rb.velocity.magnitude > minSpeed)
        {
            rb.velocity *= Mathf.Pow(decelerationRate, Time.fixedDeltaTime);
        }
        else
        {
            // Stop the arrow by setting velocity to zero
            rb.velocity = Vector2.zero;
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Kills the enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnhancedLogger.Log("Enemy Killed !", EnhancedLogger.LogLevel.Info);

            other.gameObject.SetActive(false);
            other.gameObject.GetComponent<Enemy>().SplatterBlood();
            other.gameObject.GetComponent<Enemy>().SpawnKnivesPickup();
            this.gameObject.SetActive(false);
        }
    }
}
