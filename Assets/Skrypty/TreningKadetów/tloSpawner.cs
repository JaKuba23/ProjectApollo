using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tloSpawner : MonoBehaviour
{
    public GameObject[] tla;
    public float speed = 1;
    
    void Start()
    {
        // Spawn();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.name[0] == 't')
            Spawn();
    }
    
    void Spawn()
    {
        GameObject instace = Instantiate(tla[Random.Range(0,3)], transform.position, transform.rotation);
        instace.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed,0);
    }

    
}
