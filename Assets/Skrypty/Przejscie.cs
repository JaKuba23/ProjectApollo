using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Przejscie : MonoBehaviour
{

    Animator anim;
    public static string NextScene;
    void Start()
    {
        anim = GetComponent<Animator>();
        Invoke("Poczatek",1f);
    }

    void Poczatek()
    {
        anim.SetBool("on", false);
    }

    public static void SceneLoad()
    {
        Przejscie skip = GameObject.FindGameObjectWithTag("przejscie").GetComponent<Przejscie>();
        skip.anim.SetBool("on", true);
        skip.Invoke("Load", 1.5f);
    }

    void Load()
    {
        SceneManager.LoadScene(NextScene);
    }
}
