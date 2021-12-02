using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour {
    public static int darahplayer, darahenemy, nyawa = 5;
    public int jumlahbambu, killingscore;
    public Slider hpplayer;
    public Slider hpenemy;
    public Rigidbody2D player;      //, enemy;
    public Text textposisi, enemykilling, textscore, textnyawa;     //, textposisienemy, darahhero;

    void Start () {
        killingscore   = 0;
        darahplayer    = 10;
        darahenemy     = 10;
        jumlahbambu    = 0;
    }

    void Update() {
        textposisi.text = "Posisi player : "+player.position.ToString();
    //  textposisi.text = "Posisi enemy : "+enemy.position.ToString();
        enemykilling.text = "=  " + killingscore.ToString();
    //  darahhero.text = "HP  "+darahhero.ToString();
        hpplayer.value = darahplayer;
        hpenemy.value = darahenemy;
        textscore.text = "=  " + jumlahbambu.ToString();
        textnyawa.text = "=  " + nyawa.ToString();
    }
}
