using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotStone : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D LionRigidbody;
    private Transform target;
    Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<CharacterController>().transform;
        dir = target.position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir.normalized * speed);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}