using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController_Boss : MonoBehaviour
{
    [SerializeField] GameObject dialogBoxWin;
    [SerializeField] GameObject dialogBoxLoose;
    [SerializeField] private Dragon[] dragons;
    [SerializeField] HealthBar healthBar;

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
                        dialogBoxWin.SetActive(false);
                        SceneManager.LoadScene("HomeScene");
                        Time.timeScale = 1f;
                    }
                }
            }

            if (healthBar.getHealth()==0) {
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
                        dialogBoxWin.SetActive(false);
                        SceneManager.LoadScene("HomeScene");
                        Time.timeScale = 1f;
                    }
                }
            }

            if (healthBar.getHealth()==0) {
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
                        dialogBoxWin.SetActive(false);
                        SceneManager.LoadScene("HomeScene");
                        Time.timeScale = 1f;
                    }
                }
            }

            if (healthBar.getHealth()==0) {
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
                        dialogBoxWin.SetActive(false);
                        SceneManager.LoadScene("HomeScene");
                        Time.timeScale = 1f;
                    }
                }
            }

            if (healthBar.getHealth()==0) {
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
                        dialogBoxWin.SetActive(false);
                        SceneManager.LoadScene("HomeScene");
                        Time.timeScale = 1f;
                    }
                }
            }

            if (healthBar.getHealth()==0) {
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
                        dialogBoxWin.SetActive(false);
                        SceneManager.LoadScene("HomeScene");
                        Time.timeScale = 1f;
                    }
                }
            }

            if (healthBar.getHealth()==0) {
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
