using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2_1 : MonoBehaviour
{

    Animator animator;
    public static bool isDoor = false;

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
        if (isDoor == true)
        {
            animator.SetBool("isOpen", true);
            Debug.Log("Door open");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (isDoor == false)
        {
            animator.SetBool("isOpen", false);
            Debug.Log("Door close");
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
