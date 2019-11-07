using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int levels = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = true;
        levels = PlayerPrefs.GetInt("levels");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
        PlayerPrefs.SetInt("levels", 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Select");
        GetComponent<Canvas>().enabled = false;
    }
    public void ContinueGame()
    {
        switch (levels)
        {
            case 1:
                SceneManager.LoadScene("Level 1");
                break;
            case 2:
                SceneManager.LoadScene("Level 2");
                break;
            case 3:
                SceneManager.LoadScene("Level 3");
                break;
            case 4:
                SceneManager.LoadScene("Level 4");
                break;
        }
    }
}
