using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light2_4 : MonoBehaviour
{
    Animator animator;
    public static bool isTurnon = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTurnon == true)
        {
            animator.SetBool("isLight", true);
            Debug.Log("Light4 on");
        }

        else if (isTurnon == false)
        {
            animator.SetBool("isLight", false);
            Debug.Log("Light4 off");
        }
    }
}
