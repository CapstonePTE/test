using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFallBreak : MonoBehaviour
{

    public static bool isBreak = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBreak == true)
        {
            Destroy(gameObject);
        }
    }
}
