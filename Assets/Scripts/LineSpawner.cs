using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawner : MonoBehaviour
{
    public GameObject circle1;
    public GameObject circle2;
    public GameObject[] linePrefabs;
    public float dotDistance = 5f;
    
    private GameObject lastCircle = null;
    private GameObject currentLinePrefab;
    private GameObject currentLineInstance;
    
    private List<GameObject> recentObjects = new List<GameObject>();
    
    public SpriteRenderer previewSpriteRenderer;

    private void Start()
    {
        RandomLineGenerate();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0;
            
            if (lastCircle == null)
            {
                //ClearOldObjects();
                lastCircle = Instantiate(circle1, clickPosition, Quaternion.identity);
                ChangeCircleColors(lastCircle);
                recentObjects.Add(lastCircle);
            }
            else
            {
                float distance = Vector3.Distance(lastCircle.transform.position, clickPosition);
                if (distance < dotDistance)
                {
                    GameObject newCircle = Instantiate(circle2, clickPosition, Quaternion.identity);
                    ChangeCircleColors(newCircle);
                    recentObjects.Add(newCircle);

                    ClearOldObjects();
                    PlaceAndScaleLine(lastCircle.transform.position, newCircle.transform.position);
                    lastCircle = null;
                    RandomLineGenerate();
                }

                if (distance > dotDistance)
                {
                    //When Distance > dotDistance
                    previewSpriteRenderer.color = new Color(1f, 0.22f, 0.22f);
                }
            }
        }
    }

    void PlaceAndScaleLine(Vector3 startPosition, Vector3 endPosition)
    {
        GameObject line = Instantiate(currentLinePrefab, (startPosition + endPosition) / 2, Quaternion.identity);
        float distance = Vector3.Distance(startPosition, endPosition);
        line.transform.localScale = new Vector3(distance, line.transform.localScale.y, line.transform.localScale.z);

        Vector3 direction = endPosition - startPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        line.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        recentObjects.Add(line);
    }

    void RandomLineGenerate()
    {
        int index = UnityEngine.Random.Range(0, linePrefabs.Length);
        currentLinePrefab = linePrefabs[index];
        
        UpdatePreviewColor();
    }

    void UpdatePreviewColor()
    {
        SpriteRenderer prefabRenderer = currentLinePrefab.GetComponent<SpriteRenderer>();
        Color lineColor = prefabRenderer.color;
        previewSpriteRenderer.color = lineColor;
        Color previewColor = new Color(lineColor.r, lineColor.g, lineColor.b, 0.3f);
        previewSpriteRenderer.color = previewColor;
    }
    
    
    void ChangeCircleColors(GameObject circle)
    {
        SpriteRenderer lineRenderer = currentLinePrefab.GetComponent<SpriteRenderer>();
        Color lineColor = lineRenderer.color;

        SpriteRenderer circleRenderer = circle.GetComponent<SpriteRenderer>();
        circleRenderer.color = lineColor;
    }

    public void ClearOldObjects()
    {
        foreach (var obj in recentObjects)
        {
                Destroy(obj);
        }
        recentObjects.Clear();
    }
}