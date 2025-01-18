using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour {
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;

    [SerializeField] int lettersPerSecond;

    public event System.Action OnShowDialog;
    public event System.Action OnHideDialog;

    public static DialogManager Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    Dialog dialog;
    int currentLine = 0;
    bool isTyping;
    bool boss;
    bool miniBoss;

    public IEnumerator ShowDialog(Dialog dialog, bool boss, bool miniBoss) {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();
        this.boss = boss;
        this.miniBoss = miniBoss;
        this.dialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public void HandleUpdate() {
        if (Input.GetKeyUp(KeyCode.E) && !isTyping) {
            ++currentLine;
            if (currentLine < dialog.Lines.Count) {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            } else {
                dialogBox.SetActive(false);
                currentLine = 0;
                OnHideDialog?.Invoke();
                if (boss) {
                    if (SceneManager.GetActiveScene().name == "Semester1Scene") {
                        SceneManager.LoadScene("BossFightScene");
                    }
                    if (SceneManager.GetActiveScene().name == "Semester2Scene") {
                        SceneManager.LoadScene("BossFight2Scene");
                    }
                    if (SceneManager.GetActiveScene().name == "Semester3Scene") {
                        SceneManager.LoadScene("BossFight3Scene");
                    }
                    if (SceneManager.GetActiveScene().name == "Semester4Scene") {
                        SceneManager.LoadScene("BossFight4Scene");
                    }
                    if (SceneManager.GetActiveScene().name == "Semester5Scene") {
                        SceneManager.LoadScene("BossFight5Scene");
                    }
                    if (SceneManager.GetActiveScene().name == "Semester6Scene") {
                        SceneManager.LoadScene("BossFight6Scene");
                    }
                }
                if (miniBoss) {
                    if (SceneManager.GetActiveScene().name == "Semester5Scene") {
                        SceneManager.LoadScene("MiniBossFight5Scene");
                    }
                    if (SceneManager.GetActiveScene().name == "Semester6Scene") {
                        SceneManager.LoadScene("MiniBossFight6Scene");
                    }
                }
             } 
        }
    }

    public IEnumerator TypeDialog(string line) {
        isTyping = true;
        dialogText.text = "";
        foreach (var letter in line.ToCharArray()) {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
    }
}