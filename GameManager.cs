using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public LevelManager levelManager;
    bool gameHasEnded = false;

    //public GameObject completeLevelUI;

    public void CompleteLevel(int LevelUnlock) {
        levelManager.levelUnlock = LevelUnlock;
        //completeLevelUI.SetActive(true);
        Debug.Log ("LEVEL WON");
    }

    public void EndGame () {
        if (gameHasEnded == false) {
            gameHasEnded = true;
            Debug.Log ("GAME OVER");
        }
    }
}
