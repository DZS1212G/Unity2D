using UnityEngine;

public class Pelota7 : MonoBehaviour
{
    private GameController7 gameController;
    private Animator animator;
    public float speed;
    private SpriteRenderer sprite;
    Vector2 posInicio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController7>();
        sprite = this.GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();
        posInicio = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");
        this.gameObject.transform.position += new Vector3(movH, movV, 0) * Time.deltaTime * speed;
        if (movH == 0 && movV == 0)
        {
            animator.SetBool("Mover", false);
        }
        else
        {
            animator.SetBool("Mover", true);
            if (movH > 0)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameController.aumentarCaidas();
            this.transform.position = posInicio;
        }

    }
}
