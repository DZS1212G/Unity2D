using TMPro;
using UnityEngine;

public class GameController6 : MonoBehaviour
{
    public GameObject bola;
    public TextMeshProUGUI texto;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("crearBola", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject[] jugadores = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in jugadores)
            {
                Destroy(player);
                aumentarPuntuacion();
            }
        }
    }
    public void aumentarPuntuacion()
    {
        int puntuacionActu = int.Parse(texto.text);
        puntuacionActu++;
        texto.text = puntuacionActu.ToString();
    }
    private void crearBola()
    {
        Vector2 posicionAleatoria = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
        GameObject nuevaBola = Instantiate(bola);
        nuevaBola.transform.position = posicionAleatoria;
    }

}
