using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 2f;

    int waypointIndex = 0;
    float waitTime = 3f;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > waitTime)
        {
            Move ();

        }
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
            timer = 0;
        }
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
