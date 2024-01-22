using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public StrefaBehaviour sb;
    public StrefaBehaviour sb2;
    public TMP_Text text;
    public float time;
    public string[] lose;
    public string[] win;

    void Start()
    {
        text.text = Mathf.Floor(time).ToString();
    }
    void Update()
    {
        if(Mathf.Floor(time) > 0)
        {
            text.text = Mathf.Floor(time).ToString();
            time -= Time.deltaTime;
            sb.enabled = false;
            sb2.enabled = true;
        }
    }
}
