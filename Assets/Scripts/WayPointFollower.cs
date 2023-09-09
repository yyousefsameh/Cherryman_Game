using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    private int currentWayPointIndex = 0;

    [SerializeField] private float speed = 2f;

  private void Update()
    {
        //transform.position دي عايده علي ال platform ال بتتحرك 
        // .1f دي علشان لو لمسو بعض 
        if (Vector2.Distance(wayPoints[currentWayPointIndex].transform.position, transform.position) < .1f)
        {
            currentWayPointIndex++;
            //ده علشان لو انت ال currentwaypointindex عدي ال size بتاع ال array يرجع ويعمل من الاول تاني 
            if(currentWayPointIndex>=wayPoints.Length)
            {
                currentWayPointIndex= 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWayPointIndex].transform.position,Time.deltaTime*speed);
    }
}
