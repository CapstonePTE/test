using UnityEngine;

public class Switch2_3 : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player")) //Ʈ���Ŷ� �������
        {
            isPlayer = true;
            Debug.Log("collision Switch");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayer = false;
        Debug.Log("Exit Switch");
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
            isSwitch = !isSwitch;
            Light2_4.isTurnon = !Light2_4.isTurnon;
            Light2_3.isTurnon = !Light2_3.isTurnon;
        }

        if (isSwitch == true)
        {
            animator.SetBool("isTrigger", true);
            Debug.Log("Switch2 on");
        }

        else if (isSwitch == false)
        {
            animator.SetBool("isTrigger", false);
            Debug.Log("Switch2 off");

        }

    }
}
