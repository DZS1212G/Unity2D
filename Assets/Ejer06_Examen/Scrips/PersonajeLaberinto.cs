using UnityEngine;

public class PersonajeLaberinto : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
       float movH = Input.GetAxis("Horizontal");
       float movV = Input.GetAxis("Vertical");

       this.gameObject.transform.position += new Vector3(movH, movV, 0)*speed*Time.deltaTime;

    }
}
