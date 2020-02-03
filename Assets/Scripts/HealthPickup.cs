using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthPickup : MonoBehaviour
{
    //Variable for heal amount
    public int healAmount = 1;

    //Variable for pick up time
    public float waitToPickUp = 0.5f;

    //Variable for pick up sound effect
    public int pickUpSFX = 7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //For pick up time
        //if(waitToPickUp < 0)
        //{
        //    waitToPickUp -= Time.deltaTime;
        //}       
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)) //&& waitToPickUp <= 0
        {
            PlayerHealthController.instance.HealPlayer(healAmount);
            AudioManager.instance.PlaySoundEffect(pickUpSFX);
            Destroy(gameObject);
        }
    }
}
