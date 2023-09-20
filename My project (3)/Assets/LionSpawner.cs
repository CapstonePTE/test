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
        //맵 중심기준으로 플레이어 위치에 따라 좌우 위치 변경

        transform.localPosition = new Vector2(-15, GameObject.FindGameObjectWithTag("Player").transform.position.y + 5f);
    }
    // Update is called once per frame
    void Update()
    {
        if(isShot == true)
        {
            // bulletPrefab의 복제본을 회전
            GameObject Lion = Instantiate(LionPrefab, transform.position, transform.rotation);
            // 생성된 bullet을 정면 방향이 target을 향하도록 회전
            Lion.transform.LookAt(target);
            Debug.Log("스포너 작동");
            isShot = false;
        }


        /*
        // timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;
        // 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if (timeAfterSpawn >= spawnRate)
        {
            // 누적된 시간을 리셋
            timeAfterSpawn = 0f;
            // bulletPrefab의 복제본을 회전
            GameObject Lion = Instantiate(LionPrefab, transform.position, transform.rotation);
            // 생성된 bullet을 정면 방향이 target을 향하도록 회전
            Lion.transform.LookAt(target);
            // 다음번 생성 간격을 재조정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            Debug.Log("스포너 작동");
        }
        **/
    }

    

}
