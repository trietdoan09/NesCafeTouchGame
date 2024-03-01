using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [SerializeField] private GameData gameData;
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
        gameData.gameMode = 1;
        SceneManager.LoadScene("SinglePlayer");
    }
    public void MultiPlayer()
    {
        gameData.gameMode = 2;
        SceneManager.LoadScene("MultiPlayer");
    }
}
