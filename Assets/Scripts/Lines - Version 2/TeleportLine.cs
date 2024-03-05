using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLine : MonoBehaviour
{
    private void Start()
    {
        GameObject player = GameObject.Find("===Player===");
        if (player != null)
        {
            Vector3 teleportPosition = transform.position; 
            player.transform.position = teleportPosition;
        }
    }
}
