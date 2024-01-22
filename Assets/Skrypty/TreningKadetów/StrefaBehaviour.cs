using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StrefaBehaviour : MonoBehaviour
{
    public string button;
    public TMP_Text text;
    Rigidbody2D rb;
    float speed;
    float scale;
    float newscale;
    public int licznik;
    string wsrodek;
    bool clicklock = true;

    Vector2 zwrot = Vector2.down;

    void Awake()
    {
        newscale = transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
        zwrot = (Random.Range(-1f,1f) > 0)?Vector2.up:Vector2.down;
        speed = Random.Range(.8f, 1.2f);
        scale = Random.Range(1.05f,1.2f);
    }

    void Update()
    {
        rb.velocity = -speed * zwrot;
        text.text = licznik.ToString();

        if(Input.GetButtonDown(button) && clicklock)
        {
            if(wsrodek =="pasek" )
            {
                licznik++;
                clicklock = false;
            }
            else
             licznik = 0;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.name == "pasek")
        {
            wsrodek = "pasek";
        }
        else if(other.transform.name == "tło")
        {
            if(zwrot == Vector2.down)
            {
                zwrot = Vector2.up;
                if(newscale > .1f)
                {
                transform.localScale = new Vector3(newscale/scale,.6f,1);
                newscale = transform.localScale.x;
                speed *= scale;
                }
                clicklock = true;
            }
            else if(zwrot == Vector2.up)
            {
                zwrot = Vector2.down;
                if(newscale > .1f)
                {
                transform.localScale = new Vector3(newscale/scale,.6f,1);
                newscale = transform.localScale.x;
                speed *= scale;
                }
                clicklock = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.transform.name == "pasek")
        {
            wsrodek = "";
        }
    }
}
