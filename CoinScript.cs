using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
    //float speedGeser = 5f;
    public GameInfo scriptInfo;
    public AudioClip myAudio;
    
    // Start is called before the first frame update
    void Start() {
       
    }

    // Update is called once per frame
    void Update() {
        //coinGeser();
        
    }

    void OnTriggerEnter2D (Collider2D coll) {
        if (coll.gameObject.tag == ("Player")) {
            AudioSource.PlayClipAtPoint(myAudio, transform.position);
            scriptInfo.jumlahbambu += 1;
            //Debug.Log("Poin!" +scriptInfo.jumlahbambu);
            Destroy (gameObject);
        }
    }

    //public void playSuara () {
       // myAudio.Play ();
    //}

    //void coinGeser () {
       // if (Player.groundmaju) {
       //     transform.Translate (Vector2.left * speedGeser * Time.deltaTime);
       // } else if (!Player.groundmaju) {
         //   return;
       // }
    //}
}
