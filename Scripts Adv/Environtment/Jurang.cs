using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AdventureGame 
{
    public class Jurang : MonoBehaviour 
    {
        [SerializeField]
        public float damageJurang = 100;
        [SerializeField]
        private Player playerMurag = null;

        public void OnTriggerEnter2D (Collider2D collision) 
        {
            if (collision.tag == "Player") {
                playerMurag.EnemyDamage = damageJurang;
                playerMurag.OnGetDamage.Invoke();
            }
        }
    }
}
    
