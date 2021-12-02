using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AdventureGame
{
    public class Player : MonoBehaviour
    {
        AudioSource audio;
        private float musicVol = 0f;

        [Header("Component Register")]
        [SerializeField]
        private Rigidbody2D rb = null;
        [SerializeField]
        private SpriteRenderer spriteRender = null;
        [SerializeField]
        private Animator animator = null;
        [SerializeField]
        private BoxCollider2D knife = null;
        
        [Header("Data Management")]
        public float Health = 100;
        [SerializeField]
        private float damageHit = 0;
        [SerializeField]
        private float movementSpeed = 0;
        [SerializeField]
        public Vector2 jumpPower = new Vector2(0,600);
        /*private float jumpPower = 0;*/
        [SerializeField]
        private Vector2 directionMovement = default;
        [SerializeField]
        private bool isJump = false;

        public bool isDie = false;
        public float EnemyDamage = 0;

        [Header("Other Interaction")]
        [SerializeField]
        private MiniInsect enemyClass = null;
        [SerializeField]
        private GameManager gameManager = null;

        [Header("Controll Key")]
        [SerializeField]
        private KeyCode jumpKey = default;
        [SerializeField]
        private KeyCode attackKey = default;

        [Header("Game Event")]
        public UnityEvent OnGetDamage = new UnityEvent();

        void Start()
        {
            audio = GetComponent<AudioSource>();
        }
        private void Awake()
        {
            OnGetDamage.AddListener(GetDamage);
        }

        void Update()
        {
            if (!gameManager.IsMobile)
            {
                directionMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }

            if (Input.GetKeyDown(jumpKey))
            {
                Jump();
            }

            if (Input.GetKeyDown(attackKey))
            {
                StartCoroutine(Attack());
            }

            MuteAudio();
        }

        private void FixedUpdate()
        {
            if (isDie == false)
            {
                Movement();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Ground")
            {
                isJump = false;
            }

            if(collision.tag == "BigEnemy")
            {
                GetDamage();
                enemyClass.playerDamage = damageHit;
                enemyClass.OnGetDamage.Invoke();
            }
        }

        public void AttackSystem()
        {
            StartCoroutine(Attack());
        }

        private IEnumerator Attack()
        {
            animator.SetTrigger("attack");
            knife.enabled = true;
            yield return new WaitForSeconds(1);
            knife.enabled = false;
            StopAllCoroutines();
        }

        private void GetDamage()
        {
            Health -= EnemyDamage;
            CheckHealth();
        }

        private void HeightPositionCheck() {
            if (transform.position.y <= -5.80f) {
                EnemyDamage = 100;
                OnGetDamage.Invoke();
                
            }
        }

        private void CheckHealth()
        {
            if(Health <= 0)
            {
                Die();
                isDie = true;
            }
        }

        private void Die()
        {
            animator.SetTrigger("Die");
            gameManager.ShowEndGamePanel();
        }

        public void Jump()
        {
            if (isJump == false)
            {
                isJump = true;
                /*rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);*/
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().AddForce (jumpPower);
                animator.SetBool("jump", true);

            }
            else
            {
                animator.SetBool("jump", false);
            }
        }

        private void Movement()
        {
            if (directionMovement.x != 0)
            {
                rb.velocity = new Vector2(directionMovement.x * movementSpeed * Time.deltaTime, rb.velocity.y);
                animator.SetBool("Is Idle", false);

                if (directionMovement.x < 0)
                {
                    transform.localScale = new Vector3(-0.5f, 0.5f, 0.8f);
                }
                else
                {
                    transform.localScale = new Vector3(0.5f, 0.5f, 0.8f);
                }
            }
            else
            {
                animator.SetBool("Is Idle", true);
            }
        }

        private void MuteAudio()
        {
            if (isDie == true)
            {
                audio.volume = musicVol;
            }
        }

        public void CanvasButtonMovement(string direction)
        {
            if(direction == "Left")
            {
                Debug.Log("Left");
                directionMovement = new Vector2(-1, 0);
            }
            else if (direction == "Right")
            {
                Debug.Log("Right");
                directionMovement = new Vector2(1, 0);
            }
            else
            {
                Debug.Log("Input Handler is False");
            }
        }

        public void StopMovement()
        {
            Debug.Log("Stop");
            directionMovement  = Vector2.zero;
            rb.velocity = Vector2.zero;
        }
    }
}
