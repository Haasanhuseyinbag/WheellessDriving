using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gold : MonoBehaviour
{
    public int Altin;
    public TMP_Text GoldText;
    void Update()
    {
        GoldText.text = Altin.ToString();
    }
}
