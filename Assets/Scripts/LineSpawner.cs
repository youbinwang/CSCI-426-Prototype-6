using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawner : MonoBehaviour
{
     public GameObject circle1;
      public GameObject circle2;
      public GameObject line;
      public float dotDistance = 5f;
      private GameObject lastCircle = null;
      private GameObject currentLine;
  
      private GameObject startPoint = null;
      private GameObject endPoint = null;
      
      void Update()
      {
          if (Input.GetMouseButtonDown(0))
          {
              Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
              clickPosition.z = 0;

              if (lastCircle == null)
              {
                  lastCircle = Instantiate(circle1, clickPosition, Quaternion.identity);
              }
              else
              {
                  float distance = Vector3.Distance(lastCircle.transform.position, clickPosition);
                  if (distance < dotDistance)
                  {
                      // Clear Old Circle 1 & Circle 2 and the line
                      ClearOldCircleAndLine();
                      GameObject newCircle = Instantiate(circle2, clickPosition, Quaternion.identity);
                      PlaceAndScaleLine(lastCircle.transform.position, newCircle.transform.position);
                      startPoint = lastCircle;
                      endPoint = newCircle;
                      lastCircle = null;
                  }
                  else
                  {
                      Destroy(lastCircle);
                      lastCircle = Instantiate(circle1, clickPosition, Quaternion.identity);
                  }
              }
          }
      }
      
      void PlaceAndScaleLine(Vector3 startPosition, Vector3 endPosition)
      {
          if (currentLine != null) Destroy(currentLine);

          Vector3 middlePoint = (startPosition + endPosition) / 2;
          currentLine = Instantiate(line, middlePoint, Quaternion.identity);
      
          float distance = Vector3.Distance(startPosition, endPosition);
          currentLine.transform.localScale = new Vector3(distance, currentLine.transform.localScale.y, currentLine.transform.localScale.z);
        
          Vector3 direction = endPosition - startPosition;
          float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
          currentLine.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
      }
  
      public void ClearOldCircleAndLine()
      {
          if (startPoint != null) Destroy(startPoint);
          if (endPoint != null) Destroy(endPoint);
          if (currentLine != null) Destroy(currentLine);
        
          startPoint = null;
          endPoint = null;
          currentLine = null;
      }
}
