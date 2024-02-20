using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject dialog;
    public EndDialogueSystem endPanel;
    public GameObject EnemySpawner;
    public TMP_Text text;
    public float time;

    void Start()
    {
        text.text = Mathf.Floor(time).ToString();
    }
    void Update()
    {
        if(dialog.GetComponent<DialogueSystem>().enabled == true && dialog.activeSelf == true)
            return;

        if(Mathf.Floor(time) >= 0)
        {
            text.text = Mathf.Floor(time).ToString();
            time -= Time.deltaTime;
        }
        else
        {
            //zatrzymaj gre
            EnemySpawner.SetActive(false);
            //wlaczyc panel
            endPanel.gameObject.SetActive(true);
            // endPanel.enabled = true;
            //czy wygral czy prezgral
            endPanel.Won = true;
            //zacznij dialog
            endPanel.Gadaj();
            this.gameObject.SetActive(false);
        }
    }
}
