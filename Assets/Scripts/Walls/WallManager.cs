using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public WallProperty[] Walls;
    public float switchTime;
    private void Start()
    {
        InvokeRepeating("RandomizeProperties", switchTime, switchTime);
    }

    void RandomizeProperties()
    {
        List<WallProperty.Property> availableProperties = new List<WallProperty.Property>
        {

            WallProperty.Property.bounce,
            WallProperty.Property.bounce,
            WallProperty.Property.speedBounce,
            WallProperty.Property.speedBounce,
            WallProperty.Property.dangerBounce,
            WallProperty.Property.dangerBounce
        };

        Shuffle(availableProperties);

        foreach (var wall in Walls)
        {
            if (availableProperties.Count > 0)
            {
                int index = Random.Range(0, availableProperties.Count);
                wall.SetProperty(availableProperties[index]);
                availableProperties.RemoveAt(index); // “∆≥˝“—∑÷≈‰ Ù–‘
            }
        }
    }

    void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}

