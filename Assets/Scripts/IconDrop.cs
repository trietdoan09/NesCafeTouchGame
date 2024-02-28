using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconDrop : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    public bool isFaceIcon;
    [SerializeField] private int pointIcon;
    private SinglePlayerManagement playerManagement;
    [SerializeField] private int speed;
    [SerializeField] private int tempSpeed;
    // Start is called before the first frame update
    void Start()
    {
        SetImage();
        SetPosition();
        speed = Random.Range(3, 8);
        tempSpeed = speed;
        playerManagement = FindObjectOfType<SinglePlayerManagement>();
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
        Debug.Log("Imange.Length " + images.Length);
        Debug.Log("Random image " + randomImage);
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
    private void SetPosition()
    {
        gameObject.transform.position = new Vector3(Random.RandomRange(-1.99f, 2.14f), 5.82f, 0);
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
        if(playerManagement.point + pointIcon <= 0)
        {
            playerManagement.point = 0;
        }
        else
        {
            playerManagement.point += pointIcon;
        }
        Destroy(gameObject);
    }
    private void TimeStop()
    {
        if (playerManagement.isShowNCF || playerManagement.isShowResult)
        {
            speed = 0;
        }
        else
        {
            speed = tempSpeed;
        }
    }
}
