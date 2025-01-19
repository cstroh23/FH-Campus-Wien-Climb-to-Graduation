using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Player_FightMovement : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private bool isShooting;
    private float inputX;

    public int maxHealth = 100;      // Max health of the player
    public int currentHealth;        // Current health of the player

    public HealthBar healthBar;      // Reference to the health bar

    public Transform bulletSpawnPoint; // Punkt, an dem die Bullet spawnt
    private BulletPool bulletPool;     // Referenz zum Bullet-Pool

    private Animator animator;
    private SpriteRenderer spriteRenderer;  // Für visuelles Feedback
    [SerializeField] GameObject chatpt;
    [SerializeField] GameObject lockin;

    private bool isInvincible = false;  // Ob der Spieler unverwundbar ist
    private bool canUseShieldAbility = true;  // Ob die Schutzfähigkeit verfügbar ist
    private bool isSpeedBoosted = false;  // Ob der Spieler den Geschwindigkeitsboost hat
    private bool canUseSpeedAbility = true;  // Ob die Geschwindigkeitsfähigkeit verfügbar ist

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Holt den SpriteRenderer für visuelles Feedback
        bulletPool = Object.FindFirstObjectByType<BulletPool>(); // Hole den Bullet-Pool
    }

    private void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.setHealth(maxHealth);
    }

    private void Update()
    {
        // Bewegung
        if (!isShooting)
        {
            if (!isMoving)
            {
                inputX = Input.GetAxisRaw("Horizontal");

                if (inputX != 0)
                {
                    animator.SetFloat("moveX", inputX);

                    var targetPos = transform.position;
                    targetPos.x += inputX;

                    StartCoroutine(Move(targetPos)); // Bewege den Spieler
                }
            }
            animator.SetBool("isMoving", isMoving);
        }

        // Schießen
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Shoot());
        }

        // Schutz-Funktion aktivieren
        if (Input.GetKeyDown(KeyCode.C) && canUseShieldAbility)
        {
            StartCoroutine(ActivateShield());
        }

        // Geschwindigkeitsboost aktivieren
        if (Input.GetKeyDown(KeyCode.V) && canUseSpeedAbility)
        {
            StartCoroutine(ActivateSpeedBoost());
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return; // Schaden ignorieren, wenn unverwundbar

        // Reduce player's health
        currentHealth -= damage;

        // Update health bar
        healthBar.setHealth(currentHealth);

        // Check if health is 0 or below
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        // SceneManager.LoadScene("HomeScene"); // Main Menu Szene laden
        // Add death logic (e.g., reload scene, show game over screen, etc.)
    }

    private IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos; // Setze die Position exakt
        isMoving = false;
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        animator.SetBool("isShooting", true);

        // Warte, bis die Animation abläuft
        yield return new WaitForSeconds(0.2f);

        animator.SetBool("isShooting", false);

        // Bullet aus dem Pool holen und positionieren
        GameObject bullet = bulletPool.GetBullet();
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.transform.rotation = Quaternion.identity;

        isShooting = false;
    }

    // Unverwundbarkeits-Funktion
    private IEnumerator ActivateShield()
    {
        isInvincible = true;   // Spieler unverwundbar machen
        canUseShieldAbility = false; // Fähigkeit auf Cooldown setzen
        chatpt.SetActive(false);
        Debug.Log("Unverwundbarkeit aktiviert!");

        // Visuelles Feedback: Blinken
        for (int i = 0; i < 10; i++)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled; // Sprite an/aus
            yield return new WaitForSeconds(0.25f); // Blinkt 10-mal (5 Sekunden lang)
        }
        spriteRenderer.enabled = true;

        isInvincible = false;  
        Debug.Log("Unverwundbarkeit vorbei!");

        yield return new WaitForSeconds(5f); // Weitere 5 Sekunden warten (insgesamt 10s Cooldown)
        canUseShieldAbility = true;
        chatpt.SetActive(true);
        Debug.Log("Schutzfähigkeit wieder einsatzbereit!");
    }

    // Geschwindigkeitsboost-Funktion
    private IEnumerator ActivateSpeedBoost()
    {
        isSpeedBoosted = true;   // Geschwindigkeit erhöhen
        moveSpeed *= 2;          // Verdoppeln der Geschwindigkeit
        canUseSpeedAbility = false; // Fähigkeit auf Cooldown setzen
        lockin.SetActive(false);
        Debug.Log("Geschwindigkeitsboost aktiviert!");

        yield return new WaitForSeconds(5f); // 5 Sekunden lang boosten

        moveSpeed /= 2;          // Geschwindigkeit zurücksetzen
        isSpeedBoosted = false;
        Debug.Log("Geschwindigkeitsboost vorbei!");

        yield return new WaitForSeconds(5f); // Weitere 5 Sekunden warten (insgesamt 10s Cooldown)
        canUseSpeedAbility = true;
        lockin.SetActive(true);
        Debug.Log("Geschwindigkeitsfähigkeit wieder einsatzbereit!");
    }
}
