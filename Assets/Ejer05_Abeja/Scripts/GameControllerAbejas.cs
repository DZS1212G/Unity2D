using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerAbejas : MonoBehaviour
{
    public static GameControllerAbejas objetoGameController { get; private set; }
    public TextMeshProUGUI texto;
    public Canvas canvas;
    private int choques = 0;
    public GameObject eggman;
    public GameObject fondo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texto.text = "Choques: " + choques;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Ejer05_Scene2");


        }
    }
    private void Awake()
    {
        objetoGameController = this;
        DontDestroyOnLoad(gameObject);
        if (eggman != null)
        {
            DontDestroyOnLoad(eggman);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(texto);
            DontDestroyOnLoad(fondo);
        }
    
    }
    public void setChoques(int choques)
    {
        this.choques = choques;
    }
    public int getChoques()
    {
        return this.choques;
    }
    public void aumentarChoque()
    {
        this.choques++;
        texto.text = "Choques: " + this.choques;
    }
}
