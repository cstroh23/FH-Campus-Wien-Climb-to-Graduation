using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f; // Geschwindigkeit der Bullet
    public float lifetime = 2f;    // Lebensdauer der Bullet

    private void OnEnable()
    {
        // Starte die Lebensdauer der Bullet
        Invoke(nameof(Deactivate), lifetime);
    }

    private void Update()
    {
        // Bewege die Bullet nach oben
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    private void Deactivate()
    {
        // Deaktiviert die Bullet, anstatt sie zu zerstören
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // Lösche den Deaktivierungsaufruf, um Konflikte zu vermeiden
        CancelInvoke();
    }
}
