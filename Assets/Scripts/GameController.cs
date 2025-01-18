using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState { FreeRoam, Dialog }
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController1;
    [SerializeField] PlayerController playerController2;
    [SerializeField] PlayerController playerController3;

    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject player3;

    GameState state;

    private void Start() {
        DialogManager.Instance.OnShowDialog += () => {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () => {
            if (state == GameState.Dialog)
                state = GameState.FreeRoam;
        };

        SetActivePlayer();
    }

    private void Update() {
        if (state == GameState.FreeRoam) {
            if (MainMenu.player1==true) {
                playerController1.HandleUpdate();
            } else if (MainMenu.player2==true) {
                playerController2.HandleUpdate();
            } else if (MainMenu.player3==true) {
                playerController3.HandleUpdate();
            }
            
        } else if (state == GameState.Dialog) {
            DialogManager.Instance.HandleUpdate();
        } 
    }

    private void SetActivePlayer() {
    int selectedPlayer = PlayerPrefs.GetInt("SelectedPlayer", 1); // Falls nichts gespeichert wurde, Standard = 1

    player1.SetActive(selectedPlayer == 1);
    player2.SetActive(selectedPlayer == 2);
    player3.SetActive(selectedPlayer == 3);
}

}
