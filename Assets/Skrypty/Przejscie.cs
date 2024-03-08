using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Przejscie : MonoBehaviour
{
    [SerializeField] AudioClip wind;
    AudioSource effect;
    Animator anim;
    public static string NextScene;
    void Start()
    {
        effect = GameObject.FindGameObjectWithTag("Effect").GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        effect.PlayOneShot(wind);
        Invoke("Poczatek",1f);
    }

    void Poczatek()
    {
        AudioSource effec = GameObject.FindGameObjectWithTag("Effect").GetComponent<AudioSource>();
        anim.SetBool("on", false);
        effec.Stop();
    }

    public static void SceneLoad()
    {
        AudioSource effec = GameObject.FindGameObjectWithTag("Effect").GetComponent<AudioSource>();
        Przejscie skip = GameObject.FindGameObjectWithTag("przejscie").GetComponent<Przejscie>();
        skip.anim.SetBool("on", true);
        AudioClip wind = effec.gameObject.GetComponent<DontDestroy>().wind;
        effec.PlayOneShot(wind);
        skip.Invoke("Load", 1.5f);
    }

    void Load()
    {
        AudioSource effec = GameObject.FindGameObjectWithTag("Effect").GetComponent<AudioSource>();
        SceneManager.LoadScene(NextScene);
        effec.Stop();
    }
}
