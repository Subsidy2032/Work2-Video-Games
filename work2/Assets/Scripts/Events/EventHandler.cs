using UnityEngine;
using System;

public class EventHandler : MonoBehaviour
{
    public static event Action<Collectable, CollectableObjects> OnObjectCollected;

    public static EventHandler Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectObject(Collectable collectable, CollectableObjects collectedObject)
    {
        OnObjectCollected?.Invoke(collectable, collectedObject);
    }
}
