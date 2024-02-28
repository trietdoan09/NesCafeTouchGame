using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SinglePlayerManagement : MonoBehaviour
{
    [SerializeField] private GameObject iconFace;
    [SerializeField] private GameObject iconNonFace;
    private int timeCountDown;
    [SerializeField] private TextMeshProUGUI showTime;
    public int point;
    [SerializeField] private int stack;
    [SerializeField] private Slider sliderStack;
    public bool isShowNCF;
    [SerializeField] private GameObject imageNCF;
    public bool isShowResult;
    [SerializeField] private GameObject showWinResult;
    [SerializeField] private GameObject showGameOverResult;
    [SerializeField] private GameObject showBackButton;

    // Start is called before the first frame update
    void Start()
    {
        point = 0;
        stack = 0;
        timeCountDown = 30;
        RandomSpawn();
        InvokeRepeating("RandomSpawn", 3f, 1);
        StartCoroutine(CheckTime());
        sliderStack.maxValue = 3;
        sliderStack.value = stack;
    }

    // Update is called once per frame
    void Update()
    {
        CountStack();
        ShowResult();
    }
    private void RandomSpawn()
    {
        var randomIcon = Random.Range(0, 2);
        Debug.Log(">>>>>>" + randomIcon);
        if(randomIcon == 0)
        {
            SpawnIcon();
        }
        else
        {
            SpawnFace();
        }
    }
    private void SpawnIcon()
    {
        var _nonface = Instantiate(iconNonFace);
        _nonface.GetComponent<IconDrop>().isFaceIcon = false;
    }
    private void SpawnFace()
    {
        var _face = Instantiate(iconFace);
        _face.GetComponent<IconDrop>().isFaceIcon = true;
    }
    IEnumerator CheckTime()
    {
        while (timeCountDown > 0)
        {
            yield return new WaitForSeconds(1f);
            showTime.text = $"" + timeCountDown;
            timeCountDown -= 1;
            yield return null;
        }
    }
    private void CountStack()
    {
        if(point >= 5)
        {
            stack += 1;
            point -= 5;
            imageNCF.SetActive(true);
            isShowNCF = true;
            Invoke("DisableShowNCF", 1.3f);
        }
    }
    private void DisableShowNCF()
    {        
        sliderStack.value = stack;
        imageNCF.SetActive(false);
    }
    private void ShowResult()
    {
        if(timeCountDown <= 0 || stack > 2)
        {
            CancelInvoke("RandomSpawn");
            isShowResult = true;
            showBackButton.SetActive(true);
            if (stack < 3)
            {
                showGameOverResult.SetActive(true);
                showWinResult.SetActive(false);
            }
            else
            {
                showGameOverResult.SetActive(false);
                showWinResult.SetActive(true);
            }
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
