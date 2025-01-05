using UnityEngine;
using System.Collections.Generic;
using UnityEditor.UIElements;
using System.Collections; // Required for using coroutines

public class Player2Movement : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;

    private Animator animator;

    public LayerMask  solidObjectsLayer;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical"); // Fixed typo: "Vertrical" -> "Vertical"

            Debug.Log("This is input.x" + input.x);
            Debug.Log("This is input.y" + input.y);

            if (input.x != 0) input.y=0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
                
                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos)); // Call the coroutine to move the player
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

    // Ensure this method is inside the Player2Movement class
    private IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos; // Snap to the final target position to avoid small errors
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos) {
        if(Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null) {
            return false;
        }
        return true;
    }
}
