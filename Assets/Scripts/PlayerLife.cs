using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private int PlayerLives = 1;
    private int playerMaxLives = 1;
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    [SerializeField] private AudioSource deathSoundEffect;
    
    [SerializeField] private Text healthCounterText;




   PlayerCheckPoint playercheckpointobject;

  //  ItemCollector itemScoreObject;
    // object from the playermovement script to use its variables
  //  PlayerMovement playerMovementObject;

    void Start()
    {
        
        anim= GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
       


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            // checkpoint

         //   playercheckpoint.gameObject.transform.position = playercheckpoint.spawnPoint;
            Die();
        }
        else if (collision.gameObject.CompareTag("Chicken_Enemy"))
        {


            // killing the enemy

           //if (rb.velocity.y < -.1f)
          //  {
               // Destroy(collision.gameObject);
              //  itemScoreObject.score += 200;
          //  }
           // else
            //{
                
                Die();
          //  }
        }
        else if (collision.gameObject.CompareTag("Mushroom_Enemy"))
        {

            // killing the enemy


            // if (rb.velocity.y < -.1f)
            //  {
            //     Destroy(collision.gameObject);
            // itemScoreObject.score += 200;
            // }
            // else
            // {

            Die();
           // }
        }
    }

    private void Die()
    {
        anim.SetTrigger("Death");
        rb.bodyType = RigidbodyType2D.Static;
        deathSoundEffect.Play();
        PlayerLives--;
        healthCounterText.text = PlayerLives + "/" + playerMaxLives;
        bc.enabled= false;




        //   playercheckpointobject.gameObject.transform.position = playercheckpointobject.spawnPoint;
    }

    private void RestartLevel()
    {

        if (PlayerLives >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        
        else if(PlayerLives == 0)
        {
            SceneManager.LoadScene("Gameover");
        }

    }
}
