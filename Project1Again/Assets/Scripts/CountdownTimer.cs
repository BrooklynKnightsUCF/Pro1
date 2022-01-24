using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;


public class CountdownTimer : MonoBehaviour
{
    public GameObject player;
    float currentTime = 0f;
    float startingTime = 12f;
    
    public AudioClip musicClipThree;
    public AudioSource musicSource;
    public Text win;
    public Text intro;
    public bool gameOver = false;

    public bool musicCheck = false;




    public Text countdownText;

    // Start is called before the first frame update
    void Awake()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        if(currentTime <= 10f && currentTime > 0f)
        {
            countdownText.text = currentTime.ToString();
            if(musicCheck == false)
            {
                musicCheck = true;
                musicSource.clip = musicClipThree;
            }
        }

        if (currentTime < 12f && currentTime > 10f)
        {
            intro.text = "Welcome to Jelly Cube Maze. Colect the Gems to Win \n \n WASD to Move";
        }
        else
        {
            intro.text = " ";
        }
    
    }
}
