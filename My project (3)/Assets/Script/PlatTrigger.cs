using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatTrigger : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid;
    public static bool isPlatTrigger;
    bool isBox = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box")) //Æ®¸®°Å¶û ´êÀº°æ¿ì
        {
            isBox = true;
            Debug.Log("collision PlatTrigger");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBox == true) 
        {
            isPlatTrigger = true;
        }

        if (isPlatTrigger == true)
        {
            Light2.isTurnon = true;
            Debug.Log("PlatTrigger on");
        }
    }
}
