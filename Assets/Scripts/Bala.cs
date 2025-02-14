using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float fuerzaLineal; // Velocidad de movimiento del objeto hacia adelante.


    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * fuerzaLineal; // Mueve el objeto hacia adelante en la direcci�n en la que est� mirando.
        Destroy(gameObject, 3.0f); // Destruye el objeto despu�s de 3 segundos para evitar acumulaci�n en la escena.
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "hunter")  // Si el objeto colisiona con otro que tenga la etiqueta "hunter", muestra un mensaje en la consola.
        {
            
            Debug.Log("condicional2");
        }
        Debug.Log("metodo"); // Mensaje de depuraci�n que se ejecuta cada vez que el objeto entra en un trigger.
    }



}
