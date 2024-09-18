using UnityEngine;

public class CollectedTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Collectable collectableComponent = other.GetComponent<Collectable>();

        if (collectableComponent != null)
        {
            CollectableObjects collectableData = collectableComponent.collectableData;

            if (collectableData != null)
            {
                EventHandler.Instance.CollectObject(collectableData);
            }
        }
    }
}