using Unity.VisualScripting;
using UnityEngine;

public class arbol : MonoBehaviour
{
    public Joystick joystick;
    public int speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //    if (Input.GetKey(KeyCode.RightArrow))
        //    {
        //        this.transform.Translate(Vector3.right * Time.deltaTime * 4);
        //    }
        //    if (Input.GetKey(KeyCode.LeftArrow))
        //    {
        //        this.transform.Translate(Vector3.left * Time.deltaTime * 4);
        //    }
        //    if (Input.GetKey(KeyCode.UpArrow))
        //    {
        //        this.transform.Translate(Vector3.up * Time.deltaTime * 4);
        //    }
        //    if (Input.GetKey(KeyCode.DownArrow))
        //    {
        //        this.transform.Translate(Vector3.down * Time.deltaTime * 4);
        //    }


        //float movimientoH = Input.GetAxis("Horizontal");
        //float movimientoV = Input.GetAxis("Vertical");
        //this.transform.Translate(new Vector3(movimientoH, movimientoV, 0) * Time.deltaTime * speed);



        this.transform.Translate(new Vector3(joystick.Horizontal,joystick.Vertical,0) * Time.deltaTime * speed);

    }
}
