using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Va en un GameObject vacío llamado "GameManager" de la escena "Juego".
public class GameManagerMario : MonoBehaviour
{
    [Header("Panel inicial (pedir nombre)")]
    public GameObject panelNombre;        // Panel con el InputField y el botón Empezar
    public TMP_InputField campoNombre;    // Donde el jugador escribe su nombre

    private int puntuacionActual = 0;
    private bool jugando = false;         // false mientras se escribe el nombre
    private string nombreJugador = "Jugador";

    void Start()
    {
        // Al iniciar: se ve el panel del nombre y se ocultan los textos de juego
        panelNombre.SetActive(true);

        // Ponemos el cursor en el campo para escribir directamente
        campoNombre.text = "";
        campoNombre.ActivateInputField();
    }

    void Update()
    {
        if (!jugando)
        {
            // Mientras escribe el nombre, ENTER también empieza la partida
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                EmpezarPartida();
            return;   // no seguimos: el espacio aún no debe sumar puntos
        }

        // ESPACIO: suma un punto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            puntuacionActual++;
        }

        // ESCAPE: termina la partida
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FinDePartida();
        }
    }

    // Se llama desde el OnClick del botón "Empezar" (y con ENTER)
    public void EmpezarPartida()
    {
        // Si no escribe nada, usamos "Jugador"
        nombreJugador = campoNombre.text.Trim();
        if (nombreJugador == "") nombreJugador = "Jugador";

        panelNombre.SetActive(false);
       

        
        jugando = true;
    }


    public void FinDePartida()
    {
        jugando = false;
        Ranking.GuardarPuntuacion(nombreJugador);
        SceneManager.LoadScene("Ranking");
    }
}