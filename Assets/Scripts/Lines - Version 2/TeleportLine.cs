using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLine : MonoBehaviour
{

    private bool haveUsed = false;
    public LineSpawner2 spawner;
    private void Start()
    {
        GameObject player = GameObject.Find("===Player===");
        if (player != null)
        {
            Vector3 teleportPosition = transform.position; 
            player.transform.position = teleportPosition;
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         if (!haveUsed)
    //         {
    //             //collision.gameObject.transform.position = spawner.circle2Position.position;
    //             Vector3 teleportPosition = transform.position;
    //             collision.gameObject.transform.position = teleportPosition;
    //             haveUsed = true;
    //         }
    //     }
    // }
}
