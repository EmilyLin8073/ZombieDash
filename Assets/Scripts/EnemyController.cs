using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	//Variable for moving the enemy
	public Rigidbody2D theRB;
	public float moveSpeed;

	//Variable for enemy chasing the player
	public float rangeToChasePlayer;
	private Vector3 moveDirection;

	//Variable for animation
	public Animator anim;

	//Variable for enemy health
	public int health = 200;

	//Variable for splatter
	public GameObject[] deathSplatters;
    public GameObject hitEffect;

    //Variable to let enemy fire
    public bool shouldShot;
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    private float fireCounter;

    //Variable for checking if the enemy in the camera
    public SpriteRenderer theBody;

    //Variable for shooting when in the range
    public float shootRange;

    //Variable for enemy instance
    public static EnemyController instance;

    //Variable for enemy dead sound effect
    public int deadSFX = 1;
    public int hurtSFX = 2;
    public int shootingSFX = 14;


    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        if(theBody.isVisible && PlayerController.instance.gameObject.activeInHierarchy)
        {
            //For chasing after the player
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToChasePlayer)
            {
                moveDirection = PlayerController.instance.transform.position - transform.position;

                //Chasing after player after pick up the item
            }
            else
            {
                moveDirection = Vector3.zero;
            }

            moveDirection.Normalize();

            theRB.velocity = moveDirection * moveSpeed;

            //For letting enemy to fire
            if (shouldShot && Vector3.Distance(transform.position, PlayerController.instance.transform.position) < shootRange)
            {
                fireCounter -= Time.deltaTime;

                if (fireCounter <= 0)
                {
                    fireCounter = fireRate;
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    AudioManager.instance.PlaySoundEffect(shootingSFX);
                }
            }
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }

        //For moving animation
        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }


    //For taking damage
    public void DamageEnemy(int damage)
    {
        AudioManager.instance.PlaySoundEffect(hurtSFX);
        health -= damage;

        Instantiate(hitEffect, transform.position, transform.rotation);

    	if(health <= 0)
    	{
            AudioManager.instance.PlaySoundEffect(deadSFX);
            Destroy(gameObject);

    		//For splatter effect
    		int selectedSplatter = Random.Range(0, deathSplatters.Length);
    		int rotation = Random.Range(0, 4);
    		Instantiate(deathSplatters[selectedSplatter], transform.position, Quaternion.Euler(0f, 0f, rotation * 90f));
    	}
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
        }

        //Destroy(gameObject);
    }

}








