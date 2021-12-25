using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    Gold gold;
    void Start()
    {
        gold = GameObject.Find("GameControl").GetComponent<Gold>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Para")
        {
            gold.Altin += 1;
            Destroy(other.transform.gameObject);
        }
    }
}
