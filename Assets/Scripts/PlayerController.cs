using UnityEngine;
using UnityEngine.SceneManagement; // Für Szenenwechsel
using System.Collections;
using Unity.Multiplayer.Center.Common.Analytics; // Für IEnumerator

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // Bewegungsgeschwindigkeit des Spielers
    private bool isMoving; // Überprüfen, ob der Spieler sich bewegt
    private Vector2 input; // Eingaben des Spielers
    public int maxHealth = 100;      // Max health of the player
    public HealthBar healthBar;     // Reference to the health bar
    private int currentHealth;      // Current health of the player
    private bool canExecute = true; // Kontrollvariable

    private Animator animator; // Animator für Bewegungsanimationen
    public LayerMask solidObjectsLayer; // Layer für Hindernisse
    public LayerMask interactableLayer;
    public LayerMask damageObjectsLayer;
    [SerializeField] GameObject dialogBox;
    [SerializeField] GameObject dialogBoxEnd;

    private void Awake()
    {
        animator = GetComponent<Animator>(); // Animator initialisieren
    }

     private void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); // Set the health bar's max value
    }

    public void HandleUpdate()
    {
        if (Time.timeScale == 0f) return; // Bewegung stoppen, wenn pausiert

        if (!isMoving)
        {
            // Spielerbewegung steuern
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0; // Diagonale Bewegungen verhindern

            if (input != Vector2.zero)
            {
                // Animationsparameter setzen
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                // Zielposition berechnen
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                // Bewegung starten, wenn der Zielort begehbar ist
                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown(KeyCode.E))
            dialogBox.SetActive(false);
            Interact();
    }

    void Interact() {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if (collider != null) {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    private IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        // Spieler zur Zielposition bewegen
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos; // Genaues Positionieren am Zielort
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        // Überprüfen, ob Zielposition begehbar ist
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer) != null) {
            return false;
        } else if (Physics2D.OverlapCircle(targetPos, 0.2f, damageObjectsLayer) != null) {
            if (canExecute) {
                Debug.Log("Player gets Damage");
                currentHealth = (int)healthBar.getHealth() - 5;
                healthBar.setHealth(currentHealth);
                StartCoroutine(DelayFunction()); // start waiting time
            } else {
                Debug.Log("Waiting time to damage again.");
            }
            if (healthBar.getHealth()==0) {
                dialogBoxEnd.SetActive(true);
                 if (Input.GetKeyDown(KeyCode.F)) {
                    dialogBoxEnd.SetActive(false);
                    SceneManager.LoadScene("HomeScene");
                 }
            }
            return false;
        }else {return true;}
    }
     private IEnumerator DelayFunction()
    {
        canExecute = false; // Sperrt die Funktion
        yield return new WaitForSeconds(1f); // Warte eine Sekunde
        canExecute = true; // Erlaubt die Funktion wieder
    }
}
