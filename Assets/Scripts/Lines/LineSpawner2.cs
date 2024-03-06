using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawner2 : MonoBehaviour
{
    public GameObject circle1;
    public GameObject circle2;
    public GameObject[] linePrefabs;
    public float dotDistance = 5f;
    
    public GameObject lastCircle = null;
    public GameObject currentLinePrefab;
    private GameObject currentLineInstance;
    private int lastIndex = -1;
    
    public List<GameObject> recentObjects = new List<GameObject>();
    
    public SpriteRenderer previewSpriteRenderer;

    public Transform circle2Position;

    [Header("LineLimit")]
    [SerializeField] private float lastTime;
    [SerializeField] private float coolDown;
    [SerializeField] private bool ifCanDraw = true;

    [Header("Restore")]
    public bool hasRestoreUsed; 
    public GameObject restoredLine;
    public GameObject waitingLine;
    [SerializeField] private GameObject showLine;
    private SpriteRenderer showLineRender;
    private Color showLineColor;
    private void Start()
    {
       /* RandomLineGenerate();
        UpdatePreviewColor();*/
        int index = UnityEngine.Random.Range(0, linePrefabs.Length);
        currentLinePrefab = linePrefabs[index];
        UpdatePreviewColor();
        showLineRender = showLine.GetComponent<SpriteRenderer>();
        showLineColor = showLineRender.color;
        showLineColor.a = 0;
        showLineRender.color = showLineColor;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ifCanDraw)
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0;
            
            if (lastCircle == null)
            {
                ClearOldObjects();
                 circle2Position = null;
                
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
                    circle2Position = newCircle.transform;
                    ChangeCircleColors(newCircle);
                    recentObjects.Add(newCircle);
                    
                    PlaceAndScaleLine(lastCircle.transform.position, newCircle.transform.position);
                    lastCircle = null;
                    if (waitingLine == null)
                    {
                        RandomLineGenerate();
                    }

                    else if(restoredLine !=null && waitingLine != null)
                    {
                        waitingLine = null;
                        RandomLineGenerate();
                    }
                }

                if (distance > dotDistance)
                {
                    //When Distance > dotDistance
                    previewSpriteRenderer.color = new Color(1f, 0.22f, 0.22f);
                }
/*
                if(restoredLine != null && waitingLine != null)
                {
                    
                    waitingLine = currentLinePrefab;
                   
                }*/

               if (restoredLine == null && waitingLine != null)
                {
                    if (!hasRestoreUsed)
                    {
                        hasRestoreUsed = true;
                    }

                    else
                    {
                        waitingLine = null;
                        /*ClearOldObjects();*/
                        RandomLineGenerate();
                    }
                   
                }

              
            }

            if(restoredLine == null && waitingLine != null && hasRestoreUsed)
            {
                currentLinePrefab = waitingLine;
                UpdatePreviewColor();
            }

            if (restoredLine != null && waitingLine == null)
            {
                waitingLine = currentLinePrefab;
            }

        }

        ChangeLineUI();

        SwitchLine();
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
        ifCanDraw = false;
        int index = UnityEngine.Random.Range(0, linePrefabs.Length);
        currentLinePrefab = linePrefabs[index];
        //Invoke("ClearOldObjects", lastTime);
        StartCoroutine(CanDraw());
        UpdatePreviewColor();
    }

    void WaitingLineGenerate()
    {
        currentLinePrefab = waitingLine;
        StartCoroutine(CanDraw());
        UpdatePreviewColor();
    }
    
    //Each Time Generate Different Line
    // void RandomLineGenerate()
    // {
    //     int index;
    //     do
    //     {
    //         index = UnityEngine.Random.Range(0, linePrefabs.Length);
    //     } while (index == lastIndex);
    //
    //     currentLinePrefab = linePrefabs[index];
    //     lastIndex = index;
    //
    //     UpdatePreviewColor();
    // }

    private void SwitchLine()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (restoredLine == null)
            {
                restoredLine = currentLinePrefab;
                hasRestoreUsed = false;
                ClearOldObjects();

                if (/*!hasRestored && */waitingLine == null)
                {
                    RandomLineGenerate();
                    waitingLine = currentLinePrefab;
                    //hasRestored = true;


                }

                else 
                {
                    WaitingLineGenerate();
                }
                

            }

            
           
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && restoredLine != null)
        {
            currentLinePrefab = restoredLine;
            restoredLine = null;
            ClearOldObjects();
            UpdatePreviewColor(); 




        }
    }

    private void ChangeLineUI()
    {
        if(restoredLine != null)
        {
            Color restoredColor = restoredLine.GetComponent<SpriteRenderer>().color;
            showLine.GetComponent<SpriteRenderer>().color = restoredColor;
        }
        else
        {
            SpriteRenderer showLineRenderer = showLine.GetComponent<SpriteRenderer>();
            Color color = showLineRenderer.color; 
            color.a = 0f;
            showLineRenderer.color = color; 
        }
    }

    IEnumerator CanDraw()
    {
        yield return new WaitForSeconds(coolDown);
        ifCanDraw = true;
        
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