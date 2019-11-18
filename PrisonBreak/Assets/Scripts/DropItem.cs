using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public Transform Item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SPlayerAttack" || collision.gameObject.tag == "MPlayerAttack")
        {

            if (gameObject.GetComponent<EnemyHealth>().Ehealth < 1)
            {
                Instantiate(Item);
            }
        }
    }
}
