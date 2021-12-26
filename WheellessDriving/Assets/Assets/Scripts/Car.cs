using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    Gold gold;
    CarProgress progress;
    AudioSource source;
    [SerializeField] AudioClip KazaSesi;
    void Start()
    {
        source = GetComponent<AudioSource>();
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
            source.PlayOneShot(KazaSesi);
            if (progress.Can > 0)
            {
                StartCoroutine(Yava�lat());
                Destroy(collision.transform.gameObject);
            }
        }
    }
    IEnumerator Yava�lat()
    {
        progress.CarSpeed = 2;
        yield return new WaitForSeconds(1);
        progress.CarSpeed = 10;
    }
}
