using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    public int levels;
    // Start is called before the first frame update
    void Start()
    {
        levels = PlayerPrefs.GetInt("levels");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NextLevel")
        {
            levels++;
            PlayerPrefs.GetInt("levels", levels);
            switch (levels)
            {
                case 2:
                    SceneManager.LoadScene("Level 2");
                    break;
                case 3:
                    SceneManager.LoadScene("Level 3");
                    break;
                case 4:
                    SceneManager.LoadScene("Level 4");
                    break;
                case 5:
                    SceneManager.LoadScene("Win");
                    break;
            }
        }
    }
}
