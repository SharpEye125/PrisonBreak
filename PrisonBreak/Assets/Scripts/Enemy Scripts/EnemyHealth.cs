using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Ehealth = 5;
    public GameObject prefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MPlayerAttack")
        {
            Ehealth--;
            if (Ehealth < 1)
            {
                Destroy(gameObject);
                Instantiate (prefab, transform.position, Quaternion.identity);
            }
        }
        if (collision.tag == "SPlayerAttack")
        {
            Ehealth--;
            Ehealth--;
            if (Ehealth < 1)
            {
                Destroy(gameObject);
                Instantiate(prefab, transform.position, Quaternion.identity);
            }
        }
    }
}
