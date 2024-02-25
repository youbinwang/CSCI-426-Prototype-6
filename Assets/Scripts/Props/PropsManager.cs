using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsManager : MonoBehaviour
{
    public Transform player;
    public float maxDistance = 70f;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
