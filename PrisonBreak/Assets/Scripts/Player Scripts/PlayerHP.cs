using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int health = 10;
    public int maxHealth = 10;
    public Text healthText;
    public Slider healthSlider;
    public Text toughText;
    public int reputation = 0;
    public int playerToughness = 10;
    public Transform deathPoint;
    

    void Start()
    {
        healthText.text = "Health: " + health;
        healthSlider.maxValue = health;
        healthSlider.value = health;
        toughText.text = "Toughness: " + playerToughness;
    }
    //Enemy Contact
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            updateHP();
            if (health < 1)
            {
                transform.position = new Vector3(deathPoint.position.x,
                    deathPoint.position.y, transform.position.z);
                playerToughness--;
                if (playerToughness >= collision.gameObject.GetComponent<EnemyHealth>().enemyToughness)
                {
                    playerToughness--;
                }
                    updateToughness();
                health = maxHealth / 2;
                updateHP();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Plus Health
        if (collision.gameObject.tag == "Health")
        {
            if (health < 10)
            {
                health++;
                Destroy(collision.gameObject);
                updateHP();
            }
        }
        //Enemy Bullets
        if (collision.tag == "Enemy")
        {
            health--;
            updateHP();
            if (health < 1)
            {

            }
        }
    }
    public void updateHP()
    {
        healthText.text = "Health: " + health;
        healthSlider.value = health;
    }
    public void updateToughness()
    {
        toughText.text = "Toughness: " + playerToughness;
    }
}
