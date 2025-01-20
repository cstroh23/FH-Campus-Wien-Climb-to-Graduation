using UnityEngine;

public class EnergyDrinkSpawner : MonoBehaviour
{
    public GameObject energyDrinkPrefab; // Prefab to spawn
    public float spawnInterval = 10f;    // Time between spawns
    public float spawnY = 30f;            // Fixed Y position for spawning

    private float screenWidthInUnits;

    private float timer = 0f;

    void Start()
    {
        // Calculate the screen width in world units
        float screenWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        screenWidthInUnits = screenWidth / 2; // Half-width for left and right bounds
    }

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Spawn energy drink at set intervals
        if (timer >= spawnInterval)
        {
            SpawnEnergyDrink();
            timer = 0f; // Reset the timer
        }
    }

    void SpawnEnergyDrink()
    {
        // Generate a random X position between -46 and 47
        float randomX = Random.Range(-46f, 47f);

        // Set the Y position to always be 30
        float spawnY = 30f;

        // Create the spawn position
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        // Instantiate the energy drink at the calculated position
        Instantiate(energyDrinkPrefab, spawnPosition, Quaternion.identity);

        Debug.Log($"Energy Drink spawned at X: {randomX}, Y: {spawnY}");
    }

}
