using UnityEngine;
using UnityEngine.Events;

namespace AdventureGame
{
    public class MiniInsect : MonoBehaviour
    {
        [Header("Component Register")]
        [SerializeField]
        private Rigidbody2D rb = null;

        [Header("Data Register")]
        [SerializeField]
        public float HealthEnemy = 100;
        [SerializeField]
        private float movementSpeed = 0;
        [SerializeField]
        private float minimumDistance = 0;
        [SerializeField]
        private float currentDistance = 0;
        [SerializeField]
        private bool isChase = false;
        [SerializeField]
        private float damageDeal = 0;
        [SerializeField]
        public float playerDamage = 0;

        [Header("Other Interactions")]
        [SerializeField]
        private Transform playerTransform = null;
        [SerializeField]
        private Player playerClass = null;
        [SerializeField]
        private GameInfo enemyMaot = null;
        [Header("Game Event")]
        public UnityEvent OnGetDamage = new UnityEvent();

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            CalculateDistance();
            CheckPlayerInRange(minimumDistance);
        }

        private void FixedUpdate()
        {
            if (!playerClass.isDie)
            {
                Chase(rb, movementSpeed, playerTransform, transform, isChase);
            }
            else
            {
                rb.velocity = Vector2.zero;

            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Knife")
            {

                HealthEnemy -= playerDamage;
                CheckEnemyHealth();
            }

            if(collision.tag == "Player")
            {
                playerClass.EnemyDamage = damageDeal;
                playerClass.OnGetDamage.Invoke();
            }
        }

        private void CheckEnemyHealth()
        {
            if(HealthEnemy <= 0)
            {
                EnemyDie();
                Destroy(gameObject);
            }
        }

        private void EnemyDie()
        {
            OnGetDamage.Invoke();
        }

        private void Chase(Rigidbody2D rb, float speed, Transform player, Transform self, bool isChase)
        {
            if(isChase)
            {
                if (player.position.x < self.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    rb.velocity = new Vector2(-1 * speed * Time.deltaTime, 0);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    rb.velocity = new Vector2(1 * speed * Time.deltaTime, 0);
                } 
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }

        private void CalculateDistance()
        {
            currentDistance = Vector2.Distance(transform.position, playerTransform.position);
        }

        private void CheckPlayerInRange(float minDistance)
        {
            if(currentDistance <= minDistance)
            {
                isChase = true;
            }
            else
            {
                isChase = false;
            }
        }
    }
} 