using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wyjdz : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Wyjdz", 15f);
    }

    public void Wyjdz()
    {
        SceneManager.LoadScene("Map");
    }
}
