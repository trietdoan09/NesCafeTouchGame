using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerManagement : MonoBehaviour
{
    [SerializeField] private GameObject test;
    [SerializeField] private Sprite[] faceIcons;
    [SerializeField] private Sprite[] nonFaceIcons;
    private bool isStop;

    // Start is called before the first frame update
    void Start()
    {
        //test.transform.position += new Vector3(0, -3 * Time.deltaTime, 0);
        RandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        test.transform.position += new Vector3(0, -3 * Time.deltaTime, 0);
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
        var _nonface = Instantiate(test);
        var randomPos = Random.Range(0, 2);
        _nonface.GetComponent<SpriteRenderer>().sprite = nonFaceIcons[randomPos];
        StartCoroutine(IconDrop(_nonface));
    }
    private void SpawnFace()
    {
        var _face = Instantiate(test);
        var randomPos = Random.Range(0, 2);
        _face.GetComponent<SpriteRenderer>().sprite = faceIcons[randomPos];
        StartCoroutine(IconDrop(_face));
    }
    IEnumerator IconDrop(GameObject _gameObject)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            _gameObject.transform.position += new Vector3(0, -3 * Time.deltaTime, 0);
            if (gameObject.transform.position.y < -5.7)
            {
                isStop = true;
                Destroy(_gameObject);
            }
            StopCoroutine(IconDrop(_gameObject));
            yield return null;
        }
    }
}
