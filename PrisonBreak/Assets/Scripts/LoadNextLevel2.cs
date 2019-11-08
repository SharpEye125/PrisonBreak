using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLeve2 : MonoBehaviour
{
    public int NLT = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "NextLT")
        {
            NLT++;
            if(NLT == 1)
            {
                SceneManager.LoadScene("Level 4");
            }
        }
    }

}
