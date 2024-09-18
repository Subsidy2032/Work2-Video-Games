using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // Ensure this is assigned in the Inspector
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

        foreach (Collectable collectable in FindObjectsOfType<Collectable>())
        {
            if (collectable.collectableData == collectedObjects)
            {
                Destroy(collectable.gameObject);
                break;
            }
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Your Score: " + score;
        }
        else
        {
            Debug.LogError("ScoreText is not assigned in the Inspector.");
        }
    }
}
