using UnityEngine;
using System;

public class EventHandler : MonoBehaviour
{
    public static event Action<CollectableObjects> OnObjectCollected;

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

    public void CollectObject(CollectableObjects collectedObject)
    {
        Debug.Log("Debug happend");
        if (OnObjectCollected != null)
        {
            OnObjectCollected?.Invoke(collectedObject);
        }
    }

    public static EventHandler GetInstance()
    {
        return Instance;
    }
}
