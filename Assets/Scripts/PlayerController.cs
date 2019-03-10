using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour { 

    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;
    private int count;
    private int score;

    public Text countText;
    public Text winText;
    public Text scoreText;
    public Text loseText;

    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;
   


    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        score = 3;
        SetAllText();

      
        winText.text = "";
        loseText.text = "";


    }
 
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

       
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetAllText(); 
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
        }

       if (count == 4)
        {
            transform.position = new Vector3(31f, transform.position.y, 0f);
            score = 3;
            SetAllText();
        }
    }

    void SetAllText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 8)
        {
            winText.text = "You Win!";
            musicSource.clip = musicClipTwo;
            musicSource.Play();
        }

        scoreText.text = "Lives: " + score.ToString();
        if (score <= 0)
        {
            loseText.text = "You Lose!";
            Destroy(gameObject);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    



}
