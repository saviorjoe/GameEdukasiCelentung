using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedPuzzleSelaawi : MonoBehaviour
{
    public GameObject selamat;
    public Button btnDownload;
    public bool selesai = false;

    public void cek () {
        for (int i=0; i < 12; i++) {
            if (transform.GetChild(i).GetComponent<PuzzleDragSelaawi> ().on_tempel) {
                selesai = true;
            } else {
                selesai = false;
                i = 12;
            }
        }
        if (selesai) {
            selamat.SetActive(true);
            btnDownload.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update() {
        if (!selesai) {
            cek ();
        }
    }
}
