using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableObjects collectableData;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = collectableData.collectableSprite;
    }
}
