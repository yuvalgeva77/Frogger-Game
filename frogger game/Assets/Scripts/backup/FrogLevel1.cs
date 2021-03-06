﻿
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FrogLevel1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Sprite splash;
    public Sprite frog;
    public AudioClip splatSound;
    public AudioClip trombone;
    public AudioSource audioSrc;
    Freezer _freezer;
    public float duration = 1f;
    public int life;
    public Text lifeText;
    private Vector2 startPos;
    private bool hitbool = false, _isfreeze=false;
    private float _attackTimer = 0f;


    // Update is called once per frame
    void Awake()
    {

       audioSrc = GetComponent<AudioSource>();
        
    }
     void Start()
    {
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = frog;
        
        startPos = rb.position;
        GameObject ngr = GameObject.FindWithTag("Manager");
        if (ngr)
        {
            _freezer = ngr.GetComponent<Freezer>();
            _freezer.Reset(duration);
            life = 3;
            SetLifeText();
        }
    }
    void Update()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = frog;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            rb.MovePosition(rb.position + Vector2.right);
       else if (Input.GetKeyDown(KeyCode.LeftArrow))
            rb.MovePosition(rb.position + Vector2.left);
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            rb.MovePosition(rb.position + Vector2.up);
        else if(Input.GetKeyDown(KeyCode.DownArrow))
            rb.MovePosition(rb.position + Vector2.down);
        changeImage();


    }
    void OnTriggerEnter2D(Collider2D col) 

    {
        if (col.tag == "car")
        {
            hit();
        }

    }
    void SetLifeText()
    {
        lifeText.text = "lives: " + life.ToString();
      
    }
    void hit()
    {  
       // hitbool = true;
        life = life - 1;
        SetLifeText();
        hitbool = true;
        if (life > 0)
        {
            audioSrc.PlayOneShot(splatSound);
            Debug.Log("Youve been hit!");
            _freezer.Freeze();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // this.gameObject.GetComponent<SpriteRenderer>().sprite = frog;
            //hitbool = false;
        }
        if (life == 0)
        {
            audioSrc.PlayOneShot(splatSound);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = splash;
            _freezer.Freeze();
            audioSrc.PlayOneShot(trombone);
            Debug.Log("You loose!");
            Destroy(this);
        }
    }
    void changeImage()
    {
        if (hitbool == true)
        {
            _isfreeze = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = splash;
           
            // _attackTimer = 0f;  //option to reset time

        }
        // while attacking, count up the timer.
        if (_isfreeze)
        {
            _attackTimer += Time.deltaTime;

            // once the timer is 2 seconds, stop attacking and reset the sprite.
            if (_attackTimer >= duration)
            {
                _isfreeze = false;
                hitbool = false;
                _attackTimer = 0;
                rb.MovePosition(startPos);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = frog;
                //   hitbool = false;

            }
        }
    }
}
