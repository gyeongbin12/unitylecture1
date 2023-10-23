using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected GameObject rotatePrefab;
    [SerializeField] float rotateSpeed = 200.0f;

    protected void Awake()
    {
        rotatePrefab = GameObject.Find("Rotate Prefab");
    }

    protected void OnEnable()
    {
        transform.rotation = Quaternion.Euler
        (
               90,
               0,
               rotatePrefab.transform.rotation.eulerAngles.z
        ); ;
    }

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}