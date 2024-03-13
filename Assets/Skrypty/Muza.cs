using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muza : MonoBehaviour
{
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        this.GetComponent<AudioSource>().Stop();
    }
}
