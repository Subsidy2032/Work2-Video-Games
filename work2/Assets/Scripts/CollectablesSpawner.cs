using UnityEngine;

public class CollectablesSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] CollectableObjects[] collectablesObjects;
    [SerializeField] float[] collectableProbability;

    [SerializeField] GameObject spawnBound;

    [SerializeField] int amountToSpawn;

    void Start()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            SpawnRandomCollectable();
        }
    }

    void SpawnRandomCollectable()
    {
        Vector2 center = spawnBound.transform.position;
        Vector2 size = spawnBound.GetComponent<SpriteRenderer>().bounds.size;

        Vector2 halfSize = size / 2;
        float x1 = center.x - halfSize.x;
        float x2 = center.x + halfSize.x;
        float y1 = center.y - halfSize.y;
        float y2 = center.y + halfSize.y;

        Vector2 randomPosition = new Vector2(
            Random.Range(x1, x2),
            Random.Range(y1, y2)
        );

        GameObject newCollectable = Instantiate(prefab, randomPosition, Quaternion.identity);

        Collectable collectable = newCollectable.GetComponent<Collectable>();

        CollectableObjects selectedCollectable = GetRandomCollectable();

        collectable.collectableData = selectedCollectable;
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