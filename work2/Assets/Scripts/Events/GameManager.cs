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
        // Increment score based on points from the scriptable object
        score += collectedObjects.points;
        UpdateScoreText();

        // Loop through the scene to find the Collectable GameObject with matching collectable data
        foreach (Collectable collectable in FindObjectsOfType<Collectable>())
        {
            // Check if this Collectable has the same CollectableObjects scriptable object
            if (collectable.collectableData == collectedObjects)
            {
                // Destroy the GameObject that the Collectable script is attached to
                Destroy(collectable.gameObject);
                break; // Exit loop after destroying the object
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
