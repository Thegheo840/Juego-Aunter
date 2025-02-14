using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [Header("speed")]
    [SerializeField]
    private int speed = 100; // Velocidad de movimiento del objeto.
    void Start()
    {
        Destroy(gameObject, 5.0f); // Destruye el objeto después de 5 segundos para evitar acumulación en la escena.
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // Mueve el objeto hacia adelante a la velocidad establecida.
    }
}
