using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosisiPlayer : MonoBehaviour
{
    public Rigidbody2D player;
    public Text textposisi;
    // Update is called once per frame
    void Update()
    {
        textposisi.text = "Posisi Player : " + player.position.ToString();
    }
}
