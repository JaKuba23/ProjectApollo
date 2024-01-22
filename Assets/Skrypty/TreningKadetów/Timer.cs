using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
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
            sb.enabled = true;
            sb2.enabled = true;
            // SceneManager.LoadScene("Map");
        }
    }
}
