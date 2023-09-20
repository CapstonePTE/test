using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRope_1 : MonoBehaviour
{



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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
