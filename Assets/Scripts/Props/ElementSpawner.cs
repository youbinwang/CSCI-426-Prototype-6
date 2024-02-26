using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] props;
    public float innerRadius = 5f;
    public float outerRadius = 20f; 
    public Vector2 sizeRangePrefab1 = new Vector2(0.5f, 2f);
    public Vector2 sizeRangePrefab2 = new Vector2(1f, 3f);
    public float spawnTime;
   

    private void Start()
    {
        InvokeRepeating("SpawnObject", 0, spawnTime);
    }

    void SpawnObject()
    {
        int index = Random.Range(0, props.Length);
        GameObject prefabToSpawn = props[index];

        /*
          Vector2 spawnPosition = player.transform.position + (Vector3)Random.insideUnitCircle.normalized * Random.Range(innerRadius, outerRadius);
          GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);*/


        Vector2 selectedSizeRange = index == 0 ? sizeRangePrefab1 : sizeRangePrefab2; //Two Prefabs
        float size = Random.Range(selectedSizeRange.x, selectedSizeRange.y);
        //spawnedObject.transform.localScale = new Vector3(size, size, size);

        Vector2 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, Random.value, Camera.main.nearClipPlane));
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        spawnedObject.transform.localScale = new Vector3(size, size, size);

    }


}
