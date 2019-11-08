using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;

public class PatrolBehavior : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 2f;

    int waypointIndex = 0;
    float waitTime = 3f;
    float timer = 0;
    public Transform target;

    [SerializeField]
    public float chaseSpeed = 9f;

    public float nextWaypointDistance = 3f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    public GameObject MPlayerAttack;
    public GameObject SPlayerAttack;
    public Transform Marty;
    public Transform Sanchez;
    bool isChasing;
    string tarName;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        target = waypoints[0];
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime && !isChasing)
        {
            //Move();

        }
        else if (isChasing == true)
        {
            if (tarName == "MPlayerAttack")
            {
                target = Marty;
            }
            if (tarName == "SPlayerAttack")
            {
                target = Sanchez;
            }
            Debug.Log("set target");
            //seeker.StartPath(rb.position, target.position, OnPathComplete);
            
        }
        if (path == null)
        {
            Debug.Log("null path");
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            Debug.Log("count");
            reachedEndOfPath = true;
            return;
        }
        else
        {
            Debug.Log("end of path");
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * chaseSpeed * Time.deltaTime;

        rb.AddForce(force * moveSpeed);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        Debug.Log(distance < nextWaypointDistance);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;

        }
    }
    private void OnCollisionEnter2D(Collision2D collisonInfo)
    {
        if(collisonInfo.collider.tag == "MPlayerAttack")
        {
            Debug.Log("here");
            target = Marty;
            tarName = collisonInfo.collider.tag;
            seeker.StartPath(rb.position, target.position, OnPathComplete);
            isChasing = true;
            currentWaypoint = 0;
        }
        if (collisonInfo.collider.tag == "SPlayerAttack")
        {
            target = Sanchez;
            tarName = collisonInfo.collider.tag;
            seeker.StartPath(rb.position, target.position, OnPathComplete);
            isChasing = true;
            currentWaypoint = 0;
        }
    }
    
    
    void Move()
    {
        //transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < 0.1f)
        {
            waypointIndex += 1;
            timer = 0;
            rb.velocity = Vector2.zero;
        }
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
        target = waypoints[waypointIndex];
    }
   
   
}
