using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int score = 0;

    private void OnEnable()
    {
        EventHandler.OnObjectCollected += HandleObjectCollected;
    }

    private void OnDisable()
    {
        EventHandler.OnObjectCollected -= HandleObjectCollected;
    }

    private void HandleObjectCollected(CollectableObjects collectedObjects)
    {
        score += collectedObjects.points;
        UpdateScoreText();
        Destroy(collectedObjects);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Your Score: " + score;
    }
}
