using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1_1 : MonoBehaviour
{

    Animator animator;
    public static bool isDoor1 = false;
    public static bool isDoor2 = false;

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
        if (isDoor1 == true && isDoor2 == true)
        {
            Destroy(gameObject);
            Debug.Log("Door open");
        }
    }
}
