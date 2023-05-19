using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Rigidbody2D rigid;

    private void OnCollisionExit2D(Collision2D collision)
    {
        rigid.velocity = new Vector2(0, rigid.velocity.y);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
