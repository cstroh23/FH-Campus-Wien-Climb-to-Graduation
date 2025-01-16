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
    private float nextFireTime = 0f; // Time tracking for fire rate

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

    private void Update()
    {
        // Shoot at the player periodically
        if (Time.time >= nextFireTime && !isShooting && player != null)
        {
            StartCoroutine(ShootAtPlayer());
            nextFireTime = Time.time + fireRate; // Update fire timer
        }
    }

    private IEnumerator ShootAtPlayer()
    {
        isShooting = true;

        // Get a bullet from the pool
        GameObject bullet = bulletPool.GetBullet();
        if (bullet != null && firePoint != null)
        {
            // Set bullet's position and direction
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = Quaternion.identity;

            // Calculate direction towards the player
            Vector2 direction = (player.position - firePoint.position).normalized;

            // Apply velocity to the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = direction * 5f; // Adjust bullet speed as needed
            }

            Debug.Log("Dragon fired a bullet!");
        }
        else
        {
            Debug.LogError("Bullet or FirePoint is missing!");
        }

        // Wait briefly to simulate a shooting animation if needed
        yield return new WaitForSeconds(0.2f);

        isShooting = false;
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

            // Check if the hit counter has reached 7
            if (hitCounter >= 7)
            {
                Debug.Log("Hit counter reached 7! Loading HomeScene...");
                SceneManager.LoadScene(homeSceneName);
            }
        }
    }
}
