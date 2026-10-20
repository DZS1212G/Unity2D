using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerExame : MonoBehaviour
{
    private int colisiones = 0;
    public TextMeshProUGUI texto;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texto.text = "Llevas " + colisiones + " choques";
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void limpiarPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    public void aumentarChoque()
    {
        colisiones++;
        if (colisiones >= 10)
        {
            SceneManager.LoadScene("Fin");
        }
        else
        {
            texto.text = "Llevas " + colisiones + " choques";
        }
        
    }
}
