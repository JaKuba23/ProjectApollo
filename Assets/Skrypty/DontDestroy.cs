using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public AudioClip wind;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
