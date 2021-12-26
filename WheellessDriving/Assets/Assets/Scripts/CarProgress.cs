using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarProgress : MonoBehaviour
{
    [SerializeField] public float CarSpeed;
    [SerializeField] public float HizlanmaOrani;
    [SerializeField] public int Can;
    void Update()
    {
        transform.Translate(Vector3.forward * CarSpeed * Time.deltaTime, Space.World);
        CarSpeed += Time.timeSinceLevelLoad / 1000 * HizlanmaOrani;
        CarSpeed = Mathf.Clamp(CarSpeed, 1, 120);
        if (Can <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        GetComponent<CarMove>().enabled = false;
        Time.timeScale = 0;
    }
}
