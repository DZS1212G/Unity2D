using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerExamen : MonoBehaviour
{
    public TMP_InputField input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void cargarNombre()
    {
        if (input.text == "")
        {
            PlayerPrefs.SetString("nombre", "Jugador");
        }
        else
        {
            PlayerPrefs.SetString("nombre", input.text);
        }
        SceneManager.LoadScene("Laberinto");

    }
}
