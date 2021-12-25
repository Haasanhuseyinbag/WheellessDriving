using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarMove : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    void Start()
    {
        
    }
    void Update()
    {
        float X = joystick.Horizontal * 3.5f;
        transform.position = new Vector3(X, transform.position.y, transform.position.z);
    }
}
