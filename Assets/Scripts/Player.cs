using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    
    public float FuerzaLineal = 10.0f; // Fuerza con la que se mueve el objeto hacia adelante o atr�s.
    public float giro = 5.0f; // Velocidad de rotaci�n del objeto.
    public GameObject panel; // Panel que se activar� en ciertas situaciones (por ejemplo, Game Over).

    [SerializeField]
    private GameManager gameManager;  // Referencia al GameManager para manejar eventos del juego.
    [SerializeField]
    private Enemigo enemigo; // Referencia al enemigo para activarlo o desactivarlo.
    [Header("Attack")]
    [SerializeField]
    private AudioSource shootAudio; // Fuente de audio para el disparo.
    [SerializeField]
    private ParticleSystem smallExplosion; // Efecto de part�culas que se activa cuando el objeto es golpeado.

    [Header("Health")]
    [SerializeField]
    private float maxHealth = 100; // Vida m�xima del objeto.
    [SerializeField]
    private float currentHealth = 100;  // Vida actual del objeto.
    [SerializeField]
    private float damageBullet = 5; // Da�o recibido por cada bala enemiga.
    [SerializeField]
    private Image lifeBar; // Barra de vida en la interfaz.
    void Awake()
    {
        shootAudio = GetComponent<AudioSource>(); // Obtiene el componente de audio.
        smallExplosion.Stop(); // Asegura que la explosi�n est� desactivada al inicio.
        currentHealth = maxHealth; // Inicializa la vida al m�ximo.
        lifeBar.fillAmount = 1; // Llena la barra de vida al inicio.
        panel.SetActive(false); // Oculta el panel de Game Over al iniciar.
        enemigo.enabled = true; // Activa la l�gica del enemigo.
    }
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * giro * Input.GetAxis("Horizontal"));  // Rotaci�n del objeto en el eje Y seg�n la entrada del jugador.
        transform.Translate (Vector3.forward * Time.deltaTime * FuerzaLineal * Input.GetAxis("Vertical")); // Movimiento hacia adelante o atr�s seg�n la entrada del jugador.
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "hunter" || coll.gameObject.tag == "BolaSombra")  // Comprueba si el objeto colisiona con un enemigo o proyectil enemigo.
        {
            smallExplosion.Play(); // Activa la explosi�n de part�culas.
            Debug.Log("Me toca");
            currentHealth -= damageBullet;// Reduce la vida seg�n el da�o recibido.
            lifeBar.fillAmount = currentHealth / maxHealth; // Actualiza la barra de vida.
            Destroy(coll.gameObject); // Destruye el objeto que caus� la colisi�n.
            if (currentHealth <= 0) // Si la vida llega a 0, el objeto es destruido 
            {
                Camera.main.transform.SetParent(null);// Desvincula la c�mara del objeto.
                Destroy(gameObject);  // Destruye el objeto.
                gameManager.GameOver(); // Llama a la funci�n de Game Over.


            }
        }
        
    }
    




}
