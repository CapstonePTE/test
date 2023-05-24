using UnityEngine;

public class PlatTrigger1_1 : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid;
    public static bool isPlatTrigger;
    bool isBox = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player")) //Æ®¸®°Å¶û ´êÀº°æ¿ì
        {
            isBox = true;
            Debug.Log("collision PlatTrigger");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isBox = false;
        Debug.Log("Eixt PlatTrigger");
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
        }
        else if(isBox == false)
        {
            isPlatTrigger = false;
        } 

        if (isPlatTrigger == true)
        {
            Light1_2.isTurnon = true;
            Debug.Log("PlatTrigger on");
        }
        else if (isPlatTrigger == false)
        {
            Light1_2.isTurnon = false;
            Debug.Log("PlatTrigger off");
        }
    }
}
