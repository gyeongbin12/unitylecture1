using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float offset = 40f;
    [SerializeField] List<GameObject> roads;

    public static Action roadPosition;

    private void Start()
    {
        roadPosition = NewPosition;
    }

    void Update()
    {
        for (int i = 0; i < roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    public void NewPosition()
    {
        GameObject road = roads[0];
            
        roads.Remove(road);

        float newZ = roads[roads.Count - 1].transform.position.z + offset;

        road.transform.position = new Vector3(0, 0, newZ);

        roads.Add(road);
    }
}
