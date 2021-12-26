using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] public GameObject Level;
    [SerializeField] public Transform LevelSpawner;
    public float Mod;
    void Update()
    {
        Mod = transform.position.z % 10;
        if (Mod == 0)
        {
            CreateLevel();
        }
    }
    void CreateLevel()
    {
        Instantiate(Level, LevelSpawner.position, Quaternion.identity);
    }
}
