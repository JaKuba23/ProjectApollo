using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InsideBuildingManager : MonoBehaviour
{
    public LayerMask layer;
    public Camera cam;

    void Update()
    {
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
                        SceneManager.LoadScene("Map");
                }
                else if(hit.transform.name == "Graj")
                {
                    
                    switch(SceneManager.GetActiveScene().name)
                    {
                        case "Centrum Kosmiczne":
                            SceneManager.LoadScene("Trening Kadetow");
                            break;
                        
                        case "Przyladek":
                            SceneManager.LoadScene("Symulator Rakiety");
                            break;
                    }
                }
            }
        }
    }
}
