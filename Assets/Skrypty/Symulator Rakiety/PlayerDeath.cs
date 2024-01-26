using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDeath : MonoBehaviour
{
    public TMP_Text text;
    public EnemySpawner enemys;
    GameObject player;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(player.GetComponent<DamageHandler>().health<=0)
        {
            enemys.enabled = false;
            text.text = "0";
        }
        else
            text.text = player.GetComponent<DamageHandler>().health.ToString();
    }
}
