using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableObjects collectableData; // Reference to the ScriptableObject
    public float spriteScale = 0.9f; // Scale factor for the sprite

    void Start()
    {
        if (collectableData != null)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = collectableData.collectableSprite; // Set the sprite
                Debug.Log($"Sprite set to {collectableData.collectableSprite.name}");

                // Adjust the scale of the GameObject
                transform.localScale = new Vector3(spriteScale, spriteScale, 1f);
                Debug.Log($"Transform scale set to {transform.localScale}");
            }
            else
            {
                Debug.LogError("SpriteRenderer component missing!");
            }
        }
        else
        {
            Debug.LogError("CollectableData is not assigned!");
        }
    }
}
