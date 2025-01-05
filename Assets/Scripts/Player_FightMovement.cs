using UnityEngine;
using System.Collections.Generic;
using UnityEditor.UIElements;
using System.Collections; // Required for using coroutines

public class Player_FightMovement : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private bool isShooting;
    private float inputX;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
         if (!isShooting) {// Only allow movement if not shooting
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

         // Check for shooting input (Spacebar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Shoot());
        }
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

     private IEnumerator Shoot()
    {
        isShooting = true;
        animator.SetBool("isShooting", true);

        // Wait for the shooting animation to complete
        yield return new WaitForSeconds(0.5f); // Adjust this duration to match your animation length

        animator.SetBool("isShooting", false);
        isShooting = false;
    }
}