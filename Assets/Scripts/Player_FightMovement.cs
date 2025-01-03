using UnityEngine;
using System.Collections.Generic;
using UnityEditor.UIElements;
using System.Collections; // Required for using coroutines

public class Player_FightMovement : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private float inputX;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            inputX = Input.GetAxisRaw("Horizontal");

            Debug.Log("This is input.x: " + inputX);

            if (inputX != 0)
            {
                animator.SetFloat("moveX", inputX);

                var targetPos = transform.position;
                targetPos.x += inputX;

                StartCoroutine(Move(targetPos)); // Call the coroutine to move the player
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

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
}