using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float runningTime;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI gameOverText;

    void Update()
    {
        if (runningTime > 0)
        {
            timeText.text = "Time Remaining: " + (Mathf.FloorToInt(runningTime).ToString());
            runningTime -= Time.deltaTime;
        }

        if (runningTime <= 0)
        {
            gameOverText.text = "You ran out of time!\nGame Over!";
            gameOverText.color = Color.red;
            Time.timeScale = 0f;
        }
    }

    public void IncTime()
    {
        runningTime += 5;
    }
}