using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 2.0f;
    public float paceSpeed = 1.5f;
    public float paceDistance = 3.0f;
    public float chaseTriggerDistance = 5.0f;
    public Vector2 paceDirection;
    Vector3 startPosition;
    bool home = true;
    bool grudge = false;
    public bool grudgeType;
    public bool normalType;
    public float grudgeStart = 15.0f;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x,
            player.position.y - transform.position.y);
        if (chaseDirection.magnitude < chaseTriggerDistance && grudge == true && timer > grudgeStart && grudgeType == true)
        {
            Chase();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "MPlayerAttack" || gameObject.tag == "SPlayerAttack");
        {
            if (grudgeType == true)
            {
                timer += Time.deltaTime;
                grudge = true;
            }
        }
    }

    void Chase()
    {
        home = false;
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x,
            player.position.y - transform.position.y);
        chaseDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
    }

    void GoHome()
    {
        Vector2 homeDirection = new Vector2(startPosition.x - transform.position.x,
            startPosition.y - transform.position.y);
        if (homeDirection.magnitude < 0.2f)
        {
            transform.position = startPosition;
            home = true;
        }
        else
        {
            homeDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = homeDirection * paceSpeed;
        }
    }
}
