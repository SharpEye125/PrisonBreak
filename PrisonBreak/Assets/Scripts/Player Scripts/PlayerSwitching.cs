using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitching : MonoBehaviour
{
    public Transform Smart;
    public Transform Brawn;
    bool smart = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Space"))
        {
            SwitchPlayers();
        }
    }
    void SwitchPlayers()
    {
        if (smart = true)
        {
            
            transform.position = new Vector3(Brawn.position.x,
    Brawn.position.y, transform.position.z);
            smart = false;
        }
        else if (smart = false)
        {
            transform.position = new Vector3(Smart.position.x,
    Smart.position.y, transform.position.z);
            smart = true;
        }
    }

}
