using UnityEngine;

public class Bola : MonoBehaviour
{
    public float speed;
    public float salto;
    bool suelo = false;
    private Animator animatorPersonaje;
    private SpriteRenderer spriteRender;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.animatorPersonaje = this.GetComponent<Animator>();
        this.spriteRender = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        this.transform.Translate(new Vector3(movimientoH,0,0) * Time.deltaTime * speed);
   
        if (Input.GetKeyDown(KeyCode.Space) && suelo)
        {           
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * salto, ForceMode2D.Impulse);
            

        }
        if (!suelo)
        {
            this.animatorPersonaje.SetInteger("Valor", 3);
        }
        else if (movimientoH > 0)
        {
            this.spriteRender.flipX = false;
            this.animatorPersonaje.SetInteger("Valor", 2);
            
        }
        else if (movimientoH < 0)
        {
            this.spriteRender.flipX = true;
            this.animatorPersonaje.SetInteger("Valor", 2);
        }
        
        else
        {
            animatorPersonaje.SetInteger("Valor", 0);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            this.animatorPersonaje.SetInteger("Valor", 0);
            suelo = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
           suelo = false;
        
    }
}
