using TMPro;
using UnityEngine;

public class IsWinner : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI goalText;

    private int score;
    [SerializeField] int pointsToWin;

    public void Start()
    {
        score = 0;
        goalText.text = "Goal: " + pointsToWin + " points";
    }

    private void OnEnable()
    {
        EventHandler.OnObjectCollected += CheckIfWinner;
    }

    private void OnDisable()
    {
        EventHandler.OnObjectCollected -= CheckIfWinner;
    }

    private void CheckIfWinner(Collectable collectable, CollectableObjects collectedObjects)
    {
        score += collectedObjects.points;

        if(score >= pointsToWin)
        {
            gameOverText.color = Color.green;
            gameOverText.text = "You Win!";
            Time.timeScale = 0f;
        }
    }
}
