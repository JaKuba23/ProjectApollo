using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startTheEnding : MonoBehaviour
{
    public GameObject fire;
    public int count = 0;
    void Start()
    {
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
        GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1.4f);
        Przejscie.NextScene="End";
        Przejscie.SceneLoad();
    }
}
