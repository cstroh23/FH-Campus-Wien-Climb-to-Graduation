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
    [SerializeField] private NPCController npcController;

    public static DialogManager Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    Dialog dialog;
    int currentLine = 0;
    bool isTyping;

    public IEnumerator ShowDialog(Dialog dialog) {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();

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
                if (npcController != null) {
                    if (npcController.isBoss() == true) {
                        SceneManager.LoadScene("BossFightScene");
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