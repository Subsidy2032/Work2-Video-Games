using UnityEngine;

[CreateAssetMenu(fileName = "Taget", menuName = "Tagets/Target", order = 1)]
public class CollectableObjects : ScriptableObject
{
    [SerializeField] int weight;
    [SerializeField] int points;
    [SerializeField] string target;
    public Sprite collectableSprite;
}
        
