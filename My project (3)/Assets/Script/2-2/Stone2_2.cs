using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone2_2 : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            Destroy(gameObject, 0.5f);
    }
}