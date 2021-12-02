using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPuzzle : MonoBehaviour {
    public GameObject parent_puzzle, selamat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseUp () {
        for (int i = 0; i < 9; i++) {
            parent_puzzle.transform.GetChild(i).GetComponent<PuzzleDrag> ().on_tempel = false;
            parent_puzzle.transform.GetChild(i).GetComponent<PuzzleDrag> ().on_pos = false;
            parent_puzzle.transform.GetChild(i).position = parent_puzzle.transform.GetChild(i).GetComponent<PuzzleDrag> ().pos_awal;
            parent_puzzle.transform.GetChild(i).localScale = parent_puzzle.transform.GetChild(i).GetComponent<PuzzleDrag> ().scale_awal;
        }
        selamat.SetActive (false);
        parent_puzzle.GetComponent<FeedPuzzle> ().selesai = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
