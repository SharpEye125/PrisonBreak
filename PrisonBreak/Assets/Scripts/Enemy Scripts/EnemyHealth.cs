using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Ehealth = 5;
    public int MartyDamage = 1;
    public int SanchezDamage = 2;
    public int enemyToughness = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MPlayerAttack")
        {
            Ehealth -= MartyDamage;
            if (Ehealth < 1)
            {
                enemyToughness--;
                gameObject.GetComponent<NormalEnemyAI>().grudge = false;
                gameObject.GetComponent<NormalEnemyAI>().canAgro = false;
                GameObject.Find("Marty").GetComponent<PlayerHP>().playerToughness++;
            }
        }
        if (collision.tag == "SPlayerAttack")
        {
            Ehealth -= SanchezDamage;
            if (Ehealth < 1)
            {
                enemyToughness--;
                gameObject.GetComponent<NormalEnemyAI>().grudge = false;
                gameObject.GetComponent<NormalEnemyAI>().canAgro = false;
                GameObject.Find("Sanchez").GetComponent<PlayerHP>().playerToughness++;
            }
        }
    }
}
