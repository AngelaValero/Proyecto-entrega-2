using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    public string final;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("final");
        }
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliste del juego");
    }   
}
