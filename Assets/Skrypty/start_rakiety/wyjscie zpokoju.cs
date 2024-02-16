using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wyjsciezpokoju : MonoBehaviour
{
    void Start()
    {
        Invoke("XD", 60f);
    }

    void XD()
    {
        SceneManager.LoadScene("Napisy");
    }
}
