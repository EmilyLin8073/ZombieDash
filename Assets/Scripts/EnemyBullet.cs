using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //Variable for bullet speed
    public float speed;

    //Variable for direction
    private Vector3 direction;

    //Variable for impact sound effect
    public int impactSFX = 4;


    // Start is called before the first frame update
    void Start()
    {
        //For looking for player's direction
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        //For firing the bullet
        transform.position += direction * speed * Time.deltaTime;
        
    }

    //Hit the player and after that, destory the bullet
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
        }

        AudioManager.instance.PlaySoundEffect(impactSFX);
        Destroy(gameObject);
    }


    //For making the bullet unvisible
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
