using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1_2 : MonoBehaviour
{
    public static bool isShot = false;

    public GameObject LionPrefab;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LTrigger"))
        {
            isShot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }
    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(isShot == true)
        {
            // bulletPrefab의 복제본을 회전
            GameObject Lion = Instantiate(LionPrefab, transform.position, transform.rotation);
            Debug.Log("스포너 작동");
            isShot = false;
        }
    }


}
