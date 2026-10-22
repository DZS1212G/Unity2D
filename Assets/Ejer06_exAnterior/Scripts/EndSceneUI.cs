
using UnityEngine;
using TMPro;

public class EndSceneUI : MonoBehaviour
{
    public TMP_Text mensajeFinal;
    

    void Start()
    {
        string nombreJugador="";
        if (PlayerPrefs.HasKey("nombreJugador"))
        {
            nombreJugador = PlayerPrefs.GetString("nombreJugador");

            // Opcional: Borras la clave si solo la querías para este traspaso
            PlayerPrefs.DeleteKey("nombreJugador");
        }

        mensajeFinal.text =
            "FIN\n\nGracias por jugar, " + nombreJugador + "!";
    }
}
 