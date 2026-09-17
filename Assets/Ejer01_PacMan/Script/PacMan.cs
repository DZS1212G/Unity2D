using Unity.VisualScripting;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    public int speed = 5;
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        this.transform.Translate(new Vector3(movimientoH, movimientoV, 0) * Time.deltaTime * speed);
        if(movimientoV>1){
            spriteRenderer.flipX = true;
            speed = -speed;
        }
    }
}
