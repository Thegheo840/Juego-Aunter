using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creador_enemigos : MonoBehaviour
{
    public float tiempoEntreEnemigos = 0.0f; // Tiempo de espera entre la generación de enemigos.
    private float temporizador = 0.0f;  // Temporizador para controlar la generación.
    public GameObject hunter; // Prefab del enemigo que será instanciado.


    void Start()
    {
        temporizador = 0.0f; // Inicializa el temporizador en 0.

    }

   
    void Update()
    {
        if (temporizador < tiempoEntreEnemigos) // Si el temporizador aún no ha alcanzado el tiempo de espera, lo incrementa con el tiempo transcurrido.
        {
            temporizador += Time.deltaTime;
        }
        else
        {
            Instantiate(hunter, transform.position, transform.rotation); // Genera un nuevo enemigo en la posición y rotación del objeto que contiene este script
            temporizador = 0.0f; // Reinicia el temporizador para volver a contar desde 0.
        }

    }
}
