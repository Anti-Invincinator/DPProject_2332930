using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minSpeed = 2.5f;
    public float maxSpeed = 4.5f;
    private float speed;
    public Transform player;
    public int damage = 20;

    public GameObject bloodSplatterPrefab; // Reference to the blood splatter prefab
    public GameObject knifeDropPrefab; // Referece to the knife drop


    void Start()
    {
        // Set a random speed within the specified range
        speed = Random.Range(minSpeed, maxSpeed);
        player = PlayerController._instance.transform;

    }

    void Update()
    {
        if (player != null)
        {
            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            // Face the player
            Vector2 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); // Adjust the angle as needed
        }
    }

    public void SplatterBlood()
    {
        var pos = new Vector3(transform.position.x, transform.position.y, 0.5f);
        // Instantiate blood splatter
        Instantiate(bloodSplatterPrefab, pos, Quaternion.identity);
    }

    public void SpawnKnivesPickup()
    {
        // Instantiate arrow drop
        Instantiate(knifeDropPrefab, transform.position, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deal damage to the player
            PlayerController._instance.GetComponent<PlayerHealth>().TakeDamage(damage);

            // Return to Object Pool
            this.gameObject.SetActive(false);
        }
    }
}
