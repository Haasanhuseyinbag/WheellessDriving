using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MenuControl : MonoBehaviour
{
    [SerializeField] public float HighScore;
    [SerializeField] public float TotalAltin;
    [SerializeField] TMP_Text TotalAltinText, HighScoreText, Maliyet, Can1, UyariText, CanText;
    [SerializeField] public float[] Maliyetler;
    [SerializeField] Button YukseltmeButton, BaslamaButonu;
    float AktifMaliyet = 0;
    float AktifCan;
    void Start()
    {
        HighScore = PlayerPrefs.GetFloat("HighScore");
        HighScoreText.text = ((int)HighScore).ToString();
    }
    void Update()
    {
        AktifCan = PlayerPrefs.GetFloat("Can");
        TotalAltin = PlayerPrefs.GetFloat("TotalAltin");
        TotalAltinText.text = TotalAltin.ToString();
        Maliyet.text = AktifMaliyet.ToString();
        CanText.text = AktifCan.ToString();
        switch (AktifCan)
        {
            case 0:
                AktifMaliyet = Maliyetler[0];
                UyariText.text = "Ýlk Canýný Almayý Unutma";
                break;
            case 1:
                AktifMaliyet = Maliyetler[1];
                break;
            case 2:
                AktifMaliyet = Maliyetler[2];
                break;
            case 3:
                AktifMaliyet = Maliyetler[3];
                break;
            case 4:
                AktifMaliyet = Maliyetler[4];
                break;
            case 5:
                AktifMaliyet = Maliyetler[5];
                YukseltmeButton.interactable = false;
                YukseltmeButton.GetComponentInChildren<TMP_Text>().text = "";
                Can1.text = "Max Cana Ulaþýldý";
                break;
        }
        if (AktifCan == 0)
        {
            BaslamaButonu.interactable = false;
        }
        else
        {
            BaslamaButonu.interactable = true;
        }

    }
    public void Yukselt()
    {
        if (AktifCan == 0)
        {
            UyariText.text = "";
        }
        if (TotalAltin >= AktifMaliyet && AktifCan <= 5)
        {
            PlayerPrefs.SetFloat("Can", AktifCan += 1);
            TotalAltin -= AktifMaliyet;
            PlayerPrefs.SetFloat("TotalAltin", TotalAltin);
        }
        if (TotalAltin < AktifMaliyet)
        {
            StartCoroutine(Uyari("Para Yetersiz"));
        }
    }
    IEnumerator Uyari(string UyariMetni)
    {
        UyariText.text = UyariMetni;
        yield return new WaitForSeconds(1);
        UyariText.text = "";
    }
}
