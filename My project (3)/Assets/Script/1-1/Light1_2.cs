using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light1_2 : MonoBehaviour
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
            Debug.Log("Light2 on");
            Door1_1.isDoor2 = true;
        }
        else if (isTurnon == false)
        {
            animator.SetBool("isLight", false);
            Debug.Log("Light2 off");
            Door1_1.isDoor2 = false;
        }
    }
}
