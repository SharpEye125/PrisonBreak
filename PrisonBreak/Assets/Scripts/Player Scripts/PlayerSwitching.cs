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
        if (Brawn.transform != Smart.transform)
        {
        Brawn.gameObject.GetComponent<PlayerMovement>().enabled = false;
        Brawn.gameObject.GetComponent<PlayerAnimationScript>().enabled = false;
        }
        else if (Smart.transform == Brawn.transform)
        {
            Brawn.gameObject.GetComponent<PlayerMovement>().enabled = true;
            Brawn.gameObject.GetComponent<PlayerAnimationScript>().enabled = true;
        }
        
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
        if (target == Smart)
        {
            Smart.gameObject.GetComponent<PlayerHP>().canSleep = true;
        }
        else
        {
            Smart.gameObject.GetComponent<PlayerHP>().canSleep = false;
        }
        if (target == Brawn)
        {
            Brawn.gameObject.GetComponent<PlayerHP>().canSleep = true;
        }
        else
        {
            Brawn.gameObject.GetComponent<PlayerHP>().canSleep = false;
        }
    }
    void SwitchPlayers()
    {
        //Switches it to Sanchez
        if(target == Smart && timer > switchDelay && Time.timeScale > 0)
        {
            timer = 0;

            switchSanchez();
        }
        //Switches it to Marty
        else if(target == Brawn && timer > switchDelay && Time.timeScale > 0)
        {
            timer = 0;

            switchMarty();
        }
    }
    void switchSanchez()
    {
        target = Brawn;
        if (Smart.gameObject.GetComponent<PlayerHP>().sleeping == false)
        {
            DisableMarty();
            EnableSanchez();
        }
        else if (Smart.gameObject.GetComponent<PlayerHP>().sleeping == true)
        {
            EnableSanchez();
        }
    }
    void switchMarty()
    {
        if (Brawn.gameObject.GetComponent<PlayerHP>().sleeping == false)
        {
            DisableSanchez();
            EnableMarty();
        }
        else if (Brawn.gameObject.GetComponent<PlayerHP>().sleeping == true)
        {
            EnableMarty();
        }

        target = Smart;
    }

    public void DisableSanchez()
    {
        Brawn.gameObject.GetComponent<PlayerMovement>().enabled = false;
        Brawn.gameObject.GetComponent<PlayerAttack>().enabled = false;
        Brawn.gameObject.GetComponent<PlayerAnimationScript>().enabled = false;
    }
    public void EnableSanchez()
    {
        Brawn.gameObject.GetComponent<PlayerAnimationScript>().enabled = true;
        Brawn.gameObject.GetComponent<PlayerAttack>().enabled = true;
        Brawn.gameObject.GetComponent<PlayerMovement>().enabled = true;
    }

    public void DisableMarty()
    {
        Smart.gameObject.GetComponent<PlayerMovement>().enabled = false;
        Smart.gameObject.GetComponent<PlayerAttack>().enabled = false;
        Smart.gameObject.GetComponent<PlayerAnimationScript>().enabled = false;
    }
    public void EnableMarty()
    {
        Smart.gameObject.GetComponent<PlayerAnimationScript>().enabled = true;
        Smart.gameObject.GetComponent<PlayerAttack>().enabled = true;
        Smart.gameObject.GetComponent<PlayerMovement>().enabled = true;
        
    }

}
