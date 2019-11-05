using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpActionText : MonoBehaviour
{
    public float Range = 15.0f;
    public bool showUp = false;
    public string popUpText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerDirection = new Vector2(GameObject.Find("Main Camera").GetComponent<PlayerSwitching>().target.position.x - transform.position.x,
            GameObject.Find("Main Camera").GetComponent<PlayerSwitching>().target.position.y - transform.position.y);
        if (playerDirection.magnitude < Range)
        {
            showUp = true;
        }
        else 
        {
            showUp = false;
        }
        
    }
    void OnGUI()
    {
        if (showUp == true)
        {
            Vector3 getPixelPos = Camera.main.WorldToScreenPoint(transform.position + new Vector3(-1f, 1f, 0f));//<< WorldToScreenPoint( position + offset )
            getPixelPos.y = Screen.height - getPixelPos.y;
            GUI.color = Color.black;
            GUI.Label(new Rect(getPixelPos.x, getPixelPos.y, 200f, 100f), popUpText);
        }
    }
}
