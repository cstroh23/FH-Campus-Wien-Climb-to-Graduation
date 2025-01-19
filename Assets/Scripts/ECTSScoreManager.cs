using UnityEngine;
using TMPro; // For TextMeshPro

public class ECTSScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro component
    private static int score = 180; // Statische Variable für Szenenübergreifenden Score

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount; // Score erhöhen
        UpdateScoreText();
    }

    public int GetScore() {
        return score;
    }

    private void UpdateScoreText()
    {
        scoreText.text = "ECTS: " + score; // UI aktualisieren
    }

    private void OnApplicationQuit()
    {
        score = 0; // Score zurücksetzen, wenn das Spiel beendet wird
    }
}
