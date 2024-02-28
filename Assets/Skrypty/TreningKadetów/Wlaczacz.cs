using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Wlaczacz : MonoBehaviour
{
    public TMP_Text text;
    public DialogueSystem system;
    public StrefaBehaviour sb;
    public StrefaBehaviour sb2;
    public SymulatorTimer timer;

    void Start()
    {
        if(!(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + " Loaded")==1))
        {
            sb.enabled = false;
            sb2.enabled = false;
            timer.enabled = false;
        }
        else
        {
            sb.enabled = false;
            sb2.enabled = false;
            timer.enabled = false;
            StartCoroutine(Run());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + " Loaded")==1)
        {
            StartCoroutine(Run());
            this.GetComponent<Wlaczacz>().enabled = false;
        }
    }

    IEnumerator Run()
    {
        text.text = "3";
        yield return new WaitForSeconds(1f);
        text.text = "2";
        yield return new WaitForSeconds(1f);
        text.text = "1";
        yield return new WaitForSeconds(1f);
        text.text = "0";
        yield return new WaitForSeconds(1f);
        sb.enabled = true;
        sb2.enabled = true;
        timer.enabled = true;
    }
}
