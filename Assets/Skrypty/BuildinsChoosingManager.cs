using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuildinsChoosingManager : MonoBehaviour
{
    public LayerMask BuildingMask;
    Camera cam;
    CameraMovement CameraMovement;
    void Start()
    {
        cam = Camera.main;
        CameraMovement = cam.transform.GetComponent<CameraMovement>();
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 100, BuildingMask))
            {
                Debug.Log(hit.transform.name);
                CameraMovement.target = hit.transform;
            }
        }
    }
}
