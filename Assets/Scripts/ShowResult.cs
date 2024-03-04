using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowResult : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    [SerializeField] private string nameTag1;
    [SerializeField] private string nameTag2;
    [SerializeField] private GameData gameData;
    [SerializeField] private GameObject winResultP1;
    [SerializeField] private GameObject lossResultP1;
    [SerializeField] private GameObject winResultP2;
    [SerializeField] private GameObject lossResultP2;
    [SerializeField] private GameObject endGameText;
    public bool isMultiEnd;


    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag(nameTag1);
        player2 = GameObject.FindGameObjectWithTag(nameTag2);
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.GetComponent<GameLogic>().timeReady <= 0)
        {
            ShowResultScene();
        }
    }
    private void SinglePlayer()
    {
        bool isWin = player1.GetComponent<GameLogic>().stack > 2 ? true : false;
        winResultP1.SetActive(isWin);
        lossResultP1.SetActive(!isWin);
    }
    private void MultiPlayer()
    {
        isMultiEnd = true;
        int stackP1 = player1.GetComponent<GameLogic>().stack;
        int stackP2 = player2.GetComponent<GameLogic>().stack;
        if (stackP1 > 2 || stackP2 > 2)
        {
            if (stackP1 > 2)
            {
                winResultP1.SetActive(true);
                lossResultP2.SetActive(true);
            }
            else
            {
                lossResultP1.SetActive(true);
                winResultP2.SetActive(true);
            }
        }
        else
        {
            StackEqual(stackP1, stackP2);
        }
    }
    private void StackEqual(int stackP1, int stackP2)
    {
        int pointP1 = player1.GetComponent<GameLogic>().point;
        int pointP2 = player2.GetComponent<GameLogic>().point;
        int timePointP1 = player1.GetComponent<GameLogic>().point;
        int timePointP2 = player2.GetComponent<GameLogic>().point;
        if (stackP1 > stackP2)
        {
            winResultP1.SetActive(true);
            lossResultP2.SetActive(true);
        }
        else
        {
            //stackP1 == stackP2
            if (stackP1 == stackP2)
            {
                if (pointP1 > pointP2)
                {
                    winResultP1.SetActive(true);
                    lossResultP2.SetActive(true);
                }
                else
                {
                    //pointP1 = pointP2
                    if (pointP1 == pointP2)
                    {
                        if (timePointP1 > timePointP2)
                        {
                            winResultP1.SetActive(true);
                            lossResultP2.SetActive(true);
                        }
                        else if (timePointP2 < timePointP1)
                        {
                            lossResultP1.SetActive(true);
                            winResultP2.SetActive(true);
                        }
                        else if (timePointP1 == timePointP2)
                        {
                            var random = Random.Range(0, 2);
                            if (random == 0)
                            {
                                winResultP1.SetActive(true);
                                lossResultP2.SetActive(true);
                            }
                            else
                            {
                                lossResultP1.SetActive(true);
                                winResultP2.SetActive(true);
                            }
                        }
                    }
                    else
                    {
                        lossResultP1.SetActive(true);
                        winResultP2.SetActive(true);
                    }
                }
            }
            else
            {
                lossResultP1.SetActive(true);
                winResultP2.SetActive(true);
            }
        }
    }
    private void ShowResultScene()
    {
        if (gameData.gameMode == 1)
        {
            if (player1.GetComponent<GameLogic>().timeCountDown < 0 || player1.GetComponent<GameLogic>().stack > 2)
            {
                StartCoroutine(EndGameAnimation());
            }
        }
        else
        {
            if (!isMultiEnd)
            {
                if (player1.GetComponent<GameLogic>().timeCountDown < 0 || player2.GetComponent<GameLogic>().timeCountDown < 0
                    || player1.GetComponent<GameLogic>().stack > 2 || player2.GetComponent<GameLogic>().stack > 2)
                {
                    StartCoroutine(EndGameAnimation());
                }

            }
        }
    }
    IEnumerator EndGameAnimation()
    {
        endGameText.SetActive(true);
        yield return new WaitForSeconds(1f);
        endGameText.SetActive(false);
        if (gameData.gameMode == 1)
        {
            SinglePlayer();
        }
        else
        {
            MultiPlayer();
        }
        yield return null;
    }
}
