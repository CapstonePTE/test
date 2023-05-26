using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope0_1 : MonoBehaviour
{
    public static bool isRopeOn = false;

    private void OnTriggerEnter2D(Collider2D collision) // ·ÎÇÁ¿¡ ´êÀ»¶§
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterController.isRope = true;
            Debug.Log("rope on");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // ·ÎÇÁ¶û ¶³¾îÁú¶§
    {
        CharacterController.isRope = false;
        Debug.Log("rope off");

    }

    Vector2 destination = new Vector2(45, 6);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRopeOn == true) 
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, 1);
        }
    }
}
