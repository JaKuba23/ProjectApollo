using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    float initialEnemyRate = 5; // Początkowa częstotliwość spawnowania
    float minEnemyRate = 2;     // Minimalna częstotliwość spawnowania
    float nextEnemySpawnTime = 0;
    float timeSinceStart = 0;
    float shipBoundaryX = 8.2f; // Ograniczenie na osi X

    void Update()
    {
        timeSinceStart += Time.deltaTime;
        nextEnemySpawnTime -= Time.deltaTime;

        // Oblicz nową częstotliwość spawnowania na podstawie czasu gry
        float newEnemyRate = initialEnemyRate - (timeSinceStart * 0.1f); // Przykładowy spadek częstotliwości

        // Ogranicz nową częstotliwość do wartości minimalnej
        if (newEnemyRate < minEnemyRate)
        {
            newEnemyRate = minEnemyRate;
        }

        if (nextEnemySpawnTime <= 0)
        {
            nextEnemySpawnTime = newEnemyRate;

            // Losowa pozycja w górnej części ekranu, ale w granicach shipBoundaryX
            float spawnX = Random.Range(-shipBoundaryX, shipBoundaryX);
            Vector3 spawnPosition = new Vector3(spawnX, 10f, 0f);

            // Tworzenie przeciwnika
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Ustalenie prędkości przeciwnika, aby leciał w dół
            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(0, -5f); // Możesz dostosować prędkość według własnych preferencji
            }
        }
    }
}
