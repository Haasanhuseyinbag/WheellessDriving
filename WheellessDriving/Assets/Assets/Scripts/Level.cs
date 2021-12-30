using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] GameObject[] Bariyers;
    [SerializeField] GameObject Coin;
    [SerializeField] Transform[] BariyerSpawners, CoinSpawners;
    void Start()
    {
        int SelectedBariyerSpawner = Random.Range(0, BariyerSpawners.Length);
        int SelectedCoinSpawner = Random.Range(0, CoinSpawners.Length);
        int SelectedBariyer = Random.Range(0, Bariyers.Length);

        Instantiate(Bariyers[SelectedBariyer], BariyerSpawners[SelectedBariyerSpawner].position, Bariyers[SelectedBariyer].transform.rotation);
        Instantiate(Coin, CoinSpawners[SelectedCoinSpawner].position, Quaternion.identity);
    }
}
