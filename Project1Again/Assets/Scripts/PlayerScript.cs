using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rigidbody2d; 
    public float speed;
    public Text score;
    private bool pauseIntro = false;

    public ParticleSystem gembits;


    float currentTime = 0f;
    float startingTime = 2f;
   
    public Text win;
    public Text countdownText;
    
    public int scoreValue = 0;
    public bool gameOver = false;

    public AudioClip musicClipOne;
    public AudioClip musicClipThree;
    public AudioClip musicClipTwo;
    public AudioClip CoinClip;
    public AudioClip musicClipFour;

    public AudioSource musicSource;
        public AudioSource audioSource;


    // Start is called before the first frame update

    static float  horizontal;
    static float vertical;

    void Awake()
    {   PlaySound(musicClipFour);
        rigidbody2d = GetComponent<Rigidbody2D>();
        score.text = "Score: " + scoreValue.ToString();
        currentTime = startingTime;
        
    }
    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        Vector2 move = new Vector2(horizontal, vertical);
        if (Input.GetKey(KeyCode.R))
        {
            
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // this loads the currently active scene
            
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime -= 1 * Time.deltaTime;
        if(currentTime < 0.0f && currentTime > -10f)
        {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (scoreValue > 5 && gameOver == false)
        {
        win.text = "You Win! Congratulations! A game by Brooke Lamothe";
        audioSource.Pause();
            PlaySound(musicClipTwo);
            gameOver = true;
            countdownText.text = ":)";
        }
        if (currentTime < 0f && currentTime > -10f && gameOver == false)
        {
            if (pauseIntro == false )
            {
                pauseIntro = true;
                musicSource.Stop();
            }
            PlayMusic(musicClipThree);
            
        }
        if (currentTime < -10f && scoreValue < 5 && gameOver == false)
        {
            gameOver = true;
            win.text = "You Lose :< Press R to Restart";
            audioSource.Pause();
            PlaySound(musicClipOne);

            countdownText.text = ":(";
        
        }
        
        
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

 
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = "Score: " + scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            PlaySound(CoinClip);

            gembits.Play();
        }
    }

    public void PlaySound(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }
    public void PlayMusic(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

        

        
}
