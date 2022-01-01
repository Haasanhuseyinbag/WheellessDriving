using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarProgress : MonoBehaviour
{
    [SerializeField] public float CarSpeed;
    [SerializeField] public float HizlanmaOrani;
    Car car;
    void Start()
    {
        car = GetComponent<Car>();
    }
    void Update()
    {
        if (car.Can > 0)
        {
            transform.Translate(Vector3.forward * CarSpeed * Time.deltaTime, Space.World);
            CarSpeed += Time.timeSinceLevelLoad / 1000 * HizlanmaOrani;
            CarSpeed = Mathf.Clamp(CarSpeed, 1, 120);
        }
    }
}
