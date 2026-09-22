using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class MovimientoPelotas : MonoBehaviour
{
    public int speed;
    public int sentido;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.right * Time.deltaTime * speed * sentido);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colision");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Colision");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag=="Rojo")      
            Destroy(collision.gameObject);            
        
    }

}
