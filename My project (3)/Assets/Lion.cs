using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D LionRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        LionRigidbody = GetComponent<Rigidbody2D>();
        LionRigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
