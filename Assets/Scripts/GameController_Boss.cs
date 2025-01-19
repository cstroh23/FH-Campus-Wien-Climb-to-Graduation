using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController_Boss : MonoBehaviour
{
    [SerializeField] GameObject dialogBoxWin;
    [SerializeField] GameObject dialogBoxLoose;
    [SerializeField] private Dragon[] dragons;
    [SerializeField] HealthBar healthBar;
    [SerializeField] Player_FightMovement player;
    [SerializeField] ECTSScoreManager ects;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "BossFightScene") {
            foreach (Dragon dragon in dragons) {
                //Debug.Log("In the GameController the hitCounter is: " + dragon.getHitCounter());
                if (dragon.getHitCounter() >= 7)
                {
                    Time.timeScale = 0f;
                    dialogBoxWin.SetActive(true);
                    Debug.Log("Hit counter reached 7! Loading HomeScene...");
                    if (Input.GetKeyDown(KeyCode.E)) {
                        if (ects.GetScore()<30) {
                            ects.AddScore(30);
                        }
                        dialogBoxWin.SetActive(false);
                        SceneManager.LoadScene("HomeScene");
                        Time.timeScale = 1f;
                    }
                    break;
                }
            }

            // Displays Dialog when player died
            if (player.currentHealth <= 0) {
                Time.timeScale = 0f;
                dialogBoxLoose.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)) {
                    dialogBoxLoose.SetActive(false);
                    SceneManager.LoadScene("HomeScene");
                    Time.timeScale = 1f;
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "BossFight2Scene") {
            //TODO: Still need to tell the right win condition
            foreach (Dragon dragon in dragons) {
                //Debug.Log("In the GameController the hitCounter is: " + dragon.getHitCounter());
                if (dragon.getHitCounter() >= 7)
                {
                    Time.timeScale = 0f;
                    dialogBoxWin.SetActive(true);
                    Debug.Log("Hit counter reached 7! Loading HomeScene...");
                    if (Input.GetKeyDown(KeyCode.E)) {
                        if (ects.GetScore()<60) {
                            ects.AddScore(30);
                        }
                        dialogBoxWin.SetActive(false);
                        SceneManager.LoadScene("HomeScene");
                        Time.timeScale = 1f;
                    }
                    break;
                }
            }

            if (player.currentHealth <= 0) {
                Time.timeScale = 0f;
                dialogBoxLoose.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)) {
                    dialogBoxLoose.SetActive(false);
                    SceneManager.LoadScene("HomeScene");
                    Time.timeScale = 1f;
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "BossFight3Scene") {
            //TODO: Still need to tell the right win condition
            foreach (Dragon dragon in dragons) {
                //Debug.Log("In the GameController the hitCounter is: " + dragon.getHitCounter());
                if (dragon.getHitCounter() >= 7)
                {
                    Time.timeScale = 0f;
                    dialogBoxWin.SetActive(true);
                    Debug.Log("Hit counter reached 7! Loading HomeScene...");
                    if (Input.GetKeyDown(KeyCode.E)) {
                        if (ects.GetScore()<90) {
                            ects.AddScore(30);
                        }
                        dialogBoxWin.SetActive(false);
                        SceneManager.LoadScene("HomeScene");
                        Time.timeScale = 1f;
                    }
                    break;
                }
            }

            if (player.currentHealth <= 0) {
                Time.timeScale = 0f;
                dialogBoxLoose.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)) {
                    dialogBoxLoose.SetActive(false);
                    SceneManager.LoadScene("HomeScene");
                    Time.timeScale = 1f;
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "BossFight4Scene") {
            //TODO: Still need to tell the right win condition
            foreach (Dragon dragon in dragons) {
                //Debug.Log("In the GameController the hitCounter is: " + dragon.getHitCounter());
                if (dragon.getHitCounter() >= 7)
                {
                    Time.timeScale = 0f;
                    dialogBoxWin.SetActive(true);
                    Debug.Log("Hit counter reached 7! Loading HomeScene...");
                    if (Input.GetKeyDown(KeyCode.E)) {
                        if (ects.GetScore()<120) {
                            ects.AddScore(30);
                        }
                        dialogBoxWin.SetActive(false);
                        SceneManager.LoadScene("HomeScene");
                        Time.timeScale = 1f;
                    }
                    break;
                }
            }

            if (player.currentHealth <= 0) {
                Time.timeScale = 0f;
                dialogBoxLoose.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)) {
                    dialogBoxLoose.SetActive(false);
                    SceneManager.LoadScene("HomeScene");
                    Time.timeScale = 1f;
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "BossFight5Scene") {
            //TODO: Still need to tell the right win condition
            foreach (Dragon dragon in dragons) {
                //Debug.Log("In the GameController the hitCounter is: " + dragon.getHitCounter());
                if (dragon.getHitCounter() >= 7)
                {
                    Time.timeScale = 0f;
                    dialogBoxWin.SetActive(true);
                    Debug.Log("Hit counter reached 7! Loading HomeScene...");
                    if (Input.GetKeyDown(KeyCode.E)) {
                        if (ects.GetScore()<150) {
                            ects.AddScore(30);
                        }
                        dialogBoxWin.SetActive(false);
                        SceneManager.LoadScene("HomeScene");
                        Time.timeScale = 1f;
                    }
                    break;
                }
            }

            if (player.currentHealth <= 0) {
                Time.timeScale = 0f;
                dialogBoxLoose.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)) {
                    dialogBoxLoose.SetActive(false);
                    SceneManager.LoadScene("HomeScene");
                    Time.timeScale = 1f;
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "BossFight6Scene") {
            //TODO: Still need to tell the right win condition
            foreach (Dragon dragon in dragons) {
                //Debug.Log("In the GameController the hitCounter is: " + dragon.getHitCounter());
                if (dragon.getHitCounter() >= 7)
                {
                    Time.timeScale = 0f;
                    dialogBoxWin.SetActive(true);
                    Debug.Log("Hit counter reached 7! Loading HomeScene...");
                    if (Input.GetKeyDown(KeyCode.E)) {
                        if (ects.GetScore()<180) {
                            ects.AddScore(30);
                        }
                        dialogBoxWin.SetActive(false);
                        SceneManager.LoadScene("HomeScene");
                        Time.timeScale = 1f;
                    }
                    break;
                }
            }

            if (player.currentHealth <= 0) {
                Time.timeScale = 0f;
                dialogBoxLoose.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)) {
                    dialogBoxLoose.SetActive(false);
                    SceneManager.LoadScene("HomeScene");
                    Time.timeScale = 1f;
                }
            }
        }
    }
}
