using UnityEngine;
using System.Collections;

public class Player_FightMovement : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private bool isShooting;
    private float inputX;

    public Transform bulletSpawnPoint; // Punkt, an dem die Bullet spawnt
    private BulletPool bulletPool;     // Referenz zum Bullet-Pool

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        bulletPool = Object.FindFirstObjectByType<BulletPool>(); // Hole den Bullet-Pool
    }

    private void Update()
    {
        if (!isShooting) // Nur bewegen, wenn nicht geschossen wird
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

        // Schießen bei Space-Taste
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
}
