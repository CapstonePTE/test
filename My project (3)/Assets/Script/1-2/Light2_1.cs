using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light2_1 : MonoBehaviour
{
    Animator animator;
    public static bool isTurnon = true;

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
            Debug.Log("Light1 on");
        }

        else if (isTurnon == false)
        {
            animator.SetBool("isLight", false);
            Debug.Log("Light1 off");
        }
    }
}
