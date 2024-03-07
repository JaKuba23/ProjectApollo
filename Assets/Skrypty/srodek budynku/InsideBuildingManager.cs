using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InsideBuildingManager : MonoBehaviour
{
    public GameObject dialog;
    public LayerMask layer;
    public Camera cam;

    void Update()
    {
        if(dialog.GetComponent<DialogueSystem>().enabled == true && dialog.activeSelf == true)
            return;
            
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 100, layer))
            {   
                if(hit.transform.name == "Drzwi")
                {
                    Przejscie.NextScene = "Map";
                    Przejscie.SceneLoad();
                }
                else if(hit.transform.name == "Graj")
                {
                    
                    switch(SceneManager.GetActiveScene().name)
                    {
                        case "Centrum Kosmiczne":
                            Przejscie.NextScene = "Trening Kadetow";
                            Przejscie.SceneLoad();
                            break;
                        
                        case "ILC Dover":
                            Przejscie.NextScene = "Sortowanie";
                            Przejscie.SceneLoad();
                            break;
                        
                        case "Testy Pojazdow Ksiezycowych":
                            Przejscie.NextScene = "Symulator Rakiety";
                            Przejscie.SceneLoad();
                            break;
                        
                        case "Aeroproject Corporation":
                            Przejscie.NextScene = "Paliwo";
                            Przejscie.SceneLoad();
                            break;
                    }
                }
            }
        }
    }
}
