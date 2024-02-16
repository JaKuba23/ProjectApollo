using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuildinsChoosingManager : MonoBehaviour
{
    public LayerMask BuildingMask;
    public GameObject BuildingUI;
    public Transform DefaultPos;
    public Toggle finished;
    public Image Person;
    Transform building;

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
        
        if(Input.GetButtonDown("Click"))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 100, BuildingMask))
            {
                Debug.Log(hit.transform.name);
                CameraMovement.target = hit.transform;
                CameraMovement.offset.z = -6;
                finished.isOn = hit.transform.GetComponent<Building>().IsFinished;
                Person.sprite = hit.transform.GetComponent<Building>().BuildingPerson;
                BuildingUI.SetActive(true);
                building = hit.transform;
            }
        }
    }

    public void Back()
    {
        CameraMovement.target = DefaultPos;
        CameraMovement.offset.z = -10;
        BuildingUI.SetActive(false);
    }

    public void Przejdz()
    {
        SceneManager.LoadScene(building.transform.name);
    }

    public void WyslijRakiete()
    {
        SceneManager.LoadScene("Start Rakiety");
    }
}
