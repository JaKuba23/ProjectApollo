using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuildinsChoosingManager : MonoBehaviour
{
    public GameObject ErrorG;
    public GameObject dialog;
    public LayerMask BuildingMask;
    public GameObject BuildingUI;
    public Transform DefaultPos;
    //public Toggle finished;
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
        if(dialog.GetComponent<DialogueSystem>().enabled == true && dialog.activeSelf == true)
            return;
            
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        
        if(Input.GetButtonDown("Click"))
        {
            if(building)
                building.GetComponent<SpriteRenderer>().sprite = building.GetComponent<Building>().BuildingPhoto[0];
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 100, BuildingMask))
            {
                Debug.Log(hit.transform.name);
                CameraMovement.target = hit.transform;
                CameraMovement.offset.z = -6;
               // finished.isOn = hit.transform.GetComponent<Building>().IsFinished;
                Person.sprite = hit.transform.GetComponent<Building>().BuildingPerson;
                BuildingUI.SetActive(true);
                building = hit.transform;
                building.GetComponent<SpriteRenderer>().sprite = building.GetComponent<Building>().BuildingPhoto[1];
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
        if (building.transform.name == "Start Rakiety" && (PlayerPrefs.GetInt("Trening Kadetow Finnished") == 0 || PlayerPrefs.GetInt("Sortowanie Finnished") == 0 || PlayerPrefs.GetInt("Paliwo Finnished") == 0 || PlayerPrefs.GetInt("Symulator Rakiety Finnished") == 0))
        { 
            Error.error = "Wysłać rakiete na księżyc możesz dopiero gdy ukończysz zadania we wszystkich budynkach";
            ErrorG.SetActive(true);
        }
        else
        {
            Przejscie.NextScene = building.transform.name;
            Przejscie.SceneLoad();
        }
    }

    public void WyslijRakiete()
    {
        Przejscie.NextScene = "Start Rakiety";
        Przejscie.SceneLoad();
    }
}
