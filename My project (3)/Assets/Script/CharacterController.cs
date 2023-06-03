using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public float speed = 5.0f; // ĳ���� �̵� �ӵ�
    public float jumpForce = 7.0f; // ĳ������ ���� ��
    private int jumpCount;
    public float maxSpeed;
    public float maxJump; //���� �ִ� ���ӵ� ����
    public float maxUp; //��ٸ� ��� �ӵ�
    Rigidbody2D rigid;
    private Rigidbody2D rb;
    private bool isGrounded; // ĳ���Ͱ� ���� �ִ��� ����
    public static bool isRope = false; //������ ����ִ��� Ȯ��
    public static bool isBrave = false; //����� ������ �Ծ����� üũ
    Animator animator; //�ִϸ����� ������ ���� ����
    public GameManager gameManager; //���ӸŴ��� ��ũ��Ʈ
    bool isDamaged;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ĳ������ Rigidbody2D ������Ʈ ��������
        Debug.Log(transform.position);

    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isBrave == true) // ����� ���� ȹ���
        {
            if (Input.GetKeyDown(KeyCode.Z)) // z Ű�� ������ ���� �ִ� ��쿡�� �����ϱ�
            {
                jumpCount--;
                if (jumpCount == 1)
                {
                    rigid.velocity = new Vector2(rigid.velocity.x, 0); // ����Ű �Է½� ���߿����� ���� ���� �޵��� ����
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // Rigidbody2D�� ���� �������� ���� ���� ĳ���͸� ������Ű��
                    animator.SetBool("isJump", true);
                    isGrounded = false;
                }
                else if (jumpCount == 0)
                {
                    rigid.velocity = new Vector2(rigid.velocity.x + jumpForce, 0); //�ι�° ������ ��� ���߿� �ڴٴ� ������ Ȯ���� �ֱ����� + jumpForce�� �ۼ�
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // Rigidbody2D�� ���� �������� ���� ���� ĳ���͸� ������Ű��
                    animator.SetBool("isDouble", true);

                    if (rigid.velocity.y > maxJump)//������
                    {
                        rigid.velocity = new Vector2(rigid.velocity.x, maxJump); // ���� �߰� ���ӵ� ����
                    }
                }

            }
            else if (isGrounded == true)
            {
                animator.SetBool("isJump", false); // 1�������� �ʱ�ȭ
                animator.SetBool("isDouble", false); // 2�������� �ʱ�ȭ
            }
        }

        else if (isBrave == false) //����� ���� ���� ���
        {
            if (Input.GetKeyDown(KeyCode.Z) && isGrounded)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isGrounded = false;
                animator.SetBool("isJump", true);
                Debug.Log("jump");
            }
            else if (isGrounded == true)
            {
                animator.SetBool("isJump", false);
            }
        }

        float v = Input.GetAxisRaw("Vertical");

        if (isRope == true)
        {
            if (Input.GetKey(KeyCode.UpArrow)) // ������ ��ƾ�����
            {
                rb.gravityScale = 0; // �߷� ����
                GetComponent<CapsuleCollider2D>().isTrigger = true;
                animator.SetBool("isClimb", true);
                rb.AddForce(Vector2.up * v, ForceMode2D.Impulse);
                if (rigid.velocity.y > maxUp)
                {
                    rigid.velocity = new Vector2(rigid.velocity.x, maxUp); //�ִ� ��� �ӵ�
                    Debug.Log("up");
                    transform.position = new Vector3(GameObject.FindGameObjectWithTag("Rope").transform.position.x, transform.position.y, transform.position.z);
                    isGrounded = true;
                }
            }

            else if (Input.GetKeyUp(KeyCode.UpArrow)) // ����Ű ���� ����
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                Debug.Log("off");
            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.gravityScale = 0; // �߷� ����
                GetComponent<CapsuleCollider2D>().isTrigger = true;
                animator.SetBool("isClimb", true);
                rb.AddForce(Vector2.up * v, ForceMode2D.Impulse);
                if (rigid.velocity.y < maxUp * (-1))
                {
                    rigid.velocity = new Vector2(rigid.velocity.x, maxUp * (-1)); //�ִ� �ϰ� �ӵ�
                    Debug.Log("down");
                    transform.position = new Vector3(GameObject.FindGameObjectWithTag("Rope").transform.position.x, transform.position.y, transform.position.z);
                    isGrounded = true;
                }
            }

            else if (Input.GetKeyUp(KeyCode.DownArrow)) // ����Ű ���� ����
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                Debug.Log("off");
            }
        }

        else if (isRope == false)
        {
            rb.gravityScale = 1; //�߷� ����}
            animator.SetBool("isClimb", false);
        }
    }

        

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // ����Ű�� ���� ���� �̵� �Է� �ޱ�

        Vector2 movement = new Vector2(moveHorizontal, 0).normalized; // �Էµ� ������ ���ͷ� �����ϰ� ����ȭ

        rb.AddForce(movement * speed); // Rigidbody2D�� ���� ���� ĳ���� �̵���Ű��

        float h = Input.GetAxisRaw("Horizontal");




        if (isDamaged == true)
        {
            
        }

        else if (isDamaged == false)
        {
            if (h == 0) // ����Ű�� ����
            {
                rigid.velocity = new Vector2(0, rigid.velocity.y); // ������ ���� ���� �� ����
                animator.SetBool("isMove", false);

            }
            else // ����Ű�� ������ �ִ� ����
            {
                animator.SetBool("isMove", true);
                rb.AddForce(Vector2.right * h, ForceMode2D.Impulse);
                if (rigid.velocity.x > maxSpeed)//������
                {
                    rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
                    Debug.Log("Right");
                }
                else if (rigid.velocity.x < maxSpeed * (-1))//����
                {
                    rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
                    Debug.Log("Left");
                }

                if (rigid.velocity.x > 0.1) //������ȯ
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else if (rigid.velocity.x < 0.1 * (-1))
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
            }
        }

       


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box")) // ĳ���Ͱ� ���� ���� ���
        {
            isGrounded = true; // ���� �������� ���� ����
            jumpCount = 2;
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            OnDamaged(collision.transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GetComponent<CapsuleCollider2D>().isTrigger = true;
        }
        else if (collision.gameObject.tag == "Finish") //��߿� ���� ���
        {
            //���� ���������� �Ѿ
            gameManager.Nextstage();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<CapsuleCollider2D>().isTrigger = false;
    }
    public void VelocityZero()
    {
        transform.position = new Vector3(0, 0, 0);
        rigid.velocity = Vector2.zero;
    }

    void OnDamaged(Vector2 targetPos) //����Ű �Է� ������ �ӵ��� 0���� ����� ��� ������ �ڷ� ƨ�ܳ����� ������ ���� isDamaged �߰�
    {
        isDamaged = true;
        //gameObject�� �ڱ��ڽ��� �ǹ�
        //�浹�� �÷��̾��� ���̾ PlayerDamaged ��,11�� ���̾�� ���ؾ� 
        gameObject.layer = 11;
        SpriteRenderer.color = new Color(1, 1, 1, 0.4f);
        //�Ѵ� ������ ƨ�ܳ�����
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        //���������� ������ ���������� ƨ�ܳ����� �������� ������ �������� ƨ�ܳ�����
        rigid.velocity = new Vector2(0, rigid.velocity.y);
        rigid.AddForce(new Vector2(dirc, 1) * 5, ForceMode2D.Impulse);
        animator.SetBool("isHurt", true);
        Invoke("OffDamaged2", 0.35f);
        Invoke("OffDamaged", 1.5f); 
    }

    void OffDamaged()
    {
        gameObject.layer = 10;
        SpriteRenderer.color = new Color(1, 1, 1, 1);
        
    }

    void OffDamaged2()
    {
        isDamaged = false;
        animator.SetBool("isHurt", false);
    }
}
