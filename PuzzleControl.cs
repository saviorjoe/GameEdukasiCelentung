using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PuzzleControl : MonoBehaviour
{
    public GameObject[] parent;
    
    [SerializeField]
    GameObject btnBack;
    [SerializeField]
    GameObject btnNext;

    int urutan = 0;

    public int Urutan
    {
        get
        {
            return urutan;
        }
        set
        {
            if (parent[urutan] != null)
            {
                //set the current active to inactive, before lacing it
                GameObject puzzle = parent[urutan];
                puzzle.SetActive(false);
            }

                if (value < 0)
                urutan = parent.Length - 1;
            else if (value > parent.Length - 1)
                urutan = 0;
            else
                urutan = value;
            if (parent[urutan] != null)
            {
                GameObject puzzle = parent[urutan];
                puzzle.SetActive(true);
            }
        }
    }

    public void Back(int direction)
    {
        if (direction == 0)
            urutan--;
        
        if (urutan <= 3)
        {
            btnNext.SetActive(true);
            Debug.Log("4");
        } 

        if (urutan <= 0)
        {
            btnBack.SetActive(false);
            Debug.Log("3");
        }
    }

    public void Next(int direction)
    {
        if (direction >= 1)
            urutan++;
        
        if (urutan >= 4)
        {
            btnNext.SetActive(false);
            Debug.Log("2");
        } 

        if (urutan >= 1)
        {
            btnBack.SetActive(true);
            Debug.Log("3");
        }
    }
}
