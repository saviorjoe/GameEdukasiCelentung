using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AdventureGame
{
    public class GameManager : MonoBehaviour
    {
        [Header("Data Register")]
        [SerializeField]
        private GameStageData stageData = null;
        [SerializeField]
        public string namaSceneMati, SceneReset;
        [SerializeField]
        public LevelManager levelManager;

        [Header("Component Register")]
        [SerializeField]
        public GameInfo info;
        [SerializeField]
        private Image HealthBar = null;
        [SerializeField]
        private Image EnemyHealth = null;
        [SerializeField]
        private GameObject[] liveObject = null;
        [SerializeField]
        private GameObject EndGameView = null;
        [SerializeField]
        private GameObject WinGameView = null;
        [SerializeField]
        private Text textBambu, textNada = null;

        public bool IsMobile = false;

        [Header("Other Interactions")]
        [SerializeField]
        private Player playerClass = null;
        [SerializeField]
        private MiniInsect enemyClass = null;

        private void Awake()
        {
            SetupLiveNumber();
        }

        public void DecreaseHealthBar()
        {
            HealthBar.fillAmount -= playerClass.EnemyDamage / 100;
        }

        public void DecreaseHealthBarEnemy()
        {
            EnemyHealth.fillAmount -= enemyClass.playerDamage / 100;
        }

        public void ShowEndGamePanel()
        {
            EndGameView.SetActive(true);
            if (stageData.liveNumber <= 0) {
                EndGameView.SetActive(false);
            }
        }

        public void ShowWinGame()
        {
            WinGameView.SetActive(true);
        }

        public void SetupLiveNumber()
        {
            foreach(var data in liveObject)
            {
                data.SetActive(false);
            }

            for(int i = 0; i < stageData.liveNumber; i++)
            {
                liveObject[i].SetActive(true);
            }
        }

        public void ResetGame()
        {
            stageData.liveNumber -= 1;
            SceneManager.LoadScene(SceneReset);

            if (stageData.liveNumber <= 0) {
                //EndGameView.SetActive(false);
                SceneManager.LoadScene(namaSceneMati);
            }
        }

        public void ShowData() {
            textBambu.text = info.jumlahbambu.ToString();
            textNada.text = info.killingscore.ToString();
        }

        public void CompleteLevel(int LevelUnlock) {
            levelManager.levelUnlock = LevelUnlock;
            Debug.Log ("LEVEL WON");
    }

        public void MainMenu()
        {
            SceneManager.LoadScene("Main Menu");
        }

        public void ChangeScene(string nameStage)
        {
            SceneManager.LoadScene(nameStage);
        }
    }
}