using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int Cherries=0;
    [SerializeField] private AudioSource collectionSoundEffect;


 //   public int score;

    [SerializeField] private Text CherriesText;


    private void Start()
    {
       // score= 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            Cherries++;
            Debug.Log("Cherries:" + Cherries);
            CherriesText.text = "cherries:" + Cherries;
            collectionSoundEffect.Play();
            //score += 100;
        }
    }
}
