using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    
    public GameObject Magnemite;// Referencia al objeto Magnemite.
    public Vector3 diferencia, // Vector que almacena la diferencia de posici�n entre el enemigo y Magnemite.
                   direccion; // Direcci�n normalizada hacia Magnemite.
    public float distancia; // Distancia entre el enemigo y Magnemite.
    public float velocidad = 10.0f; // Velocidad de movimiento
    public float giro = 10.0f; // Velocidad de giro.
    [SerializeField]
    private float timeBetweenBullets;  // Tiempo entre disparos.
    [SerializeField]
    private float distanceToPlayer = 6; // Distancia m�nima a la que el enemigo se acercar� al jugador.
    [Header("Attack")]
    [SerializeField]
    private GameObject bulletPrefab;  // Prefab de la bala disparada.
    [SerializeField]
    private Transform posRotBullet; // Posici�n y rotaci�n desde donde se disparan las balas.
    private GameObject player; // Referencia al jugador.
    private AudioSource shoothAudio; // Componente de audio para el sonido del disparo.

    [SerializeField]
    private ParticleSystem smallExplosion; // Efecto de explosi�n cuando el enemigo es alcanzado.

   

    private void Awake()  
    {
        InvokeRepeating("Attack", 1, timeBetweenBullets);  // Llama repetidamente a la funci�n Attack() despu�s de 1 segundo y luego cada 'timeBetweenBullets' segundos.
        player = GameObject.FindGameObjectWithTag("Player"); // Encuentra al jugador por su etiqueta.
        Magnemite = GameObject.Find("magnemite");// Encuentra el objeto Magnemite por su nombre.
        shoothAudio = GetComponent<AudioSource>(); // Obtiene el componente de audio del objeto.
        smallExplosion.Stop(); // Asegura que la explosi�n est� desactivada al inicio.
    }

    void Start()
    {

       
    }

    void Update()
    {
        if (player == null)  // Si el jugador ha sido destruido, no ejecuta m�s l�gica.
        {
            return;
        }
        diferencia = Magnemite.transform.position - transform.position; // Calcula la diferencia de posici�n entre Magnemite y el enemigo.
        distancia = diferencia.magnitude; // Calcula la distancia entre ambos objetos.
        direccion = diferencia.normalized;  // Normaliza la direcci�n para que tenga una magnitud de 1.
        transform.LookAt(Magnemite.transform.position); // Hace que el enemigo mire hacia Magnemite.
        FollowPlayer();  // Llama a la funci�n que hace que el enemigo siga al jugador.
    }
    private void FollowPlayer()
    {
       
        float distance = Vector3.Distance(transform.position, player.transform.position);  // Calcula la distancia entre el enemigo y el jugador.
        if (distance > distanceToPlayer) // Si el enemigo est� m�s lejos que 'distanceToPlayer', se mueve hacia el jugador.
        {
            transform.position += direccion * Time.deltaTime * velocidad;
        }
        
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "rayo")  // Si el enemigo es alcanzado por un objeto con la etiqueta "rayo", activa la explosi�n y lo destruye tras 1 segundo.
        {
            smallExplosion.Play();
            Destroy(gameObject, 1.0f);
        }
        
    }
    private void Attack()
    {
        if (player == null)  // Si el jugador ha sido destruido, no ejecuta el ataque.
        {
            return;
        }
        shoothAudio.Play();  // Reproduce el sonido de disparo.
        Instantiate(bulletPrefab,posRotBullet.position, posRotBullet.rotation);  // Crea una nueva bala en la posici�n y rotaci�n del objeto 'posRotBullet'.
    }
        
    

}
