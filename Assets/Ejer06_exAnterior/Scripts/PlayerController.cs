
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions.Must;


public class PlayerController : MonoBehaviour
{
    public float velocidad = 4f;
    public TMP_Text textoGolpes;
    // NO
    //public Animator animator;
    private Animator animator;

    private Rigidbody2D rb;
    private Vector2 movimiento;
    private Vector2 posicionInicial;

    private int golpes = 0;
    private bool activo = false;

 
    // NO void Awake()
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;

        posicionInicial = rb.position;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
       // if (!activo) return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movimiento = new Vector2(horizontal, vertical).normalized;

        // Elegir la animación según la dirección.

        if (horizontal > 0)
        {
            animator.SetInteger("Animacion", 6);
        }
        else if (horizontal < 0)
        {
            animator.SetInteger("Animacion", 4);
        }
        else if (vertical > 0)
        {
            animator.SetInteger("Animacion", 8);
        }
        else if (vertical < 0)
        {
            animator.SetInteger("Animacion", 2);
        }
        else
            animator.SetInteger("Animacion", 0);
        rb.MovePosition(
            rb.position +
            movimiento * velocidad * Time.fixedDeltaTime
        );
    }

   

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!activo) return;

        if (!collision.gameObject.CompareTag("Pared"))
            return;

        golpes++;

        textoGolpes.text = "Golpes: " + golpes + " / 10";

        movimiento = Vector2.zero;
        rb.position = posicionInicial;
        rb.linearVelocity = Vector2.zero;

        // Volver a la animación de quieto.
        animator.SetInteger("Animacion", 0);

        if (golpes >= 10)
        {
            activo = false;
            SceneManager.LoadScene("Fin");
        }
    }

    public void Iniciar()
    {
        golpes = 0;
        textoGolpes.text = "Golpes: 0 / 10";

        rb.position = posicionInicial;
        rb.linearVelocity = Vector2.zero;

        movimiento = Vector2.zero;
        animator.SetInteger("Animacion", 0);

        activo = true;
    }
}
