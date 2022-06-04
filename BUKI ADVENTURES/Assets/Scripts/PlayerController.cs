using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput = 0f;
    public float speed = 5f;
    public PlayerMovement movement;
    public bool isAlive = true;
    public GameManager manager;
    public Animator anim;

    public AudioSource audioS;
    public AudioClip coinSound;
    public AudioClip hurtSound;
    public AudioClip jumpSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        horizontalInput = Input.GetAxisRaw("Horizontal");

        //player jump
        if (Input.GetButtonDown("Jump") && isAlive==true)
        {
            if (movement.m_Grounded)
            {
                anim.SetTrigger("Jump");
                audioS.PlayOneShot(jumpSound, 1f);
            }
            movement.Jump();
        }

        //set animations
        anim.SetBool("Grounded", movement.m_Grounded);
        anim.SetBool("IsAlive", isAlive );

        if (horizontalInput == 0)
        {
            anim.speed = 1f;
            anim.SetBool("Move", false);
        }
        else
        {
            if (isAlive && movement.m_Grounded)
            {
                anim.speed = 1 * Mathf.Abs(horizontalInput);
            }
            anim.SetBool("Move", true);
        }
    }

    // fisicas de los juegos
    private void FixedUpdate()
    {
        if(isAlive== true)
        {
            movement.Move(horizontalInput * speed * Time.deltaTime); 
        }

    }

    //trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //cherry
        if(collision.gameObject.tag=="Cherry")
        {
            Destroy(collision.gameObject);
            manager.totalCoins++;

            audioS.PlayOneShot(coinSound, 1f);
            

        }
        //cherry mala
        if (collision.gameObject.tag == "PoisonedCherry")
        {
            Debug.Log("Poisoned Cherry is Picked!");
            if (isAlive == true)
            {
                isAlive = false;
                anim.SetTrigger("Die");
                audioS.PlayOneShot(hurtSound, 1f);
            }


        }
        //checkpoint
        if (collision.gameObject.tag == "CheckPoint")
        {
            manager.spawnPoint = collision.gameObject.transform;
        }
        //level end
        if (collision.gameObject.tag == "LevelEnd")
        {
            manager.FinishLevel();
        }
    }
    //collision
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Spike" || collision.gameObject.tag=="Enemy")
        {
            Die();
        }

        if (collision.gameObject.tag == "WeakPoint")
        {
            collision.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(collision.transform.parent.gameObject);
        }
    }

    public void Die()
    {

        isAlive = false;
        anim.SetTrigger("Die");
        audioS.PlayOneShot(hurtSound, 1f);
    }

}
