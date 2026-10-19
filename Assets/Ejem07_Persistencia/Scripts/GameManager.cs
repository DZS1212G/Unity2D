using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Va en un GameObject vacío llamado "GameManager" de la escena "Juego".
public class GameManager : MonoBehaviour
{
    [Header("Panel inicial (pedir nombre)")]
    public GameObject panelNombre;        // Panel con el InputField y el botón Empezar
    public TMP_InputField campoNombre;    // Donde el jugador escribe su nombre

    [Header("Durante la partida")]
    public TextMeshProUGUI textoContador; // Muestra los puntos
    public TextMeshProUGUI textoAyuda;    // "ESPACIO suma - ESC termina" (opcional)

    private int puntuacionActual = 0;
    private bool jugando = false;         // false mientras se escribe el nombre
    private string nombreJugador = "Jugador";

    void Start()
    {
        // Al iniciar: se ve el panel del nombre y se ocultan los textos de juego
        panelNombre.SetActive(true);
        textoContador.gameObject.SetActive(false);
        if (textoAyuda != null) textoAyuda.gameObject.SetActive(false);

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
            ActualizarContador();
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
        textoContador.gameObject.SetActive(true);
        if (textoAyuda != null)
        {
            textoAyuda.gameObject.SetActive(true);
            textoAyuda.text = "ESPACIO: sumar punto    ESC: terminar";
        }

        puntuacionActual = 0;
        ActualizarContador();
        jugando = true;
    }

    private void ActualizarContador()
    {
        textoContador.text = nombreJugador + ": " + puntuacionActual;
    }

    public void FinDePartida()
    {
        jugando = false;
        Ranking.GuardarPuntuacion(nombreJugador, puntuacionActual);
        SceneManager.LoadScene("Ranking");
    }
}