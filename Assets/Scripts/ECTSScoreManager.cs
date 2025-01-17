using UnityEngine;
using TMPro; // For TextMeshPro

public class ECTSScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro component
    private static int score = 0; // Statische Variable für Szenenübergreifenden Score

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount; // Score erhöhen
        UpdateScoreText();
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
