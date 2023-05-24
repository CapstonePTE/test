using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar2_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Light2_1.isTurnon && Light2_2.isTurnon && Light2_3.isTurnon && Light2_4.isTurnon)
        {
            Destroy(gameObject);
        }
    }
}
