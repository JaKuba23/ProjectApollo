using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Done : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = this.gameObject.GetComponent<TextMeshProUGUI>();
        text.text = (PlayerPrefs.GetInt("Trening Kadetow Finnished") + PlayerPrefs.GetInt("Sortowanie Finnished") + PlayerPrefs.GetInt("Paliwo Finnished") + PlayerPrefs.GetInt("Symulator Rakiety Finnished")).ToString() + "/4";
    }
}
