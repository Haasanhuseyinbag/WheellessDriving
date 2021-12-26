using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform Araba;
    [SerializeField] float Y_ekseni, Z_ekseni;
    void Start()
    {
        Araba = GameObject.FindGameObjectWithTag("Araba").transform;
    }
    void Update()
    {
        transform.position = new Vector3(0, Araba.position.y + Y_ekseni, Araba.position.z - Z_ekseni);
    }
}
