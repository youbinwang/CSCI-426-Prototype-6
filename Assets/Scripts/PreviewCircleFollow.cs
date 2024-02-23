using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewCircleFollow : MonoBehaviour
{
    public GameObject previewCircle;
    
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        previewCircle.transform.position = mousePosition;
    }
}
