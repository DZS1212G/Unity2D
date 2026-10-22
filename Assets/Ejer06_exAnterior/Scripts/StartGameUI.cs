
using UnityEngine;
using TMPro;

public class StartGameUI : MonoBehaviour
{
    public TMP_InputField campoNombre;
    public GameObject panelInicio;
    public PlayerController jugador;
    private string nombreJugador;


    public void IniciarJuego()
    {
        string nombre = campoNombre.text.Trim();

        nombreJugador= string.IsNullOrEmpty(nombre) ? "Jugador" : nombre;

        // Guardas el texto en memoria persistente de Unity
        PlayerPrefs.SetString("nombreJugador", nombreJugador);
        PlayerPrefs.Save(); // Asegura el guardado
        panelInicio.SetActive(false);
        jugador.Iniciar();
    } 
}
