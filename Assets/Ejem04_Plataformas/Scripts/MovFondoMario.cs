using UnityEngine;

public class MovFondoMario : MonoBehaviour
{
    private MeshRenderer mesh;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float movH = Input.GetAxis("Horizontal");

        mesh.material.mainTextureOffset += new Vector2(movH * 1 * Time.deltaTime, 0 * speed);
    }

}
