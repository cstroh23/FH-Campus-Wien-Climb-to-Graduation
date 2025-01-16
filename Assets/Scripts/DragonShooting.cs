using UnityEngine;
using System.Collections;

public class DragonShooting : MonoBehaviour
{
    public Transform firePoint; // The point where the fireballs spawn
    public GameObject fireballPrefab; // The fireball prefab
    public float fireRate = 2f; // Time between shots
    public float fireballSpeed = 5f; // Speed of the fireballs

    private float nextFireTime = 0f; // Tracks when the dragon can fire next

    private Transform player; // Reference to the player

    private void Start()
    {
        // Find the player by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the Player GameObject has the 'Player' tag.");
        }
    }

    private void Update()
    {
        // Check if it's time to fire and if the player exists
        if (Time.time >= nextFireTime && player != null)
        {
            ShootAtPlayer();
            nextFireTime = Time.time + fireRate; // Schedule the next shot
        }
    }

private void ShootAtPlayer()
{
    if (firePoint != null && fireballPrefab != null)
    {
        // Instantiate the fireball
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);

        // Calculate direction towards the player
        Vector2 direction = (player.position - firePoint.position).normalized;

        // Set the fireball's velocity
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * fireballSpeed;
        }

        // Rotate the fireball to face the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply rotation and flip the fireball if needed
        fireball.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Flip the fireball horizontally (if it's pointing backwards)
        
        fireball.transform.localScale = new Vector3(-1, 1, 1);  // Flip horizontally

        Debug.Log("Dragon fired a fireball!");
    }
}


}
