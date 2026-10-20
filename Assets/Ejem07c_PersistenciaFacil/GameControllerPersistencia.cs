using UnityEngine;

public class GameControllerPersistencia : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("contador"))
            PlayerPrefs.SetInt("contador", PlayerPrefs.GetInt("contador") + 1);
        else
            PlayerPrefs.SetInt("contador", 1);
        Debug.Log(PlayerPrefs.GetInt("contador"));
    }

    // Update is called once per frame
    void Update()
    {
          
    }
    public void limpiarPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
