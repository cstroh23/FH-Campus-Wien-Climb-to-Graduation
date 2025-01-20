using UnityEngine;

public class EnergyDrink : MonoBehaviour
{
    public int healthRestoreAmount = 30; // Amount of health restored when collected

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is tagged as "Player"
        if (collision.CompareTag("Player"))
        {
            // Access the Player_FightMovement component on the player
            Player_FightMovement player = collision.GetComponent<Player_FightMovement>();
            if (player != null)
            {
                // Restore health to the player
                player.HealPlayer(healthRestoreAmount);
            }

            // Destroy the energy drink after it is collected
            Destroy(gameObject);
        }
    }
}
