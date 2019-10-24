using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitching : MonoBehaviour
{
    public Transform Smart;
    public Transform Brawn;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = Smart;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchPlayers();
        }
        transform.position = new Vector3(target.position.x,
    target.position.y, transform.position.z);
    }
    void SwitchPlayers()
    {
        if(target == Smart)
        {
            target = Brawn;
            
        }
        else
        {
            target = Smart;
        }
    }

}
