using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startTheEnding : MonoBehaviour
{
    [SerializeField] AudioClip engine;
    AudioSource effect;
    public GameObject fire;
    public int count = 0;
    void Start()
    {
        effect = GameObject.FindGameObjectWithTag("Effect").GetComponent<AudioSource>();
        transform.rotation = Quaternion.Euler(0,0,0);
        fire.SetActive(false);
    }

    void Update()
    {
        if(count == 4)
        {
            StartCoroutine("XD");
        }
    }

    IEnumerator XD()
    {
        effect.PlayOneShot(engine);
        GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(10f);
        Przejscie.NextScene="End";
        Przejscie.SceneLoad();
    }
}
