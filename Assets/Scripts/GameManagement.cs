using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SinglePlayer()
    {
        SceneManager.LoadScene("SinglePlayer");
    }
    public void MultiPlayer()
    {
        SceneManager.LoadScene("MultiPlayer");
    }
}
