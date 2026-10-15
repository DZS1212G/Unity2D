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
    public GameObject abeja;
    private AudioSource sonido;
    public AudioClip warp;
    public AudioClip gameover;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texto.text = "Choques: " + choques;
        InvokeRepeating("InstanciarAbeja", 2f, 2f);
        sonido = this.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Ejer05_Scene2");
            sonido.PlayOneShot(warp,2f);
        }
        if (choques >= 10)
        {
            sonido.PlayOneShot(gameover,0.5f);       
            Destroy(eggman);
            texto.text = "Game Over";
            texto.transform.position = (new Vector2(300, 145));
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); 
        if (eggman != null)
        {
            DontDestroyOnLoad(eggman);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(texto);
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
    private void InstanciarAbeja()
    {
        for (int i = 0; i < 5; i++)
        {
            float randomY = Random.Range(-4.15f, 4.15f);
            Vector3 posicion = new Vector3(12, randomY, 0);
            Instantiate(abeja);
            abeja.transform.position = posicion;
        }


    }
}
