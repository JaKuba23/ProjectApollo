﻿using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] AudioClip damage;
    [SerializeField] AudioClip die;
    AudioSource effect;
    public EndDialogueSystem endPanel;
    public GameObject EnemySpawner;
    public int health = 1;
    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;

    SpriteRenderer spriteRend;

    void Start()
    {
        correctLayer = gameObject.layer;

        spriteRend = GetComponent<SpriteRenderer>();


        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

            if (spriteRend == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
            }
        }
    }
    void Die()
    {
        if(transform.tag =="Player")
        {
             //zatrzymaj gre
            EnemySpawner.SetActive(false);
            //wlaczyc panel
            endPanel.gameObject.SetActive(true);
            // endPanel.enabled = true;
            //czy wygral czy prezgral
            endPanel.Won = false;
            //zacznij dialog
            endPanel.Gadaj();
            this.gameObject.SetActive(false);
            effect = GameObject.FindGameObjectWithTag("Effect").GetComponent<AudioSource>();
            effect.PlayOneShot(die);
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D()
    {
        health--;
        effect = GameObject.FindGameObjectWithTag("Effect").GetComponent<AudioSource>();
        effect.PlayOneShot(damage);

        if (invulnPeriod > 0)
        {
            invulnTimer = invulnPeriod;
            gameObject.layer = 10;
        }
    }

    void Update()
    {

        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;

            if (invulnTimer <= 0)
            {
                gameObject.layer = correctLayer;
                if (spriteRend != null)
                {
                    spriteRend.enabled = true;
                }
            }
            else
            {
                if (spriteRend != null)
                {
                    spriteRend.enabled = !spriteRend.enabled;
                }
            }
        }

        if (health <= 0)
        {   
            Die();
        }
    }

    

}