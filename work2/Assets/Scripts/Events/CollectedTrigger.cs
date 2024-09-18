using UnityEngine;

public class CollectedTrigger : MonoBehaviour
{
    private EventHandler eventHandler = EventHandler.GetInstance();
    private void OnTriggerEnter2D(Collider2D other)
    {
        Collectable collectableComponent = other.GetComponent<Collectable>();

        if (collectableComponent != null)
        {
            Debug.Log("Entered");
            CollectableObjects collectableData = collectableComponent.collectableData;

            if (collectableData != null)
            {
                Debug.Log("Not null");
               eventHandler.CollectObject(collectableData);
            }
        }
    }
}