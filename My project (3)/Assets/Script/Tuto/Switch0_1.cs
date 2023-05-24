using UnityEngine;

public class Switch0_1 : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid;
    public static bool isSwitch;
    bool isPlayer = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //Æ®¸®°Å¶û ´êÀº°æ¿ì
        {
            isPlayer = true;
            Debug.Log("collision Switch");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.V))
        {
            if (isSwitch == false)
                isSwitch = true;

            else if (isSwitch == true)
                isSwitch = false;
        }

        if (isSwitch == true)
        {
            animator.SetBool("isTrigger", true);
            Debug.Log("Switch on");
            Rope0_1.isRopeOn = true;
        }

        else if (isSwitch == false)
        {
            animator.SetBool("isTrigger", false);
            Debug.Log("Switch off");
            Rope0_1.isRopeOn = false;
        }

    }
}
