using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageControlScript : MonoBehaviour {

    public TestSaveGame SaveGameData;
    public LevelManager levelManager;
    public Button level02Button, level03Button, level04Button, level05Button, simulasiButton, puzzleButton;
    int levelPassed;

    //Use this for inizialitation
    void Start() {
        level02Button.interactable = false;
        level03Button.interactable = false;
        level04Button.interactable = false;
        level05Button.interactable = false;
        simulasiButton.interactable = false;
        puzzleButton.interactable = false;

        switch (levelManager.levelUnlock) {
        case 2:
            level02Button.interactable = true;
            level03Button.interactable = false;
            break;
        case 3:
            level02Button.interactable = true;
            level03Button.interactable = true;
            level04Button.interactable = false;
            break;
        case 4:
            level02Button.interactable = true;
            level03Button.interactable = true;
            level04Button.interactable = true;
            level05Button.interactable = false;
            break;
        case 5:
            level02Button.interactable = true;
            level03Button.interactable = true;
            level04Button.interactable = true;
            level05Button.interactable = true;
            puzzleButton.interactable = true;
            simulasiButton.interactable = true;
            break;
        }
    }

    public void SimulasiTerbuka() {
        /*if (levelManager.simulasiUnlock == false)
        {
            level02Button.interactable = false;
            level03Button.interactable = false;
            level04Button.interactable = false;
        }
        else if (levelManager.simulasiUnlock == true)
        {
            /*level02Button.interactable = true;
            level03Button.interactable = true;
            level04Button.interactable = true;
            simulasiButton.interactable = true;
        }*/
    }

    public void PuzzleTerbuka() {
        /*if (levelManager.puzzleUnlock == false)
        {
            level02Button.interactable = false;
            level03Button.interactable = false;
            level04Button.interactable = false;
        }
        else if (levelManager.puzzleUnlock == true)
        {
            /*level02Button.interactable = true;
            level03Button.interactable = true;
            level04Button.interactable = true;
            puzzleButton.interactable = true;
        }*/
    }

    public void levelToLoad (int level) {
        SceneManager.LoadScene(level);
    }

    public void resetPlayerPrefs(int LevelUnlock) {
        
        if (SaveGameData == true) {
            level02Button.interactable = false;
            level03Button.interactable = false;
            level04Button.interactable = false;
            PlayerPrefs.DeleteAll();
    }
}
}