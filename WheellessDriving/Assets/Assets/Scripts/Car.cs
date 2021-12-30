using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Car : MonoBehaviour
{
    Gold gold;
    CarProgress progress;
    AudioSource source;
    [SerializeField] AudioClip KazaSesi, AltinToplama;
    [SerializeField] public float Can, Puan;
    [SerializeField] public TMP_Text CanText, PuanText;
    [SerializeField] GameObject DeathScreen;
    int TotalAltin;
    float HighScore;
    void Start()
    {
        Can = PlayerPrefs.GetFloat("Can");
        Time.timeScale = 1;
        source = GetComponent<AudioSource>();
        gold = GameObject.Find("GameControl").GetComponent<Gold>();
        progress = GameObject.FindGameObjectWithTag("Araba").GetComponent<CarProgress>();
    }
    void Update()
    {
        CanText.text = Can.ToString();
        PuanText.text = ((int)Puan).ToString();
        Puan += (progress.CarSpeed * 1 * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Engel")
        {
            Can -= 1;
            source.PlayOneShot(KazaSesi);
            if (Can > 0)
            {
                StartCoroutine(Yavaþlat());
                Destroy(collision.transform.gameObject);
            }
            if (Can <= 0)
            {
                Death();
            }
        }
        if (collision.transform.gameObject.tag == "Para")
        {
            gold.Altin += 1;
            source.PlayOneShot(AltinToplama);
            Destroy(collision.transform.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "LevelYarat")
        {
            GetComponent<LevelController>().CreateLevel(other.transform.position.z + 110);
        }
    }
    IEnumerator Yavaþlat()
    {
        progress.CarSpeed = 2;
        yield return new WaitForSeconds(1);
        progress.CarSpeed = 10;
    }
    void Death()
    {
        GetComponent<CarMove>().enabled = false;
        Time.timeScale = 0;
        DeathScreen.SetActive(true);
        TotalAltin = PlayerPrefs.GetInt("TotalAltin");
        PlayerPrefs.SetInt("TotalAltin", TotalAltin + gold.Altin);
        HighScore = PlayerPrefs.GetFloat("HighScore");
        if (Puan > HighScore)
        {
            PlayerPrefs.SetFloat("HighScore", Puan);
        }
    }
}
