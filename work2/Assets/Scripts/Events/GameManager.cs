using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public int score = 0;

    private void OnEnable()
    {
        EventHandler.OnObjectCollected += HandleObjectCollected;
    }

    private void OnDisable()
    {
        EventHandler.OnObjectCollected -= HandleObjectCollected;
    }

    private void HandleObjectCollected(Collectable collectable, CollectableObjects collectedObjects)
    {
        score += collectedObjects.points;
        UpdateScoreText();

        Destroy(collectable.gameObject);
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Your Score: " + score;
        }
        else
        {
            Debug.Log("No text object");
        }
    }
}
