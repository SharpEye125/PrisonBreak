using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDPlayerSwitch : MonoBehaviour
{
    public Button ButtonS;
    public Button ButtonM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Main Camera").GetComponent<PlayerSwitching>().target == GameObject.Find("Main Camera").GetComponent<PlayerSwitching>().Smart)
        {
            ButtonS.gameObject.GetComponent<Button>().interactable = false;
            ButtonM.gameObject.GetComponent<Button>().interactable = true;
        }
        if (GameObject.Find("Main Camera").GetComponent<PlayerSwitching>().target == GameObject.Find("Main Camera").GetComponent<PlayerSwitching>().Brawn)
        {
            ButtonS.gameObject.GetComponent<Button>().interactable = true;
            ButtonM.gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void SanchezButton()
    {
        GameObject.Find("Main Camera").GetComponent<PlayerSwitching>().switchMarty();
    }
    public void MartyButton()
    {
        GameObject.Find("Main Camera").GetComponent<PlayerSwitching>().switchSanchez();
    }
}
