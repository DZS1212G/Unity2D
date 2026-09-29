using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.SceneManagement;

public class Mario : MonoBehaviour
{
    int contador = 0;
    public float speed;
    public float salto;
    bool suelo = false;
    private Animator animatorPersonaje;
    private SpriteRenderer spriteRender;
    private Vector3 inicio;
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
   
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && suelo)
        {           
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * salto, ForceMode2D.Impulse);
            contador++;
            Debug.Log("Saltos: "+ contador);

        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.Translate(new Vector3(movimientoH, 0, 0) * Time.deltaTime * speed*1.5f);
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
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Platform2");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
           suelo = false;
        
    }
    private void OnBecameInvisible()
    {
        this.transform.position = new Vector3(0, 0, 0);
    }
}
