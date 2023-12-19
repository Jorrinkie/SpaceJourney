using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    public GameObject coinPrefab; // Reference to the coin prefab.
    public float coinSpawnInterval = 1f; // Time between spawning coins.
    private float timeSinceLastSpawn = 0f;
    public float TimeUntilStart = 3f;

    private void Update()
    {
        TimeUntilStart -= Time.deltaTime;
        if (TimeUntilStart < 0)
        {
            // Update the timer.
            timeSinceLastSpawn += Time.deltaTime;

            // Check if it's time to spawn a coin.
            if (timeSinceLastSpawn >= coinSpawnInterval)
            {
                SpawnCoin();
                timeSinceLastSpawn = 0f; // Reset the timer.
            }
        }
    }

    private void SpawnCoin()
    {
        // Create a new coin instance.
        GameObject newCoin = Instantiate(coinPrefab, transform.position, Quaternion.identity);

        // Adjust the coin's position based on your desired offset.
        Vector3 coinOffset = new Vector3(0f, 0f, 0.01f); // Adjust this as needed.
        newCoin.transform.position += coinOffset;
    }
}
