using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water3_2 : MonoBehaviour
{
    public GameObject bar;
    public static int Count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Count == 5)
        {
            GameObject.Find("Water3_2").transform.Find("bar").gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 1, transform.localScale.z);
            Count++;
            Debug.Log(Count);
        }
    }
}
