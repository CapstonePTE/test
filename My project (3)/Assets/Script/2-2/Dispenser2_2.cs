using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser2_2 : MonoBehaviour
{
    public GameObject SteonPrefab; //������ ��������
    
    private float spawnRate = 1.3f; // ���� �ֱ�
    
    private float timeAfterSpawn; // �ֱ� ���� �������� ���� �ð�

    public static bool isBreak = false;

    private void Start()
    {
        timeAfterSpawn = 0f; //�ʱ�ȭ
    }

    private void Update()
    {
        timeAfterSpawn += Time.deltaTime; // timeAfterSpawn ����

        if (timeAfterSpawn >= spawnRate) // �ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        {
            timeAfterSpawn = 0f;

            GameObject Stone = Instantiate(SteonPrefab, transform.position, transform.rotation);
        }

        if (isBreak == true)
        {
            Destroy(gameObject);
        }
    }
}