using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndDialogueSystem : MonoBehaviour
{
    public Animator anim;
    public TextMeshProUGUI tekst;
    public float predkoscTekstu;
    int index;
    string[] slowa;

    [Header("Do ustawienia w innym skrypcie")]
    public string[] win;
    public string[] lose;
    public bool Won = false;

    public void Gadaj()
    {
        if(Won)
            slowa = win;
        else
            slowa = lose;

        // this.gameObject.SetActive(true);
        anim.SetTrigger("On");
        tekst.text = string.Empty;
        StartCoroutine(Zacznij());
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
            if(slowa == win)
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + " Finnished", 1);
                anim.SetTrigger("Off");
                Invoke("GotoMainScene", 1f);
            }
            else if(slowa == lose)
            {
                anim.SetTrigger("Off");
                Invoke("Reload", 1f);
            }
            // anim.SetTrigger("Off");
            // this.gameObject.GetComponent<DialogueSystem>().enabled = false;
        }
     }

     void Reload()
     {
        Przejscie.NextScene = SceneManager.GetActiveScene().name;
        Przejscie.SceneLoad();
     }

     void GotoMainScene()
     {
        Przejscie.NextScene = "Map";
        Przejscie.SceneLoad();
        
     }
}
