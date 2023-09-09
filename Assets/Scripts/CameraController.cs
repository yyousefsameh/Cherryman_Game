using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  [SerializeField]  private Transform PlayerTransform;
 

    // Update is called once per frame
   private void Update()
    {
        transform.position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, transform.position.z);
    }
}
