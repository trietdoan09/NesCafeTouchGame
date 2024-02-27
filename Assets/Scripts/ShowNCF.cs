using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNCF : MonoBehaviour
{
    private Animator animator;
    private SinglePlayerManagement management;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        management = FindObjectOfType<SinglePlayerManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isShow", management.isShowNCF);
        if (management.isShowNCF)
        {
            Invoke("DisableAnimationNCF", 1.3f);
        }
    }

    void DisableAnimationNCF()
    {
        management.isShowNCF = false;
    }
}
