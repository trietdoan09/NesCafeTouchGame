using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNCF : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private string tagName;
    private GameObject management;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        management = GameObject.FindGameObjectWithTag(tagName);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isShow", management.GetComponent<GameLogic>().isShowNCF);
        if (management.GetComponent<GameLogic>().isShowNCF)
        {
            Invoke("DisableAnimationNCF", 1.3f);
        }
    }

    void DisableAnimationNCF()
    {
        management.GetComponent<GameLogic>().isShowNCF = false;
    }
}
