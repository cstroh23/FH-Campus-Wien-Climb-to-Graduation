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
    private int count;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip attackSound;

    private void Start()
    {
        hitCounter=0;

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


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("Dragon hit by a bullet!");
            StartCoroutine(HandleDragonHit(collision)); // Coroutine starten
        }
    }

    private IEnumerator HandleDragonHit(Collider2D collision) {
        // 1. Sound abspielen
        if (attackSound != null && audioSource != null)
        {
            Debug.Log("Trying to play audio");
            audioSource.PlayOneShot(attackSound);
        }
        else
        {
            Debug.Log("Audio could not be played");
        }

        collision.gameObject.SetActive(false);

        // 2. Warte 3 Sekunden, bevor der Drache zerstört wird
        yield return new WaitForSeconds(3f);

        // 3. Danach den Drachen zerstören
        Destroy(gameObject);
        
        hitCounter++;
        Debug.Log("Current hit counter: " + hitCounter);
    }

    public int getHitCounter() {
        //Debug.Log("The current hitCounter: " + hitCounter);
        return hitCounter;
    }
}
