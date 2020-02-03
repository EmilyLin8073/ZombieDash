using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;


public class PlayerBullet : MonoBehaviour
{
	//Variable for bullet speed
	public float speed = 7.5f;

	//Move bullet
	public Rigidbody2D theRB;

	//For bullet effect
	public GameObject impactEffect;

    //Variable for damage the enemy'
    public int damageToGive = 50;

    //Variable for shotting sound effect
    public int impactSFX = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = transform.right * speed; 
    }


    //For bullet collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.instance.PlaySoundEffect(impactSFX);

        Instantiate(impactEffect, transform.position, transform.rotation);
    	Destroy(gameObject);

        //For damage the enemy and box
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().DamageEnemy(damageToGive);
        }

        if(other.tag == "Box")
        {
            other.GetComponent<Breakables>().DamageObject(damageToGive);
        }
    }


    //For delete the bullet when it's out of the windows
    private void OnBecameInvisible()
    {
    	Destroy(gameObject);
    }
}
