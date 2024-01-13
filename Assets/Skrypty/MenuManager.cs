using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public void NewGame()
    {
        //Czy już był na tych poziomach żeby się cutscenka 2 razy na gre nei wyświetlałą
        PlayerPrefs.SetInt("Map Loaded", 0);
        PlayerPrefs.SetInt("Centrum Kosmiczne Loaded", 0);
        PlayerPrefs.SetInt("Przyladek Loaded", 0);
        PlayerPrefs.SetInt("VAB Loaded", 0);
        PlayerPrefs.SetInt("ILC Dover Loaded", 0);
        PlayerPrefs.SetInt("Testy Pojazdow Ksiezycowych Loaded", 0);
        PlayerPrefs.SetInt("Aeroproject Corporation Loaded", 0);
        //tutaj to samo z tym czy ktoś przeszedł już ten level
        PlayerPrefs.SetInt("Centrum Kosmiczne Finnished", 0);
        PlayerPrefs.SetInt("Przyladek Finnished", 0);
        PlayerPrefs.SetInt("VAB Finnished", 0);
        PlayerPrefs.SetInt("ILC Dover Finnished", 0);
        PlayerPrefs.SetInt("Testy Pojazdow Ksiezycowych Finnished", 0);
        PlayerPrefs.SetInt("Aeroproject Corporation Finnished", 0);

        SceneManager.LoadScene("Map");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Map");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
