using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public int levels;
    public Button LevelOne;
    public Button LevelTwo;
    public Button LevelThree;
    public Button LevelFour;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = true;
        levels = PlayerPrefs.GetInt("levels");
        switch (levels)
        {
            case 1:
                LevelOne.gameObject.GetComponent<Button>().interactable = true;
                LevelTwo.gameObject.GetComponent<Button>().interactable = false;
                LevelThree.gameObject.GetComponent<Button>().interactable = false;
                LevelFour.gameObject.GetComponent<Button>().interactable = false;
                break;
            case 2:
                LevelOne.gameObject.GetComponent<Button>().interactable = true;
                LevelTwo.gameObject.GetComponent<Button>().interactable = true;
                LevelThree.gameObject.GetComponent<Button>().interactable = false;
                LevelFour.gameObject.GetComponent<Button>().interactable = false;
                break;
            case 3:
                LevelOne.gameObject.GetComponent<Button>().interactable = true;
                LevelTwo.gameObject.GetComponent<Button>().interactable = true;
                LevelThree.gameObject.GetComponent<Button>().interactable = true;
                LevelFour.gameObject.GetComponent<Button>().interactable = false;
                break;
            case 4:
                LevelOne.gameObject.GetComponent<Button>().interactable = true;
                LevelTwo.gameObject.GetComponent<Button>().interactable = true;
                LevelThree.gameObject.GetComponent<Button>().interactable = true;
                LevelFour.gameObject.GetComponent<Button>().interactable = true;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Level2()
    {
        
        if (levels >= 2)
        {
            SceneManager.LoadScene("Level 2");
        }
        else if (levels < 2)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void Level3()
    {
        if (levels >= 3)
        {
            SceneManager.LoadScene("Level 3");
        }
        else if (levels < 3)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }

    }
    public void Level4()
    {
        if (levels >= 4)
        {
            SceneManager.LoadScene("Level 4");
        }
        else if (levels < 4)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
