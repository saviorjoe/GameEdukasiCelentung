using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlPuzzle : MonoBehaviour {
    public GameObject parent;

    public UnityEvent DestroyDownload = new UnityEvent();
    // Start is called before the first frame update
    void Start() {
        
    }

    int urutan = 0;

    void aktif(int a) {
        urutan += a;
        if (urutan < 0)
        {
            urutan = parent.transform.childCount - 1;
        } else if (urutan > parent.transform.childCount - 1) {
            urutan = 0;
        }
        
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            parent.transform.GetChild(i).gameObject.SetActive(false);
        }

        parent.transform.GetChild (urutan).gameObject.SetActive(true);

        DestroyDownload.Invoke();
    
    }

    void OnMouseUp() {
        if (gameObject.name == "Next")
        {
            aktif (1);
        } else 
        {
            aktif (-1);
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
