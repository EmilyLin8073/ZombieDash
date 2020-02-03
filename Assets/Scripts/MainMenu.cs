using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Variable for load the scene
    public string levelToLoad;
    public string helpScreen;
    public string mainMenuScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //For start the game
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    } 


    //For exit the game
    public void ExitGame()
    {
        Application.Quit();
    }

    //For help screen
    public void HelpScreen()
    {
        SceneManager.LoadScene(helpScreen);
    }

    //For help screen
    public void MainMenuScreen()
    {
        SceneManager.LoadScene(mainMenuScreen);
    }
}
