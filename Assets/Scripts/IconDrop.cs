using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconDrop : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    public bool isFaceIcon;
    [SerializeField] private int pointIcon;
    private GameObject playerManagement;
    [SerializeField] private int speed;
    [SerializeField] private int tempSpeed;
    [SerializeField] private string nameTag;
    // Start is called before the first frame update
    void Start()
    {
        SetImage();
        speed = Random.Range(3, 8);
        tempSpeed = speed;
        playerManagement = GameObject.FindGameObjectWithTag(nameTag);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(0, -1 * Time.deltaTime *speed, 0);
        DeleteItem();
        TimeStop();
    }
    private void SetImage()
    {
        var randomImage = Random.Range(0, images.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = images[randomImage];
        if (isFaceIcon)
        {
            pointIcon = -2;
        }
        else
        {
            if (randomImage == images.Length-1)
            {
                pointIcon = 2;
            }
            else
            {
                pointIcon = 1;
            }
        }
    }
    private void DeleteItem()
    {
        if(gameObject.transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }
    private void OnMouseDown()
    {
        if (!playerManagement.GetComponent<GameLogic>().isShowNCF)
        {
            if (playerManagement.GetComponent<GameLogic>().point + pointIcon <= 0)
            {
                playerManagement.GetComponent<GameLogic>().point = 0;
            }
            else
            {
                playerManagement.GetComponent<GameLogic>().point += pointIcon;
                playerManagement.GetComponent<GameLogic>().timeGetPoint = playerManagement.GetComponent<GameLogic>().timeCountDown;
            }
            Destroy(gameObject);
        }
    }
    private void TimeStop()
    {
        if (playerManagement.GetComponent<GameLogic>().isShowNCF || playerManagement.GetComponent<GameLogic>().isShowResult)
        {
            speed = 0;
            if (playerManagement.GetComponent<GameLogic>().isShowResult)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            speed = tempSpeed;
        }
    }
}
