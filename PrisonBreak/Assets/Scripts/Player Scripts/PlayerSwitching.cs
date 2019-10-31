using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitching : MonoBehaviour
{
    public Transform Smart;
    public Transform Brawn;
    public Transform target;
    public float switchDelay = 0.5f;
    float timer = 0;
    public float switchSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        target = Smart;
        Brawn.gameObject.GetComponent<PlayerMovement>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchPlayers();
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x,
    target.position.y, transform.position.z), switchSpeed);
    }
    void SwitchPlayers()
    {
        if(target == Smart && timer > switchDelay && Time.timeScale > 0)
        {
            timer = 0;
            target = Brawn;
            Smart.gameObject.GetComponent<PlayerMovement>().enabled = false;
            Brawn.gameObject.GetComponent<PlayerMovement>().enabled = true;
            Smart.gameObject.GetComponent<PlayerAttack>().enabled = false;
            Brawn.gameObject.GetComponent<PlayerAttack>().enabled = true;
        }
        else if(target == Brawn && timer > switchDelay && Time.timeScale > 0)
        {
            timer = 0;
            target = Smart;
            Smart.gameObject.GetComponent<PlayerMovement>().enabled = true;
            Brawn.gameObject.GetComponent<PlayerMovement>().enabled = false;
            Smart.gameObject.GetComponent<PlayerAttack>().enabled = true;
            Brawn.gameObject.GetComponent<PlayerAttack>().enabled = false;
        }
    }

}
