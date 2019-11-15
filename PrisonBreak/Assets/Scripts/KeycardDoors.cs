using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardDoors : MonoBehaviour
{
    public Transform Keycard;
    public Transform Doors;
    public float Range = 3;
    public float doorClose = 10.0f;
    public float timer = 0;
    public bool hasKeyCard = false;
    public bool startTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       Vector2 playerDistance = new Vector2(transform.position.x - Keycard.position.x,
            transform.position.y - Keycard.position.y);

        if (playerDistance.magnitude <= Range && Input.GetKeyDown(KeyCode.E))
        {
            hasKeyCard = true;
            KeycardDisable();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Doors" && hasKeyCard == true)
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public void KeycardEnable()
    {
        Keycard.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Keycard.gameObject.GetComponent<PopUpActionText>().enabled = true;
        Keycard.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void KeycardDisable()
    {
        Keycard.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Keycard.gameObject.GetComponent<PopUpActionText>().enabled = false;
        Keycard.gameObject.GetComponent<BoxCollider2D>().enabled = false;

    }
}
