using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float lifetime = 5f; // Time before the fireball is destroyed

    private void Start()
    {
        // Destroy the fireball after its lifetime
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Just to visualize the movement of fireballs, let’s check their position.
        // This will confirm if the fireball is moving towards the player
        Debug.Log("Fireball Position: " + transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Fireball collided with: " + collision.gameObject.name); // This should log when it hits anything
        
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Fireball hit the player!"); // This should appear if the fireball hits the player
            Player_FightMovement player = collision.GetComponent<Player_FightMovement>();
            if (player != null)
            {
                player.TakeDamage(10); // Inflict 10 damage
            }
            Destroy(gameObject); // Destroy the fireball
        }
    }
}
