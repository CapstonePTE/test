using UnityEngine;

public class PlatTrigger2_1 : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid;
    public static bool isPlatTrigger;
    bool isBox = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box")) //Æ®¸®°Å¶û ´êÀº°æ¿ì
        {
            isBox = true;
            Debug.Log("collision PlatTrigger");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isBox == true)
        {
            isPlatTrigger = true;
            RotateBar2_1.isRotate = true;
        }
        else if(isBox == false)
        {
            isPlatTrigger = false;
            RotateBar2_1.isRotate = false;
        } 
    }
}
