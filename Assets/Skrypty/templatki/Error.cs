using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Error : MonoBehaviour
{
    public TextMeshProUGUI tekst;
    public static string error = "";
    void Update()
    {
        tekst.text = error;
        if(Input.GetButtonDown("Click"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
