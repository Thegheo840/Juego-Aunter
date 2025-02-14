using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panelGameOver;  // Panel de Game Over que se activar� cuando el jugador pierda.

    [SerializeField]
    private Enemigo enemyManager; // Referencia al script de gesti�n de enemigos, que se desactivar� al terminar el juego.

    public void GameOver()
    {
        panelGameOver.SetActive(true); // Muestra el panel de Game Over.
        enemyManager.enabled = false; // Desactiva la l�gica de los enemigos.
        Cursor.lockState = CursorLockMode.Confined;  // Libera el cursor para que el jugador pueda interactuar con la interfaz.
    }

    public void _LoadSceneLevel()
    {
        SceneManager.LoadScene("Level01"); // Carga la escena del nivel 1, reiniciando la partida.
    }
}
