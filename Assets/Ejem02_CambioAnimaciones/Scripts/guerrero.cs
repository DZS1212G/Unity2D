using UnityEngine;

public class guerrero : MonoBehaviour
{
    public int speed = 0;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
            float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        this.transform.Translate(new Vector3(movimientoH, movimientoV, 0) * Time.deltaTime * speed);

        if (movimientoV > 0) animator.SetInteger("tipo_estado", 8);
        if (movimientoV < 0) animator.SetInteger("tipo_estado", 2);
        if (movimientoH > 0) animator.SetInteger("tipo_estado", 6);
        if (movimientoH < 0) animator.SetInteger("tipo_estado", 4);
        

        //if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        //{
        //    this.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
        //    animator.SetInteger("tipo_estado", 6);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))
        //{
        //    this.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        //    animator.SetInteger("tipo_estado", 4);
        //}
        //if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        //{
        //    this.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
        //    animator.SetInteger("tipo_estado", 2);
        //}
        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        //{
        //    this.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
        //    animator.SetInteger("tipo_estado", 8);
        //}
    }
}
