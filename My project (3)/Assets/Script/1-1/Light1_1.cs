using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light1_1 : MonoBehaviour
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
            Debug.Log("Light1 on");
            Door1_1.isDoor1 = true;
        }

        else if (isTurnon == false)
        {
            animator.SetBool("isLight", false);
            Debug.Log("Light1 off");
            Door1_1.isDoor1 = false;
        }
    }
}
