using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform Marty;
    public Transform Sanchez;
    public Transform target;
    public float bulletSpeed = 5.0f;
    public GameObject Attack;
    public float bulletLifetime = 1.0f;
    public float shootDelay = 1.0f;
    float timer = 0;
    public float targetFinding = 6;
    public float shootFinding = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 sanchezDistance = new Vector2(Sanchez.position.x - transform.position.x,
                Sanchez.position.y - transform.position.y);
        Vector2 martyDistance = new Vector2(Marty.position.x - transform.position.x,
                Marty.position.y - transform.position.y);
        if (martyDistance.magnitude <= gameObject.GetComponent<NormalEnemyAI>().chaseTriggerDistance)
        {
            target = Marty;
        }
        if (sanchezDistance.magnitude <= gameObject.GetComponent<NormalEnemyAI>().chaseTriggerDistance)
        {
            target = Sanchez;
        }


        timer += Time.deltaTime;
        if (timer > shootDelay)
        {
            Vector2 shootDir = new Vector2(target.position.x - transform.position.x,
                target.position.y - transform.position.y);
            timer = 0;
            if (shootDir.magnitude <= shootFinding )
            {
            GameObject bullet = Instantiate(Attack, transform.position, Quaternion.identity);
            shootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            Destroy(bullet, bulletLifetime);
            }
        }

    }
}
