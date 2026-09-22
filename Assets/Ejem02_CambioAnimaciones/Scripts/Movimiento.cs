using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public int speed = 1;
    Animator animatorPersonaje;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        animatorPersonaje = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoY = Input.GetAxis("Vertical");
        this.transform.Translate(new Vector3(movimientoX, movimientoY, 0) * Time.deltaTime * speed);
        if (movimientoX > 0) animatorPersonaje.SetInteger("tipo_estado", 6);
        if (movimientoX < 0) animatorPersonaje.SetInteger("tipo_estado", 4);
        if (movimientoY > 0) animatorPersonaje.SetInteger("tipo_estado", 8);
        if (movimientoY < 0) animatorPersonaje.SetInteger("tipo_estado", 2);
        //si en vez de poner if independientes le pones else if no te hara diagonales
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    this.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
        //    animatorPersonaje.SetInteger("tipo_estado", 6);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    this.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        //    animatorPersonaje.SetInteger("tipo_estado", 4);
        //}
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    this.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
        //    animatorPersonaje.SetInteger("tipo_estado", 8);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    this.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
        //    animatorPersonaje.SetInteger("tipo_estado", 2);
        //}
    }
}
