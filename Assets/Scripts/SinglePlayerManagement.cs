using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerManagement : MonoBehaviour
{
    [SerializeField] private GameObject iconFace;
    [SerializeField] private GameObject iconNonFace;

    // Start is called before the first frame update
    void Start()
    {
        RandomSpawn();
        InvokeRepeating("RandomSpawn", 3f, 1);
    }

    // Update is called once per frame
    void Update()
    {
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
    }
    private void SpawnFace()
    {
        var _face = Instantiate(iconFace);
    }
}
