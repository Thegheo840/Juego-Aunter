using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    public GameObject Thunder; // Prefab del trueno que será instanciado al disparar
    [SerializeField]
    private AudioSource shootAudio; // Componente de audio para reproducir el sonido del disparo.

    void Awake()
    {
        shootAudio = GetComponent<AudioSource>(); // Obtiene el componente de audio adjunto a este objeto.
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta si el jugador hace clic con el botón izquierdo del ratón.
        {
            shootAudio.Play();  // Reproduce el sonido del disparo.
            Instantiate(Thunder, transform.position, transform.rotation); // Instancia el objeto Thunder en la posición y rotación del objeto actual.
        } 
    }

}
