using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid;
    public static bool isTrigger;
    bool isPlayer = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player")) //Æ®¸®°Å¶û ´êÀº°æ¿ì
        {
            isPlayer = true;
            Debug.Log("collision trigger");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.V)) 
        {
            isTrigger = true;
        }

        if (isTrigger == true)
        {
            animator.SetBool("isTrigger", true);
            Light.isTurnon = true;
            Debug.Log("Trigger on");
        }
    }
}
