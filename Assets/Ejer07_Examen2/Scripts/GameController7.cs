using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class GameController7 : MonoBehaviour
{
    private int caida = -1;
    public TextMeshProUGUI texto;
    public GameObject bola;
    public TextMeshProUGUI textoFinish;
    private bool over = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (texto != null)
        {
            aumentarCaidas();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (over)
        {
            textoFinish.transform.Translate(Vector2.up * Time.deltaTime * 12);
            if (textoFinish.transform.position.y >= 140)
            {
                over = false;
                Application.Quit();
            }
        }
        if (texto!= null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("FinPartida");
            }
        }

    }
    public void aumentarCaidas()
    {
        caida++;
        string mensaje = "Caidas: " + caida + " / 4";
        texto.text = mensaje;
        if (caida >= 4)
        {
            gameOver();
        }
    }
    public void gameOver()
    {
        Destroy(bola.gameObject);
        over = true;
    }
    public void iniciarPartida()
    {
        SceneManager.LoadScene("Ejer07");
    }

    public void finalizarPartida()
    {
        Application.Quit();
    }

}
