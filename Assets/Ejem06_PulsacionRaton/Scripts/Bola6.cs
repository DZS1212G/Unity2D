using Unity.AI.Navigation.LowLevel;
using UnityEngine;

public class Bola6 : MonoBehaviour
{
    private GameController6 gameController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController6>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (this.GetComponent<CircleCollider2D>() == Physics2D.OverlapPoint(worldPosition))
            {
                Destroy(this.gameObject);
                gameController.aumentarPuntuacion();
                
            }
        }
    }
}
