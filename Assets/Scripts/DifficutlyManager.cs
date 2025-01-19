using UnityEngine;
using TMPro; // For TextMeshPro

public class DifficutlyManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro component
    private static int difficulty = 1; // Statische Variable für Szenenübergreifenden Score

    void Start()
    {
        UpdateDifficutlyText();
    }

    public void SetDifficulty(int hardness)
    {
        difficulty = hardness; // Score erhöhen
        UpdateDifficutlyText();
    }

    public int GetDifficulty() {
        return difficulty;
    }

    private void UpdateDifficutlyText()
    {
        if (difficulty==1) {
            scoreText.text = "Difficulty: Easy"; // UI aktualisieren
        } else if (difficulty==2) {
            scoreText.text = "Diffficulty: Medium"; // UI aktualisieren
        } else if (difficulty==3) {
            scoreText.text = "Difficulty: Hard"; // UI aktualisieren
        }
    }

    private void OnApplicationQuit()
    {
        difficulty = 1; // Difficutly zurücksetzen, wenn das Spiel beendet wird
    }
}
