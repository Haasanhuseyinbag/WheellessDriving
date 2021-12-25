using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarProgress : MonoBehaviour
{
    [SerializeField] public float CarSpeed;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(0, 0, CarSpeed * Time.deltaTime);
    }
}
