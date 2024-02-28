using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetButtonDown("Skip"))
        {
            Przejscie.NextScene = "Map";
            Przejscie.SceneLoad();
        }
    }

    // public void GoToMenu()
    // {
    //     Przejscie.NextScene = "Menu";
    //     Przejscie.SceneLoad();
    // }
}
