using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Va en un GameObject vacío de la escena "Ranking".
public class MostrarRanking : MonoBehaviour
{
    public TextMeshProUGUI textoRanking;   // Lista del top 5
    public TextMeshProUGUI textoUltima;    // Resultado de la última partida (opcional)

    void Start()
    {
        string[] nombres = new string[Ranking.TAMANO];
        int[] puntos = new int[Ranking.TAMANO];
        Ranking.Cargar(nombres, puntos);

        int ultimaPosicion = PlayerPrefs.GetInt("UltimaPosicion", -1);

        textoRanking.text = "MEJORES PUNTUACIONES\n\n";
        for (int i = 0; i < Ranking.TAMANO; i++)
        {
            string linea = (i + 1) + ".  " + nombres[i] + "  " + puntos[i];

            // Resaltamos en amarillo la partida que se acaba de jugar
            if (i == ultimaPosicion)
                linea = "<color=yellow>" + linea + "  <- tú</color>";

            textoRanking.text += linea + "\n";
        }

        if (textoUltima != null)
        {
            string nombre = PlayerPrefs.GetString("UltimoNombre", "");
            int ultimos = PlayerPrefs.GetInt("UltimosPuntos", 0);

            if (ultimaPosicion >= 0)
                textoUltima.text = nombre + ", has hecho " + ultimos + " puntos. ¡Puesto " + (ultimaPosicion + 1) + "!";
            else
                textoUltima.text = nombre + ", has hecho " + ultimos + " puntos. No entras en el top 5.";
        }
    }

    void Update()
    {
        // ESPACIO o ENTER: jugar otra vez.  ESC: salir del juego
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            JugarOtraVez();

        if (Input.GetKeyDown(KeyCode.Escape))
            Salir();
    }

    // Para el OnClick de un botón "Jugar otra vez"
    public void JugarOtraVez()
    {
        SceneManager.LoadScene("Ejem07");
    }

    // Para el OnClick de un botón "Borrar récords"
    public void BorrarRecords()
    {
        Ranking.Borrar();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   // recarga la pantalla
    }

    // Para el OnClick de un botón "Salir"
    public void Salir()
    {
        Debug.Log("Salir del juego");   // Application.Quit no hace nada dentro del editor
        Application.Quit();
    }
}