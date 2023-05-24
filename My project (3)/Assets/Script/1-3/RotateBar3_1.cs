using UnityEngine;

public class RotateBar3_1 : MonoBehaviour
{
    public static bool isRotate = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isRotate == false)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));

        else if (isRotate == true)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -45));
    }
}
