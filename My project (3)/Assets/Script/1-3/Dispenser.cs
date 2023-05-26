using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    public GameObject SteonPrefab; //������ ��������
    
    private float spawnRate = 2; // ���� �ֱ�
    
    private float timeAfterSpawn; // �ֱ� ���� �������� ���� �ð�

    private void Start()
    {
        timeAfterSpawn = 0f; //�ʱ�ȭ
    }

    private void Update()
    {
        if (Water3_2.Count != 5)
        {
            
            timeAfterSpawn += Time.deltaTime; // timeAfterSpawn ����
            
            if (timeAfterSpawn >= spawnRate) // �ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
            { 
                timeAfterSpawn = 0f;
                
                GameObject Stone = Instantiate(SteonPrefab, transform.position, transform.rotation);
            }
        }
        else if (Water3_2.Count == 5)
        {
            Destroy(gameObject);
        }
    }
}