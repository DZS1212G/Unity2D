using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController2 : MonoBehaviour
{
    public static GameController2 objetoGameController { get; private set; }

    public GameObject mario;
    public GameObject fondo;
    public GameObject flecha;
    public TextMeshProUGUI texto;
    public Canvas canvas;
    public int vidas = 3;
    private void Awake()
    {
        // Evitar que el GameController2 se duplique al cargar la nueva escena
        if (objetoGameController != null && objetoGameController != this)
        {
            Destroy(gameObject);
            return;
        }

        objetoGameController = this;
        DontDestroyOnLoad(gameObject); // Mantenemos el controlador

        if (mario != null)
        {
            DontDestroyOnLoad(mario); // Mantenemos a Mario
            DontDestroyOnLoad(fondo);
            DontDestroyOnLoad(canvas);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Platform2");


        }
    }
    private void Start()
    {
        texto.text = vidas.ToString();
        InvokeRepeating("crearFlecha", 2, 2);
    }
    private void crearFlecha()
    {
        Vector2 posicion = new Vector2(12, Random.Range(-4f, 4f));
        GameObject flechNueva = Instantiate(flecha);
        flechNueva.transform.position = posicion;
    }
    public void reducirVidas()
    {
        if (vidas == 1)
        {
            texto.text = "Game Over";
            Destroy(mario);
            texto.rectTransform.position = (new Vector2(400, 150));
        }
        else
        {
            vidas--;
            texto.text = vidas.ToString();
        }
    }
}