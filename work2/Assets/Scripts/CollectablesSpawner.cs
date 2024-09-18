using UnityEngine;

public class CollectablesSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] CollectableObjects[] collectablesObjects;
    [SerializeField] float[] collectableProbability;

    [SerializeField] GameObject spawnBound;
    [SerializeField] int amountToSpawn;

    [SerializeField] float checkRadius = 0.5f;
    [SerializeField] int maxAttempts = 10;

    void Start()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            SpawnRandomCollectable();
        }
    }

    void SpawnRandomCollectable()
    {
        Vector2 randomPosition = GetValidPosition();
        if (randomPosition != Vector2.zero)
        {
            GameObject newCollectable = Instantiate(prefab, randomPosition, Quaternion.identity);
            Collectable collectable = newCollectable.GetComponent<Collectable>();
            CollectableObjects selectedCollectable = GetRandomCollectable();
            collectable.collectableData = selectedCollectable;
        }
        else
        {
            Debug.LogWarning("Failed to find a valid spawn location after multiple attempts.");
        }
    }

    Vector2 GetValidPosition()
    {
        Vector2 center = spawnBound.transform.position;
        Vector2 size = spawnBound.GetComponent<SpriteRenderer>().bounds.size;

        Vector2 halfSize = size / 2;
        float x1 = center.x - halfSize.x;
        float x2 = center.x + halfSize.x;
        float y1 = center.y - halfSize.y;
        float y2 = center.y + halfSize.y;

        int attemptCount = 0;
        while (attemptCount < maxAttempts)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(x1, x2),
                Random.Range(y1, y2)
            );

            Collider2D hitCollider = Physics2D.OverlapCircle(randomPosition, checkRadius);
            if (hitCollider == null)
            {
                return randomPosition;
            }

            attemptCount++;
        }

        return Vector2.zero;
    }

    CollectableObjects GetRandomCollectable()
    {
        float randomValue = Random.Range(0f, 1f);
        float cumulativeProbability = 0f;

        for (int i = 0; i < collectableProbability.Length; i++)
        {
            cumulativeProbability += collectableProbability[i];
            if (randomValue < cumulativeProbability)
            {
                return collectablesObjects[i];
            }
        }

        return collectablesObjects[collectablesObjects.Length - 1];
    }
}
