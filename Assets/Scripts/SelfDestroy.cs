using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float destroyTime;
    void Start()
    {
        Invoke("DestroyMe", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
