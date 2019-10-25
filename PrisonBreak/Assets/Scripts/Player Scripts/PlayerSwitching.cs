﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitching : MonoBehaviour
{
    public Transform Smart;
    public Transform Brawn;
    Transform target;
    public float switchDelay = 0.5f;
    float timer = 0;
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
        transform.position = new Vector3(target.position.x,
    target.position.y, transform.position.z);
    }
    void SwitchPlayers()
    {
        if(target == Smart && timer > switchDelay)
        {
            timer = 0;
            target = Brawn;
            Smart.gameObject.GetComponent<PlayerMovement>().enabled = false;
            Brawn.gameObject.GetComponent<PlayerMovement>().enabled = true;
        }
        else if(target == Brawn && timer > switchDelay)
        {
            timer = 0;
            target = Smart;
            Smart.gameObject.GetComponent<PlayerMovement>().enabled = true;
            Brawn.gameObject.GetComponent<PlayerMovement>().enabled = false;
        }
    }

}
