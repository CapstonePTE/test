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
            Destroy(gameObject);
            Debug.Log("Door open");
        }
    }
}
