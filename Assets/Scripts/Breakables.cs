using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{
    //Variable for the broken box piece
    public GameObject[] brokenPieces;

    //Variable for randomly chose couple broken pieces
    public int maxPieces = 5;

    //Variable for the object health
    public int health = 50;

    //Vairable for drop items
    public bool shouldDropItems;
    public GameObject[] itemsToDrop;
    public float itemDropPercent;

    //Variable for sound effect
    public int breakSound = 0;

    private static Breakables instance;


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
        
    }


    //For when player run into the object
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (PlayerController.instance.dashCounter > 0)
            {
                Destroy(gameObject);

                AudioManager.instance.PlaySoundEffect(breakSound);

                //For randomly select couple broken pieces
                int piecesToDrop = Random.Range(1, maxPieces);

                //For show broken pieces
                for (int i = 0; i < piecesToDrop; i++)
                {
                    //For randomly select broken pieces
                    int randomPiece = Random.Range(0, brokenPieces.Length);
                    Instantiate(brokenPieces[randomPiece], transform.position, transform.rotation);
                }

                //Fpr drop items
                if(shouldDropItems)
                {
                    float dropChance = Random.Range(0f, 100f);

                    if(dropChance < itemDropPercent)
                    {
                        int randomItem = Random.Range(0, itemsToDrop.Length);
                        Instantiate(itemsToDrop[randomItem], transform.position, transform.rotation);
                    }
                }
            }
        }
    }


    //For damage the object by player bullet
    public void DamageObject(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            AudioManager.instance.PlaySoundEffect(breakSound);

            Destroy(gameObject);
            
            //For randomly select couple broken pieces
            int piecesToDrop = Random.Range(1, maxPieces);

            //For randomly select couple broken pieces
            for (int i = 0; i < piecesToDrop; i++)
            {
                //For randomly select broken pieces
                int randomPiece = Random.Range(0, brokenPieces.Length);
                Instantiate(brokenPieces[randomPiece], transform.position, transform.rotation);
            }

            //Fpr drop items
            if (shouldDropItems)
            {
                float dropChance = Random.Range(0f, 100f);

                if (dropChance < itemDropPercent)
                {
                    int randomItem = Random.Range(0, itemsToDrop.Length);
                    Instantiate(itemsToDrop[randomItem], transform.position, transform.rotation);
                }
            }
        }
    }
}
