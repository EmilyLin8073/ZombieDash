using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;


public class PlayerController : MonoBehaviour
{
    //[SerializeField]
    public static PlayerController instance;

    //Variable for player movement
    public float moveSpeed;
    private Vector2 moveInput;

    //Variable for collision
    public Rigidbody2D theRB;

    //For rotating the gun
    public Transform gunArm;

    //Variable for reference the Camera.main
    private Camera theCamera;

    //For walking animation
    public Animator anim;

    //Variable for firing the bullet
    public GameObject bulletToFire;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;

    //Variable for making player invincible
    public SpriteRenderer bodySR;

    //Variable for dashing
    private float activeMoveSpeed;
    public float dashSpeed = 8f, dashLength = 0.5f, dashColldown = 1f, dashInvinvibility = 0.5f;
    private float dashCoolCounter;
    //Don't show it on the player script
    [HideInInspector]
    public float dashCounter;

    //Variable for stop play moving when clear the level
    [HideInInspector]
    public bool canMove = true;

    //Variable for dash sound effect
    public int dashSFX = 8;
    public int shootingSFX = 15;


    //Trigger as soon as the player is in the world
    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        theCamera = Camera.main;
        activeMoveSpeed = moveSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        //For stop the player when the level is clear
        if (canMove && !LevelManager.instance.isPaused)
        {
            //For moving player horizontally and vertically
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

            //For letting player move in the same speed in any direction
            moveInput.Normalize();
            theRB.velocity = moveInput * activeMoveSpeed;

            //Variable for moving the gun around
            Vector3 mousePosition = Input.mousePosition;
            Vector3 screenPoint = theCamera.WorldToScreenPoint(transform.localPosition);

            //Checking the position of the mouse
            if (mousePosition.x < screenPoint.x)
            {
                //Make the player facing to the mouse direction
                transform.localScale = new Vector3(-1f, 1f, 1f);

                //Make the gun facing to the mouser direction
                gunArm.localScale = new Vector3(-1f, -1f, 1f);
            }
            else
            {
                transform.localScale = Vector3.one;  //one = (1f, 1f, 1f)
                gunArm.localScale = Vector3.one;
            }

            //Rotate gun arm
            //Calculate the difference between mouse and player
            Vector2 offset = new Vector2((mousePosition.x - screenPoint.x), (mousePosition.y - screenPoint.y));

            //Calculate the angle between mouse and the player
            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            gunArm.rotation = Quaternion.Euler(0, 0, angle);

            //For firing the bullet
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                shotCounter = timeBetweenShots;
                AudioManager.instance.PlaySoundEffect(shootingSFX);
            }

            //For firing the bullet when user keep the mouse down
            if (Input.GetMouseButton(0))
            {
                shotCounter -= Time.deltaTime;

                if (shotCounter <= 0)
                {
                    Instantiate(bulletToFire, firePoint.position, firePoint.rotation);

                    shotCounter = timeBetweenShots;
                }
            }

            //For player dashing
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AudioManager.instance.PlaySoundEffect(dashSFX);

                if (dashCoolCounter <= 0 && dashCounter <= 0)
                {
                    activeMoveSpeed = dashSpeed;
                    dashCounter = dashLength;

                    anim.SetTrigger("dash");
                }
            }

            //For when player is dashing
            if (dashCounter > 0)
            {
                dashCounter -= Time.deltaTime;

                if (dashCounter <= 0)
                {
                    activeMoveSpeed = moveSpeed;
                    dashCoolCounter = dashColldown;
                }
            }

            if (dashCoolCounter > 0)
            {
                dashCoolCounter -= Time.deltaTime;
            }

            //For moving animation
            if (moveInput != Vector2.zero)
            {
                anim.SetBool("isMoving", true);
            }
            else
            {
                anim.SetBool("isMoving", false);
            }
        }
        else
        {
            theRB.velocity = Vector2.zero;
            anim.SetBool("isMoveing", false);
        }
    }
}














