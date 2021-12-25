using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    Gold gold;
    CarProgress progress;
    void Start()
    {
        gold = GameObject.Find("GameControl").GetComponent<Gold>();
        progress = GameObject.FindGameObjectWithTag("Araba").GetComponent<CarProgress>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Para")
        {
            gold.Altin += 1;
            Destroy(other.transform.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Engel")
        {
            progress.Can -= 1;
            if (progress.Can > 0)
            {
                StartCoroutine(Yavaþlat());
                Destroy(collision.transform.gameObject);
            }
        }
    }
    IEnumerator Yavaþlat()
    {
        progress.CarSpeed = 2;
        yield return new WaitForSeconds(1);
        progress.CarSpeed = 10;
    }
}
