using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController2 : MonoBehaviour
{
    public static GameController2 objetoGameController { get; private set; }

    public GameObject mario;
    public GameObject fondo;
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
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Platform2");


        }
    }
}