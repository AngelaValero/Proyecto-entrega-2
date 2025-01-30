using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemigo : MonoBehaviour
{
    #region //variables
    public Transform objetivo;

    #endregion  
    void Start()
    {
   
    }

    void Update()
    {
             NavMeshAgent AGENTE = GetComponent<NavMeshAgent>();
        AGENTE.destination = objetivo.position;
    }
}