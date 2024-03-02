using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tloDestroyer : MonoBehaviour
{
    void OnCollisionExit2D(Collision2D other)
    {
        Destroy(other.gameObject);
    }
}
