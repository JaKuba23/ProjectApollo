using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class czesci_rakiety : MonoBehaviour
{
    public startTheEnding start;
    public Transform target;
    public Vector3 offset;
    public float damping;
    Vector3 velocity = Vector3.zero;
    Vector2 difference = Vector2.zero;
    public bool ride = false;
    bool once = true;
    void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition)-difference;
    }

    void FixedUpdate()
    {
        if(ride)
        {
            if(target != null)
            {
            Vector3 movePosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
            if(once)
            {
                start.count++;
                once = false;
            }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(target == other.transform)
        {
            ride = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(target == other.transform)
        {
            ride = false;
        }
    }
}
