using UnityEngine;

public class Eggman : MonoBehaviour
{
    public float speed = 0.5f;
    private float limiteinf = -4.5f;
    private float limitesup = 4.5f;
    private Vector3 inicio;  // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameControllerAbejas gameController;
    private AudioSource sonido;
    public AudioClip daño;
    void Start()
    {
        inicio = this.transform.position;
        gameController = GameObject.Find("GameController").GetComponent<GameControllerAbejas>();
        sonido = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > limiteinf && this.transform.position.y < limitesup)
        {
            float movimientoY = Input.GetAxis("Vertical");
            this.transform.Translate(new Vector3(0, movimientoY) * Time.deltaTime * speed);
        }
        else
        {
            this.transform.position = inicio;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameController.aumentarChoque();
            Destroy(collision.gameObject);
            sonido.PlayOneShot(daño);
        }
    }
}
