using UnityEngine;

public class PlatTrigger2_1_1 : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid;
    public static bool isPlatTrigger;
    bool isBox = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //Æ®¸®°Å¶û ´êÀº°æ¿ì
        {
            isBox = true;
            Debug.Log("collision PlatTrigger");
        }
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
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
            Spawner1_1.isShot = true;
            animator.SetBool("isPlatTrigger", true);
            Destroy(gameObject);
        }
        else if (isBox == false)
        {
            isPlatTrigger = false;
            Spawner1_1.isShot = false;
            animator.SetBool("isPlatTrigger", false);
        }
    }
}
