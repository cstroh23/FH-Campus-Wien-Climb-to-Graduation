using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI; // Referenz zum Pause-Menü
    private bool isPaused = false;

    private void Update()
    {
        // ESC-Taste löst das Pause-Menü aus
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Pause-Menü deaktivieren
        Time.timeScale = 1f;         // Spielgeschwindigkeit auf normal setzen
        isPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true); // Pause-Menü aktivieren
        Time.timeScale = 0f;         // Spiel anhalten
        isPaused = true;
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;         // Spielgeschwindigkeit zurücksetzen
        SceneManager.LoadScene("HomeScene"); // Main Menu Szene laden
    }
}
