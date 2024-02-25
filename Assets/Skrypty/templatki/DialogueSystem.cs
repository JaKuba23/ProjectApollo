using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public Animator anim;
    public TextMeshProUGUI tekst;
    public string[] slowa;
    public float predkoscTekstu;
    int index;

    void Awake()
    {
        // Debug.Log(SceneManager.GetActiveScene().name + " Loaded");
        Invoke("WakeUp", 1.5f);
    }

    void WakeUp()
    {
        if(!(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + " Loaded")==1))
        {
            this.gameObject.SetActive(true);
            anim.SetTrigger("On");
            tekst.text = string.Empty;
            StartCoroutine(Zacznij());
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator Zacznij()
    {
        yield return new WaitForSeconds(1);
        StartDialogue();
    }

    void Update()
    {
        if(Input.GetButtonDown("Skip"))
        {
            if(tekst.text == slowa[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                tekst.text = slowa[index];
            }
        }
    }

     void StartDialogue()
     {
        index = 0;
        StartCoroutine(WypiszSlowa());
     }

     IEnumerator WypiszSlowa()
     {
        foreach (var s in slowa[index].ToCharArray())
        {
            tekst.text += s;
            yield return new WaitForSeconds(predkoscTekstu);
        }
     }

     void  NextLine()
     {
        if(index < slowa.Length-1)
        {
            index++;
            tekst.text = string.Empty;
            StartCoroutine(WypiszSlowa());
        }
        else
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + " Loaded", 1);
            anim.SetTrigger("Off");
            this.gameObject.GetComponent<DialogueSystem>().enabled = false;
        }
     }
}
