using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    private void OnEnable()
    {
        EventHandler.OnObjectCollected += HandleObjectCollected;
    }

    private void OnDisable()
    {
        EventHandler.OnObjectCollected -= HandleObjectCollected;
    }

    private void HandleObjectCollected(CollectableObjects collectedObjects)
    {
        score += collectedObjects.points;

        Destroy(collectedObjects);
    }
}
