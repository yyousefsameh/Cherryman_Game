using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMovement : MonoBehaviour  
{
   // [SerializeField] Transform player;
    SpriteRenderer sr;
    Rigidbody2D rb;

    [SerializeField] private float speed = 150f;

    bool isRight = true;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb= GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //لو انت عايز ال enemy يبصلك 
        /*  if (player.position.x > transform.position.x)
          {
              sr.flipX= true;
          }
          else
          {
              sr.flipX= false;
          }*/
    }


    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) <= .01f)
        {
            isRight = !isRight;
            sr.flipX= !sr.flipX;
        }

        if(isRight) 
        {
            rb.velocity=new Vector2(Time.fixedDeltaTime*speed,rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(Time.fixedDeltaTime * speed*-1 , rb.velocity.y);

        }
    }


}

