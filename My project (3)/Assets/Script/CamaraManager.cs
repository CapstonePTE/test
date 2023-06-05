using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraManager : MonoBehaviour
{

    public GameObject target; // ī�޶� ���� ���
    public float moveSpeed; // ī�޶� ���� �ӵ�
    private Vector3 targetPosition; // ����� ���� ��ġ

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ����� �ִ��� üũ

    }

    private void FixedUpdate()
    {
        if (target.gameObject != null)
        {
            // this�� ī�޶� �ǹ� (z���� ī�޶��� �״�� ����)
            targetPosition.Set(target.transform.position.x, target.transform.position.y + 3, transform.position.z);

            // vectorA -> B���� T�� �ӵ��� �̵�
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime * 2f);
        }
    }
}