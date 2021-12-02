using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedPuzzle : MonoBehaviour {
    public GameObject selamat;
    public bool selesai = false;

    public void cek () {
        for (int i=0; i < 9; i++) {
            if (transform.GetChild(i).GetComponent<PuzzleDrag> ().on_tempel) {
                selesai = true;
            } else {
                selesai = false;
                i = 9;
            }
        }
        if (selesai) {
            selamat.SetActive (true);
        }
    }

    // Update is called once per frame
    void Update() {
        if (!selesai) {
            cek ();
        }
    }
}
