using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundControl : MonoBehaviour
{
    [SerializeField] Sprite On, Off;
    [SerializeField] Button SoundButton;
    [SerializeField] AudioSource[] sources;
    [SerializeField] bool Acikmi;
    void Start()
    {
        if (PlayerPrefs.GetString("Sound") == "Acik")
        {
            Acikmi = true;
        }
        if (PlayerPrefs.GetString("Sound") == "Kapali")
        {
            Acikmi = false;
        }
    }
    void Update()
    {
        if (Acikmi)
        {
            PlayerPrefs.SetString("Sound", "Acik");
            SoundButton.GetComponent<Image>().sprite = On;
            foreach (AudioSource item in sources)
            {
                item.enabled = true;
            }
        }
        else if (!Acikmi)
        {
            PlayerPrefs.SetString("Sound", "Kapali");
            SoundButton.GetComponent<Image>().sprite = Off;
            foreach (AudioSource item in sources)
            {
                item.enabled = false;
            }
        }
    }
    public void SoundOnOff()
    {
        Acikmi = !Acikmi;
    }
}
