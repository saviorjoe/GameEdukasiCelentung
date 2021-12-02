using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulasiCoba : MonoBehaviour {
    #region Variable

    public Text textMagnitude = null;
    public Animator animator = null;
    public AudioSource audioSource = null;
    public bool debugMode = false;
    public bool soundIsActive =  false;
    public float minimumMagnitude = 2;
    public float decreaseSpeed = 1f;
    public float delayTime = 4f;
    public AudioClip[] audioArray = null;
    private Vector3 accelerationFloat = default;

    #endregion
    #region Data
    private Dictionary<string, AudioClip> audioData = new Dictionary<string, AudioClip>();
    #endregion

    private void Awake() {
        audioData.Add("Do", audioArray[0]);
        audioData.Add("Re", audioArray[1]);
        audioData.Add("Mi", audioArray[2]);
        audioData.Add("Fa", audioArray[3]);
        audioData.Add("Sol", audioArray[4]);
        audioData.Add("La", audioArray[5]);
        audioData.Add("Si", audioArray[6]);
        audioData.Add("Do1", audioArray[7]);
    }
    // Start is called before the first frame update
    void Start() {
        //Void start is nonactive
    }

    // Update is called once per frame
    private void Update() {
        accelerationFloat = Input.acceleration;
        textMagnitude.text = accelerationFloat.sqrMagnitude.ToString();

        if (debugMode == false){
            if (accelerationFloat.sqrMagnitude >= minimumMagnitude) {
                PlayAudio();
            } else {
                StopAudio();
            }
        } else {
            if (soundIsActive) {
                audioSource.volume = 1;
            } else {
                audioSource.volume -= decreaseSpeed * Time.deltaTime;
            }
        }
    }

    public void ChangeAudio(string nada) {
        audioSource.clip = audioData[nada];
    }

    public void PlayAudio() {
        float max = 1;

        if (audioSource.volume <= accelerationFloat.sqrMagnitude / 7 && audioSource.volume <= max) {
            audioSource.volume += decreaseSpeed * Time.deltaTime;
        }

        if (soundIsActive == false) {
            audioSource.Play();
            animator.SetBool("Shake", true);
            soundIsActive = true;
            StopAllCoroutines();
        }
    }

    public void StopAudio() {
        audioSource.volume -= decreaseSpeed * Time.deltaTime;

        if (soundIsActive == true) {
            StartCoroutine(DelayOff(delayTime));
        }
    }

    private IEnumerator DelayOff (float time) {
        yield return new WaitForSeconds(time);
        animator.SetBool("Shake", false);
        soundIsActive = false;
        audioSource.Stop();
    }
}
