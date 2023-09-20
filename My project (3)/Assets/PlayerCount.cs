using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCount : MonoBehaviour
{

    Rigidbody2D rigid;
    bool isPlayer = false;
    public static bool isLion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //Ʈ���Ŷ� �������
        {
            isPlayer = true;
            Debug.Log("collision Switch");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayer = false;
        Debug.Log("Exit Switch");
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        isLion = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLion == true)
        {
            CancelInvoke("LionON");
            spawnlion();
        }
        else if (isLion == false) 
        {
            Invoke("LionON", 5f);

        }
    }

    void spawnlion() 
    {
        //���� ���� ��ȯ
        isLion = false;
        Debug.Log("���� �߻�");
        LionSpawner.isShot = false;
    }
    void LionON() 
    {
        Debug.Log("���� �߻� ����");
        isLion = true;
        LionSpawner.isShot = true;
    }

}
