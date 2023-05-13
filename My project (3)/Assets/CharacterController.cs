using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public float speed = 5.0f; // ĳ���� �̵� �ӵ�
    public float jumpForce = 7.0f; // ĳ������ ���� ��
    private int jumpCount;
    public float maxSpeed;
    public float maxJump; //���� �ִ� ���ӵ� ����
    Rigidbody2D rigid;
    private Rigidbody2D rb;
    private bool isGrounded; // ĳ���Ͱ� ���� �ִ��� ����
    public static bool isBrave = false; //����� ������ �Ծ����� üũ
    Animator animator; //�ִϸ����� ������ ���� ����

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ĳ������ Rigidbody2D ������Ʈ ��������
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() // isBrave ���� 1������ 2������ �����ϱ�
    {
        if (isBrave == true) // ����� ���� ȹ���
        {
            if (Input.GetKeyDown(KeyCode.Z)) // z Ű�� ������ ���� �ִ� ��쿡�� �����ϱ�
            {
                jumpCount--;
                if (jumpCount == 1)
                {
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // Rigidbody2D�� ���� �������� ���� ���� ĳ���͸� ������Ű��
                    animator.SetBool("isJump", true);
                    isGrounded = false;
                }
                else if (jumpCount == 0)
                {
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
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isGrounded = false;
                animator.SetBool("isJump", true);
            }
            else if (isGrounded == true) 
            {
                animator.SetBool("isJump", false);
            }
        }

        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // ����Ű�� ���� ���� �̵� �Է� �ޱ�
        float moveVertical = Input.GetAxisRaw("Vertical"); // ����Ű�� ���� ���� �̵� �Է� �ޱ�

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized; // �Էµ� ������ ���ͷ� �����ϰ� ����ȭ

        rb.AddForce(movement * speed); // Rigidbody2D�� ���� ���� ĳ���� �̵���Ű��

        float h = Input.GetAxisRaw("Horizontal");

        if (h == 0) // ����Ű�� ����
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y); // ������ ���� ���� �� ����
            animator.SetBool("isMove", false);
        }
        else // ����Ű�� ������ �ִ� ����
        {
            animator.SetBool("isMove", true);
            rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
            if (rigid.velocity.x > maxSpeed)//������
            {
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            }
            else if (rigid.velocity.x < maxSpeed * (-1))//����
            {
                rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
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



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // ĳ���Ͱ� ���� ���� ���
        {
            isGrounded = true; // ���� �������� ���� ����
            jumpCount = 2;
        }
    }
}