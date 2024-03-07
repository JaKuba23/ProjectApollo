using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBuilding : MonoBehaviour
{
    public GameObject building;
    string nazwa = "";
    void Start()
    {

        switch(building.transform.name)
        {
            case "Centrum Kosmiczne":
                nazwa = "Trening Kadetow";
                break;
            
            case "Testy Pojazdow Ksiezycowych":
                nazwa = "Symulator Rakiety";
                break;
            
            case "ILC Dover":
                nazwa = "Sortowanie";
                // Debug.Log("Dupa");
                break;
            
            case "Aeroproject Corporation":
                nazwa = "Paliwo";
                break;
            
            case "Start Rakiety":
                nazwa = "End";
                break;
        }

        if(PlayerPrefs.GetInt(nazwa + " Finnished") == 1)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
