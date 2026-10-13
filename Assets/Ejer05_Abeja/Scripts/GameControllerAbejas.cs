using TMPro;
using UnityEngine;

public class GameControllerAbejas : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public Canvas canvas;
    private int choques = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texto.text = "Choques: " + choques;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setChoques(int choques)
    {
        this.choques = choques;
    }
    public int getChoques()
    {
        return this.choques;
    }
    public void aumentarChoque()
    {
        this.choques++;
        texto.text = "Choques: " + this.choques;
    }
}
