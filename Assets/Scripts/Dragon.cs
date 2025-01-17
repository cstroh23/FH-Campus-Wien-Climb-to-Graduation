using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Dragon : MonoBehaviour
{
    private static int hitCounter = 0; // Counter to track bullet hits
    public string homeSceneName = "HomeScene"; // Name of the scene to load

    public Transform firePoint; // Point where bullets spawn
    public float fireRate = 2f; // Time between shots
    private BulletPool bulletPool; // Reference to the BulletPool

    private Transform player; // Reference to the player's Transform
    private bool isShooting; // Prevents shooting while already shooting

    private void Start()
    {
        // Find the player in the scene
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found! Ensure the Player GameObject has the 'Player' tag.");
        }

        // Reference to the bullet pool
        bulletPool = Object.FindFirstObjectByType<BulletPool>();
        if (bulletPool == null)
        {
            Debug.LogError("BulletPool not found! Ensure it exists in the scene.");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with a bullet
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("Dragon hit by a bullet!");

            // Deactivate or destroy the dragon
            Destroy(gameObject);

            // Optional: Deactivate or return the bullet to the pool
            collision.gameObject.SetActive(false);

            // Increment the hit counter
            hitCounter++;
        }
    }
    public int getHitCounter() {
        //Debug.Log("The current hitCounter: " + hitCounter);
        return hitCounter;
    }
}
