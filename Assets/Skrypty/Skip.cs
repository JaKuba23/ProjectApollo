using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetButtonDown("Skip"))
            SceneManager.LoadScene("Menu");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
