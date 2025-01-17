using UnityEngine;
using TMPro; // For TextMeshPro

public class ECTSScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro component
    private int score = 0; // Initialize score to 0

    void Start()
    {
        UpdateScoreText(); // Initialize the score text
    }

    public void AddScore(int amount)
    {
        score += amount; // Increase the score
        UpdateScoreText(); // Update the UI
    }

    private void UpdateScoreText()
    {
        scoreText.text = "ECTS: " + score; // Update the text
    }
}
