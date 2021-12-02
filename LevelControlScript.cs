using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour {
    
    public static LevelControlScript instance = null;
    GameObject StageComplete;
    int sceneIndex, levelPassed;

    // Start is called before the first frame update
    void Start() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy (gameObject);

        //levelSign = GameObject.Find ("LevelNumber");
        StageComplete = GameObject.Find ("StageComplete");
        StageComplete.gameObject.SetActive (false);

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt ("LevelPassed");
    }

    public void stageComplete() {
        if (sceneIndex == 2)
            Invoke ("loadMainMenu", 1f);
        else {
            if (levelPassed < sceneIndex)
                PlayerPrefs.SetInt ("Levelpassed", sceneIndex);
            //levelSign.gameObject.SetActive (false);
            StageComplete.gameObject.SetActive (true);
            Invoke ("loadNextLevel", 1f);
        }
    }

    // Update is called once per frame
    void loadNextLevel () {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    void loadMainMenu () {
        SceneManager.LoadScene("MainMenu");
    }
}
