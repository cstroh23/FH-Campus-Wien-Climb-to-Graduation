using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f; // Geschwindigkeit der Bullet
    public float lifetime = 2f;    // Lebensdauer der Bullet

    private void OnEnable()
    {
        // Starte die Lebensdauer der Bullet
        Invoke(nameof(Deactivate), lifetime);

        // Ignore collision between the bullet and the player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Collider2D bulletCollider = GetComponent<Collider2D>();
            Collider2D playerCollider = player.GetComponent<Collider2D>();

            // Ignore collision between the bullet and the player
            if (bulletCollider != null && playerCollider != null)
            {
                Physics2D.IgnoreCollision(bulletCollider, playerCollider, true);
            }
        }
    }

    private void Update()
    {
        // Bewege die Bullet nach oben
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    private void Deactivate()
    {
        // Deaktiviert die Bullet, anstatt sie zu zerstören
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // Lösche den Deaktivierungsaufruf, um Konflikte zu vermeiden
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bullet collided with: " + collision.gameObject.name); // Log the collision

        // Destroy the bullet when it hits anything (if you want this)
        Destroy(gameObject);
    }
}
