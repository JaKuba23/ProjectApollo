using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tloRunner : MonoBehaviour
{
    public float speed = 1;
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed,0);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "left")
        {
            Destroy(this.gameObject);
        }
    }
}
