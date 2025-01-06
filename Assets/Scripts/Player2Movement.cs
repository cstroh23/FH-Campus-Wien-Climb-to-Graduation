using UnityEngine;
using UnityEngine.SceneManagement; // Für Szenenwechsel
using System.Collections; // Für IEnumerator

public class Player2Movement : MonoBehaviour
{
    public float moveSpeed; // Bewegungsgeschwindigkeit des Spielers
    private bool isMoving; // Überprüfen, ob der Spieler sich bewegt
    private Vector2 input; // Eingaben des Spielers

    private Animator animator; // Animator für Bewegungsanimationen
    public LayerMask solidObjectsLayer; // Layer für Hindernisse

    public GameObject dialogBox; // Dialog-Box (z. B. das Panel in Unity)
    private bool isDialogActive = false; // Überprüfen, ob die Dialog-Box aktiv ist

    private void Awake()
    {
        animator = GetComponent<Animator>(); // Animator initialisieren
    }

    private void Start()
    {
        // Sicherstellen, dass das Dialog-Panel zu Beginn inaktiv ist
        if (dialogBox != null)
        {
            dialogBox.SetActive(false);
        }
    }

    private void Update()
    {
        // Wenn der Dialog aktiv ist, auf "Enter" warten
        if (isDialogActive)
        {
            if (Input.GetKeyDown(KeyCode.Return)) // Warten auf die Enter-Taste
            {
                CloseDialog();
                SceneManager.LoadScene("BossFightScene"); // Wechsel zur BossFightScene
            }
            return; // Verhindern, dass der Spieler sich während des Dialogs bewegt
        }

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
        return Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) == null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Dialog-Box anzeigen, wenn der Spieler den NPC berührt
        if (collision.CompareTag("Enemy")) // Der NPC muss das Tag "Enemy" haben
        {
            ShowDialog();
        }
    }

    private void ShowDialog()
    {
        isDialogActive = true; // Dialog als aktiv markieren
        if (dialogBox != null)
        {
            dialogBox.SetActive(true); // Dialog-Box anzeigen
        }
    }

    private void CloseDialog()
    {
        isDialogActive = false; // Dialog als inaktiv markieren
        if (dialogBox != null)
        {
            dialogBox.SetActive(false); // Dialog-Box verstecken
        }
    }
}
