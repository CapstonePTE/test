using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
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
    }
}
