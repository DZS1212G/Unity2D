using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerPlatform : MonoBehaviour
{
    public GameObject mario;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(mario);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
