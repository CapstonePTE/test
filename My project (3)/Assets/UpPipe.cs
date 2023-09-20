using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPipe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DropRope.isPlayer == true) // 떨어지는 밧줄과 위치 동기화
        {
            if (DropRope.DropCount <= 0.3)
            {
                Vector2 target = new Vector2(transform.position.x, transform.position.y + 0.1f);
                transform.position = Vector2.MoveTowards(transform.position, target, DropRope.speed * Time.deltaTime);
            }
        }
    }
}
