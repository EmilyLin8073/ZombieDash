using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealthController : MonoBehaviour
{

    //Variable for player health
    public static PlayerHealthController instance;

    //Variable for current player health
    public int currentHealth;

    //Variable for max player health
    public int maxHealth;

    //Variable for invincible
    public float damageInvincLength = 1f;
    private float invincCount;

    //Variable for hurting sound effect
    public int hurtSFX = 11;
    public int deadSFX = 9;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //For set up the player health
        //maxHealth = CharacterTracker.instance.maxHealth;
        //currentHealth = CharacterTracker.instance.currentHealth;
        currentHealth = maxHealth;


        //For player health
        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCount > 0)
        {
            //For player invincible
            invincCount -= Time.deltaTime;

            if(invincCount <= 0)
            {
                PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, 1f);
            }
        }
    }


    //For damage the player
    public void DamagePlayer()
    {

        if (invincCount <= 0)
        {
            AudioManager.instance.PlaySoundEffect(hurtSFX);

            currentHealth--;

            //For setting invincible
            invincCount = damageInvincLength;

            //For when player getting damage, the body become invincible(transparent)
            PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, 0.5f);


            //For player died
            if (currentHealth <= 0)
            {
                PlayerController.instance.gameObject.SetActive(false);

                //For display death screen
                UIController.instance.deathScreen.SetActive(true);

                //For turn on the game over music
                AudioManager.instance.PlaySoundEffect(deadSFX);
                AudioManager.instance.PlayGameOver();
            }


            //For update player's health
            UIController.instance.healthSlider.value = currentHealth;
            UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
        }
    }


    public void MakeInvincible(float length)
    {
        invincCount = length;
        PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r, PlayerController.instance.bodySR.color.g, PlayerController.instance.bodySR.color.b, .5f);
    }


    //For heal the player
    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }


        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
}
