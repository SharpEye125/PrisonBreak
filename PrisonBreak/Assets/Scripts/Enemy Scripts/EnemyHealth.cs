using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int Ehealth = 5;
    public int eMaxHealth = 5;
    public int MartyDamage = 1;
    public int SanchezDamage = 2;
    public int enemyToughness = 10;
    public Transform deathPoint;
    public Slider healthSlider;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MPlayerAttack")
        {
            Ehealth -= MartyDamage;
            if (Ehealth < 1)
            {
                enemyToughness--;
                GameObject.Find("Marty").GetComponent<PlayerHP>().playerToughness++;
                GameObject.Find("Marty").GetComponent<PlayerHP>().UpdateRepAndTough();
                if (gameObject.GetComponent<NormalEnemyAI>().grudgeType == true)
                {
                    gameObject.GetComponent<NormalEnemyAI>().grudge = true;
                    gameObject.GetComponent<NormalEnemyAI>().target = gameObject.GetComponent<NormalEnemyAI>().Marty;
                }
                transform.position = new Vector3(deathPoint.position.x,
                    deathPoint.position.y, transform.position.z);
                Ehealth = eMaxHealth;
                gameObject.GetComponent<NormalEnemyAI>().defeated = true;
            }
        }
        if (collision.tag == "SPlayerAttack")
        {
            Ehealth -= SanchezDamage;
            if (Ehealth < 1)
            {
                enemyToughness--;
                GameObject.Find("Sanchez").GetComponent<PlayerHP>().playerToughness++;
                GameObject.Find("Sanchez").GetComponent<PlayerHP>().UpdateRepAndTough();
                if (gameObject.GetComponent<NormalEnemyAI>().grudgeType == true)
                {
                    gameObject.GetComponent<NormalEnemyAI>().target = gameObject.GetComponent<NormalEnemyAI>().Sanchez;
                    gameObject.GetComponent<NormalEnemyAI>().grudge = true;
                    gameObject.GetComponent<NormalEnemyAI>().defeated = true;
                }
                transform.position = new Vector3(deathPoint.position.x,
                    deathPoint.position.y, transform.position.z);
                Ehealth = eMaxHealth;
                gameObject.GetComponent<NormalEnemyAI>().defeated = true;
            }
        }
    }
}
