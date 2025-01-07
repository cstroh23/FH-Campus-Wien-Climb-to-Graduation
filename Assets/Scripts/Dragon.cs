using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class Dragon : MonoBehaviour
{
    private static int hitCounter = 0; // Counter to track bullet hits
    public string homeSceneName = "HomeScene"; // Name of the scene to load

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

            // Check if the hit counter has reached 6
            if (hitCounter >= 7)
            {
                Debug.Log("Hit counter reached 6! Loading HomeScene...");
                SceneManager.LoadScene(homeSceneName);
            }
        }
    }
}
