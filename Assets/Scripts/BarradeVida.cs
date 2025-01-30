using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float salud = 50;
    public float SaludMaxima = 100;

    public Image BarradeVida;
    public Text Texto;

    public int monedas = 0;
    public Text monedasTexto; // Asigna esto en el Inspector

    void Update()
    {
        monedasTexto.text = "Monedas: " + monedas;
    }
void ActualizarInterface()
    {
        BarradeVida.fillAmount = salud / SaludMaxima;
    }


}
