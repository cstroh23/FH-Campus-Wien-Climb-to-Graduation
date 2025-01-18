using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public static bool player1;
    public static bool player2;
    public static bool player3;

    private void Awake() {
        if (!PlayerPrefs.HasKey("GameStarted")) {
            SetPlayer1();
            PlayerPrefs.SetInt("GameStarted", 1);
        }
    }

    public void SetPlayer1() {
        player1 = true;
        player2 = false;
        player3 = false;
    }

    public void SetPlayer2() {
        player1 = false;
        player2 = true;
        player3 = false;
    }

    public void SetPlayer3() {
        player1 = false;
        player2 = false;
        player3 = true;
    }

    public bool GetPlayer1() {
        return player1;
    }

    public bool GetPlayer2() {
        return player2;
    }

    public bool GetPlayer3() {
        return player3;
    }

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
    public void GoToSkinEditor() {
        SceneManager.LoadScene("EditorScene");
    }  
}
