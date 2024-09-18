using UnityEngine;

[CreateAssetMenu(fileName = "Taget", menuName = "Tagets/Target", order = 1)]
public class CollectableObjects : ScriptableObject
{
    [SerializeField] public int weight;
    [SerializeField] public  int points;
    [SerializeField] public string target;
    public Sprite collectableSprite;
}
        
