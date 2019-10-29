using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodyguard : MonoBehaviour
{
    public Transform Smart;
    public Transform Brawn;
    public float startTriggerRange = 3.0f;
    public float followDistance = 10.0f;
    public float tooClose = 5.0f;
    public float followSpeed = 2.0f;
    public bool guardMe = false;
    // Start is called before the first frame update
    void Start()
    {
        guardMe = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 followDirection = new Vector2(Smart.position.x - Brawn.position.x,
            Smart.position.y - Brawn.position.y);
        if (Input.GetKeyDown(KeyCode.G))
        {
            GuardEnabler();
        }
        if (followDirection.magnitude < startTriggerRange && guardMe == true && followDirection.magnitude > tooClose)
        {
            Guard();
        }
    }
    void Guard()
    {

            Vector2 followDirection = new Vector2(Smart.position.x - Brawn.position.x,
                Smart.position.y - Brawn.position.y);
            followDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = followDirection * followSpeed;

    }
    void GuardEnabler()
    {
        if (guardMe == false)
        {
            guardMe = true;
        }
        else
        {
            guardMe = false;
        }
    }
}
