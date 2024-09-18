using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableObjects collectableData;
    public float spriteScale;

    void Start()
    {
        if (collectableData != null)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = collectableData.collectableSprite;

                transform.localScale = new Vector3(spriteScale, spriteScale, 1f);
            }

        }
    }
}
