using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class nube : MonoBehaviour
{
    public float speed = 5f;
    public float leftLimit = -10f;
    public float rightLimit = 10f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // movimiento en X usando dir (-1 o 1)
        transform.position += Vector3.right * speed * Time.deltaTime;

        // invertir dirección si llegamos a los límites (con tolerancia)
        if (transform.position.x >= rightLimit)
        {
            speed = -5f;
        }
        else if ( transform.position.x <= leftLimit)
        {
            speed = 5f;
        }
    }
 //    if (this.transform.position.x > limiteDerecho)
 //    {
 //       velocidad = -velocidad;
 //    }
 //    else if (this.transform.position.x<limiteIzquierdo)
 //    {
 //       velocidad = -velocidad;
 //    }
    }
