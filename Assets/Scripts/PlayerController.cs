using UnityEngine;
using UnityEngine.SceneManagement; // Für Szenenwechsel
using System.Collections;
using Unity.Multiplayer.Center.Common.Analytics; // Für IEnumerator

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // Bewegungsgeschwindigkeit des Spielers
    private bool isMoving; // Überprüfen, ob der Spieler sich bewegt
    private Vector2 input; // Eingaben des Spielers

    private Animator animator; // Animator für Bewegungsanimationen
    public LayerMask solidObjectsLayer; // Layer für Hindernisse
    public LayerMask interactableLayer;

    private void Awake()
    {
        animator = GetComponent<Animator>(); // Animator initialisieren
    }

    public void HandleUpdate()
    {
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
        }
        return true;
    }
}
