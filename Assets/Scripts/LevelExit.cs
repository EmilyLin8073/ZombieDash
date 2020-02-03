using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For loading the scene
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    //Variable to switch scene
    public string levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //For when player enter the door
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //Using scene manager system
            //SceneManager.LoadScene(levelToLoad);
            StartCoroutine(LevelManager.instance.LevelEnd());
        }
    }
}
