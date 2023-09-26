using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser2_2 : MonoBehaviour
{
    public GameObject SteonPrefab; //생성할 돌프리펩
    
    private float spawnRate = 1.3f; // 생성 주기
    
    private float timeAfterSpawn; // 최근 생성 시점에서 지난 시간

    public static bool isBreak = false;

    private void Start()
    {
        timeAfterSpawn = 0f; //초기화
    }

    private void Update()
    {
        timeAfterSpawn += Time.deltaTime; // timeAfterSpawn 갱신

        if (timeAfterSpawn >= spawnRate) // 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
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