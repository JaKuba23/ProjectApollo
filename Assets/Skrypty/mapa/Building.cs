using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Sprite[] BuildingPhoto;
    public Sprite BuildingPerson;
    public bool IsFinished;

    void Awake()
    {
        this.GetComponent<SpriteRenderer>().sprite = BuildingPhoto[0];
    }

    public void GoClick()
    {
        this.GetComponent<SpriteRenderer>().sprite = BuildingPhoto[1];
    }

    public void ByeClick()
    {
        this.GetComponent<SpriteRenderer>().sprite = BuildingPhoto[0];
    }
}
