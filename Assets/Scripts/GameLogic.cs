using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public int timeReady;
    [SerializeField] private TextMeshProUGUI timeToReady;
    [SerializeField] private GameObject iconFace;
    [SerializeField] private GameObject iconNonFace;
    [SerializeField] private float minPosition;
    [SerializeField] private float maxPosition;
    public int timeCountDown;
    public int timeGetPoint;
    [SerializeField] private TextMeshProUGUI showTime;
    public int point;
    public int stack;
    [SerializeField] private Slider sliderStack;
    public bool isShowNCF;
    [SerializeField] private GameObject imageNCF;
    public bool isShowResult;
    [SerializeField] private GameObject showBackButton;
    private ShowResult result;

    // Start is called before the first frame update
    void Start()
    {
        timeReady = 3;
        result = FindObjectOfType<ShowResult>();
        StartCoroutine(ReadyStartGame());
    }

    // Update is called once per frame
    void Update()
    {
        if (timeReady <= 0)
        {
            CountStack();
            ShowResult();
        }
    }
    IEnumerator ReadyStartGame()
    {
        while (timeReady >= 0)
        {
            yield return new WaitForSeconds(1f);
            timeReady -= 1;
            timeToReady.text = $"" + timeReady;
            if (timeReady <= 0)
            {
                point = 0;
                stack = 0;
                timeCountDown = 32;
                showTime.enabled = true;
                RandomSpawn();
                InvokeRepeating("RandomSpawn", 3f, 1);
                StartCoroutine(CheckTime());
                sliderStack.maxValue = 3;
                sliderStack.value = stack;
                timeToReady.enabled = false;
            }
            yield return null;
        }
    }
    private void RandomSpawn()
    {
        var randomIcon = Random.Range(0, 2);
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
        _nonface.transform.position = new Vector3(Random.RandomRange(minPosition, maxPosition), 5.82f, 0);

    }
    private void SpawnFace()
    {
        var _face = Instantiate(iconFace);
        _face.GetComponent<IconDrop>().isFaceIcon = true;
        _face.transform.position = new Vector3(Random.RandomRange(minPosition, maxPosition), 5.82f, 0);
    }
    IEnumerator CheckTime()
    {
        while (timeCountDown >= 0)
        {
            if (!isShowNCF)
            {
                showTime.text = $"00:" + (timeCountDown-2);
                timeCountDown -= 1;
            }
            yield return new WaitForSeconds(2f);
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
            StartCoroutine(LoadStack());
        }
    }
    IEnumerator LoadStack()
    {
        while(sliderStack.value < stack)
        {
            sliderStack.value += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }
    private void DisableShowNCF()
    {        
        //sliderStack.value = stack;
        imageNCF.SetActive(false);
    }
    private void ShowResult()
    {
        if(timeCountDown < 0 || stack > 2 || result.GetComponent<ShowResult>().isMultiEnd)
        {
            StopAllCoroutines();
            CancelInvoke("RandomSpawn");
            isShowResult = true;
            showBackButton.SetActive(true);
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
