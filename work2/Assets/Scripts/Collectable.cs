using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableObjects collectableData;
    [SerializeField] string[] objects;
    [SerializeField] float[] scale;

    void Start()
    {
        if (collectableData != null)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = collectableData.collectableSprite;

                for (int i = 0; i < objects.Length; i++)
                {
                    if (objects[i] == collectableData.target)
                    {
                        transform.localScale = new Vector3(scale[i], scale[i], 1f);
                    }
                }
            }

        }
    }
}
