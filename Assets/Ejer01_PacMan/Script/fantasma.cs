using UnityEngine;

public class fantasma : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float leftLimit = -10;
    public float rightLimit = 10;
    public float upLimit = 5;
    public float downLimit = -5;
    public int speedX;
    public int speedY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    { 
        this.transform.Translate(Vector3.right * Time.deltaTime * speedX);
        if (transform.position.x >= rightLimit)
        {
            speedX = -speedX;
            spriteRenderer.flipX = true;
            
        }
        if(transform.position.x <= leftLimit)
        {
            speedX = -speedX;
            spriteRenderer.flipX = false;
            
        }
        this.transform.Translate(Vector3.up * Time.deltaTime * speedY);
        if (transform.position.y >= upLimit)
        {
            speedY = -speedY;
        }
        if (transform.position.y <= downLimit)
        {
            speedY = -speedY;
        }
    }
}
