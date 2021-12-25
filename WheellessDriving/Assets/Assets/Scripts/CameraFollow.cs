using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform Araba;
    void Start()
    {
        Araba = GameObject.FindGameObjectWithTag("Araba").transform;
    }
    void Update()
    {
        transform.position = new Vector3(0, Araba.position.y + 15, Araba.position.z - 12.5f);
    }
}
