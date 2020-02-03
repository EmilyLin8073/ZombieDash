using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //Variable for open the door
    public bool closeWhenEntered;
    public GameObject[] doors;

    //Variable for see if the enemy is clear
    public bool openWhenEnemiesCleared;
    public List<GameObject> enemies = new List<GameObject>();

    //Variable for checking which room player in
    private bool roomActive;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //For checking if there's enemies in the room
        if(enemies.Count > 0 && roomActive && openWhenEnemiesCleared)
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                if(enemies[i] == null)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
            }

            //For unlock the door
            if(enemies.Count == 0)
            {
                foreach (GameObject door in doors)
                {
                    door.SetActive(false);

                    //For reenter the room, the door won't be close
                    closeWhenEntered = false;
                }
            }
        }
    }


    //For dected if the player is in the room
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            CameraController.instance.ChangeTarget(transform);

            //For open the door
            if(closeWhenEntered)
            {
                foreach(GameObject door in doors)
                {
                    door.SetActive(true);
                }
            }

            roomActive = true;
        }
    }


    //For checking the room active
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            roomActive = false;
        }      
    }
}
