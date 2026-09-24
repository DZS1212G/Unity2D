using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class MovimientoPelotas : MonoBehaviour
{
    public int speed;
    public int sentido;
    public GameObject prefabBola;
    private int contador = 0;
    public GameObject controladorJuego;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("creandoBola",1,2);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.right * Time.deltaTime * speed * sentido);
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rojo" && prefabBola != null)
        {
            Destroy(collision.gameObject);
            Instantiate(prefabBola);
        }
    }
    private void creandoBola()
    {
        if (prefabBola != null)
        {
            Instantiate(prefabBola);
        }
       
    }
    private void OnBecameInvisible()
    {
        if (gameObject.tag == "Azul")
        {
            Debug.Log("LLevas " + contador + " golpes");
        }
        
    }
    public int getContador()
    {
        return contador;
    }
    public void setContador(int contador)
    {
        this.contador = contador;
    }
}
