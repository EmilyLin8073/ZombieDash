using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    //Variable for reference the music
    public AudioSource levelMusic, gameOverMusic, winMusic;

    //Variable for sound effect
    public AudioSource[] sfx;


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


    //For stopping the music and start the game over music
    public void PlayGameOver()
    {
        levelMusic.Stop();
        gameOverMusic.Play();
    }


    //For playing win music
    public void PlayLevelMusic()
    {
        levelMusic.Stop();
        winMusic.Play();
    }

    //For playing sound effect
    public void PlaySoundEffect(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }
}
