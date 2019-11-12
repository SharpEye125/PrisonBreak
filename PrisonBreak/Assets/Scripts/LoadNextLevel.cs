using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public int levels;

    void Start()
    {
        levels = PlayerPrefs.GetInt("levels");
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NextLevel")
        {
            
            levels++;
            PlayerPrefs.GetInt("levels", levels);
            switch (levels)
            {
                case 1:

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
}
