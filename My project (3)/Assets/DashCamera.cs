using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCamera : MonoBehaviour
{
    public static float speed = 5f;
    private Vector3 targetPosition;
    public float acc = 0;
    public static bool isReset = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isReset == false)
        {
            targetPosition.Set(transform.position.x + acc, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime * 2f);
            acc += 0.01f;
            if (acc >= 0.5f)
            {
                acc = 0.5f;
            }
        }
        else if(isReset == true)
        {
            transform.position = new Vector3(0, 0, -10);
            acc = 0;
            isReset = false;
        }
    }
}
