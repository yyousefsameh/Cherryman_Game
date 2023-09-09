using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerCheckPoint : MonoBehaviour
{

    // ده بتاع ال player ولا ال flag
    private Animator  anim;



    [SerializeField] GameObject checkpointFlag;
    private Vector2 spawnPoint;






    private enum  CheckPointFlagMovementState
    {
       checkpointnoflagidle, checkpointflagout
    }

  


    private  void Start()
    {
        // put the player's position in spawnpoint variable

        spawnPoint=gameObject.transform.position;
    }
    private void UpdateFlagAnimationState()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckPointFlagMovementState checkpointflagstate;




        
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            checkpointflagstate = CheckPointFlagMovementState.checkpointflagout;
            //put the checkpointflag's position in spawnpoint variable
            spawnPoint = checkpointFlag.transform.position;
            //  Destroy(checkpointFlag);

            anim.SetInteger("FlagState", (int)checkpointflagstate);
        }


        
    }
}
