using UnityEngine;

public class CollectedTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        CollectableObject collectableComponent = other.GetComponent<CollectableObject>();

        if (collectableComponent != null)
        {
            CollectableObjects collectableData = collectableComponent.collectableData;

            if (collectableData != null)
            {
                if (EventHandler.Instance != null)
                {
                    EventHandler.Instance.CollectObject(collectableData);
                }
            }
        }
    }
}