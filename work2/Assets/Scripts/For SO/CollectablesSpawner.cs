using System.Drawing;
using System.IO.IsolatedStorage;
using Unity.VisualScripting;
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

        Vector2 halfSize = size / 2;

        // Calculate the boundary values
        float x1 = center.x - halfSize.x;
        float x2 = center.x + halfSize.x;
        float y1 = center.y - halfSize.y;
        float y2 = center.y + halfSize.y;
    }

    spawnBound.get
        Vector2 randomPosition = new Vector2(
            Random.Range(spawnMinBounds.x, spawnMaxBounds.x),
            Random.Range(spawnMinBounds.y, spawnMaxBounds.y) );

        GameObject newCollectable = Instantiate(prefab, randomPosition, Quaternion.identity);

        CollectableObjects selectedCollectable = GetRandomCollectable();

        newCollectable.GetComponent<Collectable>().collectableData = selectedCollectable;
    }

    CollectableObjects GetRandomCollectable()
    {
        // Get a random value between 0 and 1
        float randomValue = Random.Range(0f, 1f);

        // Assign based on probabilities
        if (randomValue < diamondProbability)
        {
            return diamond;
        }
        else if (randomValue < diamondProbability + coinProbability)
        {
            return coin;
        }
        else
        {
            return rock;
        }
    }
}
