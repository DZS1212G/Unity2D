using UnityEngine;

public class MovFondoAbejas : MonoBehaviour
{
    private float speed = 0.1f;
    private MeshRenderer mesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mesh.material.mainTextureOffset += new Vector2(-1 * Time.deltaTime, 0 * speed);
    }
}
