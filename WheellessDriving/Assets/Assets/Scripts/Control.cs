using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Control : MonoBehaviour
{
    public void Menu()
    {
        Car car = GameObject.FindGameObjectWithTag("Araba").GetComponent<Car>();
        car.Death();
        SceneManager.LoadScene("Menu");
    }
    public void Game()
    {
        SceneManager.LoadScene("Game");
    }
    public void Restart()
    {
        Car car = GameObject.FindGameObjectWithTag("Araba").GetComponent<Car>();
        car.Death();
        SceneManager.LoadScene("Game");
    }
    public void Cikis()
    {
        Application.Quit();
    }
}
