using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_Chest : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid;
    public static bool isChest;
    bool isPlayer = false;
    public GameObject Brave;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //Ʈ���Ŷ� �������
        {
            isPlayer = true;
            Debug.Log("collision Chest");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayer = false;
        Debug.Log("Exit Chest");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.V))
        {
            isChest = true;
        }

        if (isChest == true)
        {
            animator.SetBool("IsOpened", true);
            Debug.Log("Chest open");
            DropItem();
        }

        void DropItem()
        {
            Instantiate(Brave);
            isChest = false;
        }
    }
}
