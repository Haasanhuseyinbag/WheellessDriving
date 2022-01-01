using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Car : MonoBehaviour
{
    Gold gold;
    CarProgress progress;
    AudioSource source;
    Control control;
    [SerializeField] AudioClip KazaSesi, AltinToplama;
    [SerializeField] public float Can, Puan;
    [SerializeField] public TMP_Text CanText, PuanText;
    [SerializeField] GameObject DeathScreen;
    float TotalAltin;
    float HighScore;
    bool Bittimi;
    void Start()
    {
        Can = PlayerPrefs.GetFloat("Can");
        Time.timeScale = 1;
        source = GetComponent<AudioSource>();
        gold = GameObject.Find("GameControl").GetComponent<Gold>();
        progress = GameObject.FindGameObjectWithTag("Araba").GetComponent<CarProgress>();
        control= GameObject.Find("GameControl").GetComponent<Control>();
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
            Destroy(collision.transform.gameObject);
            if (Can > 0)
            {
                StartCoroutine(Yavaþlat());
            }
            if (Can <= 0)
            {
                GetComponent<CarMove>().enabled = false;
                Time.timeScale = 0;
                DeathScreen.SetActive(true);
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
    public void Death()
    {
        TotalAltin = PlayerPrefs.GetFloat("TotalAltin");
        PlayerPrefs.SetFloat("TotalAltin", TotalAltin + gold.Altin);
        HighScore = PlayerPrefs.GetFloat("HighScore");
        if (Puan > HighScore)
        {
            PlayerPrefs.SetFloat("HighScore", Puan);
        }
    }
    public void Resume()
    {
        GetComponent<CarMove>().enabled = true;
        Time.timeScale = 1;
        DeathScreen.SetActive(false);
        Can = 1;
    }
}
