using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameManagerSO")]

public class GameManager : ScriptableObject
{
    public event Action OnBotonPulsado;

    public void BotonPulsado(int idBoton)
    {
        OnBotonPulsado.Invoke();
    }
}

