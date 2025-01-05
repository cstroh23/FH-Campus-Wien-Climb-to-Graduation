using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab; // Das Bullet-Prefab
    public int poolSize = 10;       // Anzahl der Bullets im Pool

    private Queue<GameObject> bulletPool;

    private void Awake()
    {
        // Initialisiere den Pool
        bulletPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false); // Setze die Bullet unsichtbar
            bulletPool.Enqueue(bullet); // Füge sie zum Pool hinzu
        }
    }

    public GameObject GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true); // Aktiviert die Bullet
            return bullet;
        }
        else
        {
            // Optional: Pool erweitern, falls keine Bullets mehr verfügbar sind
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(true);
            return bullet;
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
