using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public EndDialogueSystem endPanel;
    public float pkt;
    public StrefaBehaviour sb;
    public StrefaBehaviour sb2;
    public TMP_Text text;
    public float time;

    void Start()
    {
        text.text = Mathf.Floor(time).ToString();
    }
    void Update()
    {
        if(Mathf.Floor(time) >= 0)
        {
            text.text = Mathf.Floor(time).ToString();
            time -= Time.deltaTime;
            sb.enabled = true;
            sb2.enabled = true;
        }
        else
        {
            sb.rb.velocity = Vector2.zero;
            sb2.rb.velocity = Vector2.zero;
            sb.enabled = false;
            sb2.enabled = false;
            endPanel.enabled = true;
            if(text.text == "0" && sb2.licznik + sb.licznik <= pkt)
            {
                endPanel.Won = true;
            }
            endPanel.Gadaj();
            this.gameObject.SetActive(false);
            // SceneManager.LoadScene("Map");
        }
    }
}
