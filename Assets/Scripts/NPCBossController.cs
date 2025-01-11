using UnityEngine;
using UnityEngine.SceneManagement; // For scene management
using System.Collections; // Required for IEnumerator


public class NPCBossController : MonoBehaviour, Interactable
{
    public float moveSpeed = 2f;
    private Vector3[] directions = new Vector3[4];
    private int currentDirection = 0;

    private Animator animator;

    [SerializeField] Dialog dialog;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact() {
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }

    private void Start()
    {
        directions[0] = Vector3.up;
        directions[1] = Vector3.left;
        directions[2] = Vector3.down;
        directions[3] = Vector3.right;

        StartCoroutine(MoveEnemy());
    }

    private IEnumerator MoveEnemy()
    {
        while (true)
        {
            if (Time.timeScale == 0f) yield return null; // Bewegung pausieren
            animator.SetFloat("moveX", directions[currentDirection].x);
            animator.SetFloat("moveY", directions[currentDirection].y);
            animator.SetBool("isMoving", true);

            Vector3 targetPos = transform.position + directions[currentDirection];

            float elapsedTime = 0f;
            Vector3 startPos = transform.position;
            while (elapsedTime < 1f)
            {
                transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / 1f);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos;
            animator.SetBool("isMoving", false);

            yield return new WaitForSeconds(1f);
            currentDirection = (currentDirection + 1) % directions.Length;
        }
    }
}
