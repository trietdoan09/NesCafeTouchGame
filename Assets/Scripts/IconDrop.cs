using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconDrop : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    // Start is called before the first frame update
    void Start()
    {
        SetImage();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(0, -3 * Time.deltaTime, 0);
        DeleteItem();
    }
    private void SetImage()
    {
        var randomImage = Random.Range(0, images.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = images[randomImage];
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
        Destroy(gameObject);
    }
}
