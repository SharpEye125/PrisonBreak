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
    public Text repText;
    public int reputation = 0;
    public int playerToughness = 10;
    public Transform deathPoint;
    public float continuousContact = 1;
    float contactTimer = 0.0f;
    bool contact;
    bool sleeping = false;
    public float startSleepingRange = 1;
    public float sleepDuration = 30.0f;
    float sleepTimer = 0;


    void Start()
    {
        healthText.text = "Health: " + health;
        healthSlider.maxValue = health;
        healthSlider.value = health;
        UpdateRepAndTough();
    }
    void Update()
    {
        if (contact == true)
        {
            contactTimer += Time.deltaTime;
        }
        else if (contact == false)
        {
            contactTimer = 0.0f;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SleepEnabler();
        }
        Vector2 bedDistance = new Vector2(transform.position.x - deathPoint.position.x,
            transform.position.y - deathPoint.position.y);
        if (bedDistance.magnitude <= startSleepingRange && sleeping == true)
        {
            Sleep();
            sleepTimer += Time.deltaTime;
        }
    }
    //Enemy Contact
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !contact)
        {
            health--;
            UpdateHP();
            if (health < 1)
            {
                transform.position = new Vector3(deathPoint.position.x,
                    deathPoint.position.y, transform.position.z);
                playerToughness--;
                if (playerToughness >= collision.gameObject.GetComponent<EnemyHealth>().enemyToughness)
                {
                    playerToughness--;
                }
                UpdateRepAndTough();
                health = maxHealth / 2;
                UpdateHP();
            }
        }
    }
    //Damages you if you stay in contact
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            contact = true;
            if (contactTimer >= continuousContact)
            {
                contactTimer = 0;
                health--;
                UpdateHP();
                if (health < 1)
                {
                    transform.position = new Vector3(deathPoint.position.x,
                        deathPoint.position.y, transform.position.z);
                    playerToughness--;
                    if (playerToughness >= collision.gameObject.GetComponent<EnemyHealth>().enemyToughness)
                    {
                        playerToughness--;
                    }
                    UpdateRepAndTough();
                    health = maxHealth / 2;
                    UpdateHP();
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            contact = false;
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
                UpdateHP();
            }
        }
        //Enemy Bullets
        if (collision.tag == "Enemy")
        {
            health--;
            UpdateHP();
            if (health < 1)
            {

            }
        }
    }
    public void UpdateHP()
    {
        healthText.text = "Health: " + health;
        healthSlider.value = health;
    }
    public void UpdateRepAndTough()
    {
        toughText.text = "Toughness: " + playerToughness;
        repText.text = "Reputation: " + reputation;
    }
    void Sleep()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PlayerAnimationScript>().enabled = false;
        transform.position = new Vector3(deathPoint.position.x,
                        deathPoint.position.y, transform.position.z);

        if (sleepTimer >= sleepDuration)
        {
            sleepTimer = 0;
            if (health <= maxHealth)
            {
                health++;
                UpdateHP();
            }
        }
    }
    void SleepEnabler()
    {
        Vector2 bedDistance = new Vector2(transform.position.x - deathPoint.position.x,
            transform.position.y - deathPoint.position.y);
        if (sleeping == false)
        {
            if (bedDistance.magnitude <= startSleepingRange)
            {
                sleeping = true;
            }
        }
        else
        {
            sleeping = false;
            gameObject.GetComponent<PlayerMovement>().enabled = true;
            gameObject.GetComponent<PlayerAnimationScript>().enabled = true;
        }
    }
}
