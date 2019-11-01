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
    public bool grudge = false;
    public bool grudgeType;
    public bool normalType;
    public float grudgeStart = 15.0f;
    public float timer = 0;
    public bool canAgro;
    public bool defeated;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 chaseDirection = new Vector2(GameObject.Find("Main Camera").GetComponent<PlayerSwitching>().target.position.x - transform.position.x,
            GameObject.Find("Main Camera").GetComponent<PlayerSwitching>().target.position.y - transform.position.y);
        //Just seperating to be able to read the if statement more easily
        if (chaseDirection.magnitude < chaseTriggerDistance && grudge == true && timer > grudgeStart && grudgeType == true 
            || chaseDirection.magnitude < chaseTriggerDistance && grudgeType == true && canAgro == true
            || chaseDirection.magnitude < chaseTriggerDistance && normalType == true && canAgro == true)
        {
            Chase();
        }
        if (grudge == true)
        {
            timer += Time.deltaTime;
        }
        if (timer >= grudgeStart && grudge == false)
        {
            timer = 0;
        }
        if (defeated == true)
        {
            canAgro = false;
            defeated = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MPlayerAttack" || collision.tag == "SPlayerAttack")
        {
            if (grudgeType == true)
            {
                timer += Time.deltaTime;
                canAgro = true;
            }
            else if (normalType == true)
            {
                canAgro = true;
            }
        }
    }

    void Chase()
    {
        Vector2 chaseDirection = new Vector2(GameObject.Find("Main Camera").GetComponent<PlayerSwitching>().target.position.x - transform.position.x,
            GameObject.Find("Main Camera").GetComponent<PlayerSwitching>().target.position.y - transform.position.y);
        chaseDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
    }

}
