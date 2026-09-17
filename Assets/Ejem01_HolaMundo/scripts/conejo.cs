using Unity.VisualScripting;
using UnityEngine;

public class conejo : MonoBehaviour
{
    public float speed = 5;
    public float leftLimit = -10;
    public float rightLimit = 10;
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        // movimiento en X usando dir (-1 o 1)
        transform.position += Vector3.right * speed * Time.deltaTime;

        // invertir dirección si llegamos a los límites (con tolerancia)
        if (transform.position.x > rightLimit)
        {
            spriteRenderer.flipX = true;
            speed = -speed;
        }
        else if (transform.position.x < leftLimit)
        {
            spriteRenderer.flipX = false;
            speed = -speed;
        }
    }
}
