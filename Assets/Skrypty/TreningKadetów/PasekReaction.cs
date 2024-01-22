using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasekReaction : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(transform.position.x > -4)
            rb.velocity = new Vector2(-speed, 0f);
        else
            rb.velocity = Vector2.zero;
        
        if(Input.GetButtonDown("Skip"))
            StartCoroutine(Jump());

    }

    IEnumerator Jump()
    {
        rb.velocity = Vector2.zero;
        if(transform.position.x + jump < 4f)
            transform.Translate(new Vector2(jump, 0f));
        else
            transform.Translate(new Vector2(4f - transform.position.x, 0f));

        yield return new WaitForSeconds(1);
        rb.velocity = new Vector2(-speed, 0f);
    }
}
