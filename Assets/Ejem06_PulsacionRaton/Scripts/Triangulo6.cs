using UnityEngine;

public class Triangulo6 : MonoBehaviour
{
    private Animator animacion;
    private AudioSource audio;
    public AudioClip sonido;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animacion = this.GetComponent<Animator>();
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animacion.SetTrigger("Activar");
        }
    }
    private void ejecutarSonido()
    {
        audio.PlayOneShot(sonido, 1f);
    }
}
