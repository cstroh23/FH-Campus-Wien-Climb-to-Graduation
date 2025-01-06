using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGame() {
        SceneManager.LoadScene("SampleScene"); //For the moment only calling Level 1
    }

    public void GoToSettingsMenu() {
        SceneManager.LoadScene("SettingsScene");
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("HomeScene");
    }

    public void QuitGame() {
        Application.Quit();
    }
}