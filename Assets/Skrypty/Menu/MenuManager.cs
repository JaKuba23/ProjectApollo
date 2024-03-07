using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject ErrorG;
    AudioSource effect;
    [SerializeField] AudioClip click;
    public Animator exit;
    public Animator start;
    public Animator options;
    public Animator dalej;

    void Awake()
    {
        if(PlayerPrefs.GetInt("FirstGame Loaded") != 1)
            PlayerPrefs.SetInt("FirstGame Loaded", 0);
        effect = GameObject.FindGameObjectWithTag("Effect").GetComponent<AudioSource>();
    }
    public void NewGame()
    {
        PlayerPrefs.SetInt("FirstGame Loaded", 1);
        //Zoptymalizuj to z listą nazw wsyztskich poziomów. <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        //Czy już był na tych poziomach żeby się cutscenka 2 razy na gre nei wyświetlałą
        //budynki
        PlayerPrefs.SetInt("Map Loaded", 0);
        PlayerPrefs.SetInt("Centrum Kosmiczne Loaded", 0);
        PlayerPrefs.SetInt("Przyladek Loaded", 0);
        PlayerPrefs.SetInt("VAB Loaded", 0);
        PlayerPrefs.SetInt("ILC Dover Loaded", 0);
        PlayerPrefs.SetInt("Testy Pojazdow Ksiezycowych Loaded", 0);
        PlayerPrefs.SetInt("Aeroproject Corporation Loaded", 0);
        PlayerPrefs.SetInt("Start Rakiety Loaded", 0);
        PlayerPrefs.SetInt("Symulator Rakiety Loaded", 0);
        //minigry
        PlayerPrefs.SetInt("Trening Kadetow Loaded", 0);
        PlayerPrefs.SetInt("Sortowanie Loaded", 0);
        PlayerPrefs.SetInt("Paliwo Loaded", 0);
        PlayerPrefs.SetInt("Symulator Rakiety Loaded", 0);
        //tutaj to samo z tym czy ktoś przeszedł już ten level
        PlayerPrefs.SetInt("Trening Kadetow Finnished", 0);
        PlayerPrefs.SetInt("Sortowanie Finnished", 0);
        PlayerPrefs.SetInt("Paliwo Finnished", 0);
        PlayerPrefs.SetInt("Symulator Rakiety Finnished", 0);

        Przejscie.NextScene = "Prolog";
        Przejscie.SceneLoad();
    }

    public void LoadGame()
    {
        if(PlayerPrefs.GetInt("FirstGame Loaded") != 1)
            {
                Error.error = "Nie możesz załadowac gry ponieważ grasz w nią po raz pierwszy";
                ErrorG.SetActive(true);
            }
        Przejscie.NextScene = "Map";
        Przejscie.SceneLoad();
    }

    public void Exit()
    {
        Application.Quit();
    } 
    public void ExitPoinetrEnter()
    {
        exit.SetTrigger("on");
    }

    public void ExitPoinetrExit()
    {
        exit.SetTrigger("off");
    }

    public void StartPoinetrExit()
    {
        start.SetTrigger("off");
    }

    public void StartPoinetrEnter()
    {
        start.SetTrigger("on");
    }

    public void OptionsPoinetrExit()
    {
        options.SetTrigger("off");
    }

    public void OptionsPoinetrEnter()
    {
        options.SetTrigger("on");
    }

    public void DalejPoinetrExit()
    {
        dalej.SetTrigger("off");
    }

    public void DalejPoinetrEnter()
    {
        dalej.SetTrigger("on");
    }

    public void Click()
    {
        effect.PlayOneShot(click);
    }
    
}
