using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//For using UI
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public static UIController instance;
    //Variable for health slider
    public Slider healthSlider;
    public Text healthText;

    //Variable for death screen
    public GameObject deathScreen;

    //Variable for select the scene
    public string newGameScene, mainMenuScene;

    //Variable for pause menu
    public GameObject pauseMenu;


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


    //For new game scene
    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }


    //For return to main menu
    public void returnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }


    //For pause menu
    public void Resume()
    {
        LevelManager.instance.PauseNUnpause();
    }
}
