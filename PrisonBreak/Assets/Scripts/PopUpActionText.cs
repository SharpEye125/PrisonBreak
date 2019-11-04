using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpActionText : MonoBehaviour
{
    public Transform Camera;
    public float showUpDistance = 5.0f;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerDir = new Vector2(Camera.gameObject.GetComponent<PlayerSwitching>().target.position.x - transform.position.x,
                   Camera.gameObject.GetComponent<PlayerSwitching>().target.position.y - transform.position.y);
        if (playerDir.magnitude >= showUpDistance)
        {
            
        }
        else
        {
            
        }
    }
}
