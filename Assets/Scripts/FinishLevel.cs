using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private AudioSource finishsSound;
    private bool levelCompleted=false;
   private void Start()
    {
        finishsSound= GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name=="Player"&&!levelCompleted)
        {
            finishsSound.Play();
            levelCompleted=true;
            Invoke("completeLevel",1f);
        }
    }

    private void completeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }


}
