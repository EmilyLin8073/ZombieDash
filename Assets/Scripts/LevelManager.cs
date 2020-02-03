using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //Variable for call the LevelManager
    public static LevelManager instance;

    //Vairable for time to load the scene
    public float waitToLoad = 2f;

    //Variable for catch the scene name
    public string nextLevel;

    //Variable for pause the game
    public bool isPaused = true;


    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }


    // Update is called once per frame
    void Update()
    {
        //For pause the game
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            PauseNUnpause();
        }
    }


    public IEnumerator LevelEnd()
    {
        //For playing the win music
        //AudioManager.instance.PlayLevelWin();
        yield return new WaitForSeconds(waitToLoad);

        PlayerController.instance.canMove = false;

        SceneManager.LoadScene(nextLevel);
    }


    //Variable for pause the game
    public void PauseNUnpause()
    {
        if(!isPaused)
        {
            UIController.instance.pauseMenu.SetActive(true);
            isPaused = true;
            //For stopping the game when pause
            Time.timeScale = 0f;
        }
        else
        {
            UIController.instance.pauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;

        }
    }
}
