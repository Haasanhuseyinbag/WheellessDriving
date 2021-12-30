using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] public GameObject Level;
    public void CreateLevel(float CreateZ)
    {
        Instantiate(Level, new Vector3(0, 0, CreateZ), Quaternion.identity);
    }
}
