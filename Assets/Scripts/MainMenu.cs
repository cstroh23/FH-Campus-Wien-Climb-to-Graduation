using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public static bool player1;
    public static bool player2;
    public static bool player3;

    public void SetPlayer1() {
    PlayerPrefs.SetInt("SelectedPlayer", 1);
    PlayerPrefs.Save();
    Debug.Log("Player 1 ausgewählt.");
    player1=true;
    player2=false;
    player3=false;
}

public void SetPlayer2() {
    PlayerPrefs.SetInt("SelectedPlayer", 2);
    PlayerPrefs.Save();
    Debug.Log("Player 2 ausgewählt.");
    player1=false;
    player2=true;
    player3=false;
}

public void SetPlayer3() {
    PlayerPrefs.SetInt("SelectedPlayer", 3);
    PlayerPrefs.Save();
    Debug.Log("Player 3 ausgewählt.");
    player1=false;
    player2=false;
    player3=true;
}

private void Start() {
    if (PlayerPrefs.HasKey("SelectedPlayer"))
    {
        PlayerPrefs.DeleteKey("SelectedPlayer"); // Löscht nur "SelectedPlayer"
        PlayerPrefs.Save(); // Speichert die Änderungen sofort
    }else if (!PlayerPrefs.HasKey("SelectedPlayer")) {
        Debug.Log("Kein Spieler ausgewählt, setze Standard: Player 1");
        PlayerPrefs.SetInt("SelectedPlayer", 1);
        PlayerPrefs.Save();
        player1=true;
        player2=false;
        player3=false;
    }
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
