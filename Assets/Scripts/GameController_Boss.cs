using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController_Boss : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] private Dragon[] dragons;

    private void Update()
    {
        foreach (Dragon dragon in dragons) {
            if (dragon.getHitCounter() >= 7)
            {
                Time.timeScale = 0f;
                dialogBox.SetActive(true);
                Debug.Log("Hit counter reached 7! Loading HomeScene...");
                if (Input.GetKeyDown(KeyCode.E)) {
                    dialogBox.SetActive(false);
                    SceneManager.LoadScene("HomeScene");
                    Time.timeScale = 1f;
                }
            }
        }
    }
}
