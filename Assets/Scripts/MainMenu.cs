using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGameSemester1() {
        SceneManager.LoadScene("Semester1Scene");
    }
    public void PlayGameSemester2() {
        SceneManager.LoadScene("Semester2Scene");
    }
    public void PlayGameSemester3() {
        SceneManager.LoadScene("Semester3Scene");
    }
    public void PlayGameSemester4() {
        SceneManager.LoadScene("Semester4Scene");
    }
    public void PlayGameSemester5() {
        SceneManager.LoadScene("Semester5Scene");
    }
    public void PlayGameSemester6() {
        SceneManager.LoadScene("Semester6Scene");
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

    public void GoToChapterMenu() {
        SceneManager.LoadScene("ChapterScene");
    }

    public void GoToChapter1Menu() {
        SceneManager.LoadScene("Chapter1Scene");
    }
    public void GoToChapter2Menu() {
        SceneManager.LoadScene("Chapter2Scene");
    }
    public void GoToChapter3Menu() {
        SceneManager.LoadScene("Chapter3Scene");
    }
    
}