using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OpcionesMenu : MonoBehaviour
{
    public void Jugar()
    {
       SceneManager.LoadScene("SampleScene");
}
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliendo...");

    }
}
