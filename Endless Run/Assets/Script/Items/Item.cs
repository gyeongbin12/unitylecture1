using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 200.0f;

    void Update()
    {
        transform.Rotate( 0, 0, rotateSpeed * Time.deltaTime);
    }
}
