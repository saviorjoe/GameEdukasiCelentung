using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureGame
{
    public class Finish : MonoBehaviour
    {
        public GameManager gameManager = null;

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                gameManager.ShowWinGame();
                gameManager.ShowData();
            }
        }
    }
}
