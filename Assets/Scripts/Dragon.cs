using UnityEngine;

public class Dragon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Prüfen, ob die Bullet den Dragon trifft
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("Dragon hit by a bullet!");

            // Deaktiviere oder zerstöre den Dragon
            Destroy(gameObject);

            // Optional: Bullet deaktivieren oder in den Pool zurückgeben
            collision.gameObject.SetActive(false);
        }
    }
}
