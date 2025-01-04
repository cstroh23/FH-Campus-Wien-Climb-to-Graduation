using UnityEngine;
using System.Collections.Generic;
using UnityEditor.UIElements;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of the NPC movement
    private Vector3[] directions = new Vector3[4];
    private int currentDirection = 0;

    private Animator animator; // Reference to Animator component

    private void Awake()
    {
        // Initialize the Animator component
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        // Define movement directions: up, left, down, right
        directions[0] = Vector3.up;    // Move up
        directions[1] = Vector3.left;  // Move left
        directions[2] = Vector3.down;  // Move down
        directions[3] = Vector3.right; // Move right

        // Start the movement loop
        StartCoroutine(MoveEnemy());
    }

    private IEnumerator MoveEnemy()
    {
        while (true)
        {
            // Set animation parameters for current direction
            animator.SetFloat("moveX", directions[currentDirection].x);
            animator.SetFloat("moveY", directions[currentDirection].y);
            animator.SetBool("isMoving", true);

            // Get the target position based on the current direction
            Vector3 targetPos = transform.position + directions[currentDirection];

            // Move towards the target position
            float elapsedTime = 0f;
            Vector3 startPos = transform.position;
            while (elapsedTime < 1f) // Move for 1 second
            {
                transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / 1f);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos; // Snap to the target position

            // Stop movement animation
            animator.SetBool("isMoving", false);

            // Wait for 1 second
            yield return new WaitForSeconds(1f);

            // Move to the next direction
            currentDirection = (currentDirection + 1) % directions.Length;
        }
    }
}
