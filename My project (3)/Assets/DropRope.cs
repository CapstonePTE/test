using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRope : MonoBehaviour
{
    public static float speed = 5.0f;
    public static float DropCount = 0;
    public static bool isPlayer = false;
    public static bool isBreak = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer == true)
        {
            if (DropCount <= 0.3) 
            {
                WaterFallBreak.isBreak = true;
                Dispenser2_2.isBreak = true;
                Vector2 target = new Vector2(transform.position.x, transform.position.y - 0.1f);
                transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
                DropCount += Time.deltaTime;
            }
            
        }  
    }
}
