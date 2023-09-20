using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionSpawner : MonoBehaviour
{
    public static bool isShot = false;

    public GameObject LionPrefab;

    private Transform target;

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
        target = FindObjectOfType<CharacterController>().transform;
    }
    private void FixedUpdate()
    {
        //�� �߽ɱ������� �÷��̾� ��ġ�� ���� �¿� ��ġ ����

        transform.localPosition = new Vector2(-15, GameObject.FindGameObjectWithTag("Player").transform.position.y + 5f);
    }
    // Update is called once per frame
    void Update()
    {
        if(isShot == true)
        {
            // bulletPrefab�� �������� ȸ��
            GameObject Lion = Instantiate(LionPrefab, transform.position, transform.rotation);
            // ������ bullet�� ���� ������ target�� ���ϵ��� ȸ��
            Lion.transform.LookAt(target);
            Debug.Log("������ �۵�");
            isShot = false;
        }


        /*
        // timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;
        // �ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if (timeAfterSpawn >= spawnRate)
        {
            // ������ �ð��� ����
            timeAfterSpawn = 0f;
            // bulletPrefab�� �������� ȸ��
            GameObject Lion = Instantiate(LionPrefab, transform.position, transform.rotation);
            // ������ bullet�� ���� ������ target�� ���ϵ��� ȸ��
            Lion.transform.LookAt(target);
            // ������ ���� ������ ������
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            Debug.Log("������ �۵�");
        }
        **/
    }

    

}
