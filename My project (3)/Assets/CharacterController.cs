using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public float speed = 5.0f; // 캐릭터 이동 속도
    public float jumpForce = 7.0f; // 캐릭터의 점프 힘
    private int jumpCount;
    public float maxSpeed;
    public float maxJump; //점프 최대 가속도 설정
    public float maxUp;
    Rigidbody2D rigid;
    private Rigidbody2D rb;
    private bool isGrounded; // 캐릭터가 땅에 있는지 여부
    public static bool isRope = false; //로프에 닿아있는지 확인
    public static bool isBrave = false; //용기의 보석을 먹었는지 체크
    Animator animator; //애니메이터 조작을 위한 변수

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 캐릭터의 Rigidbody2D 컴포넌트 가져오기
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() // isBrave 만들어서 1단점프 2단점프 구분하기
    {
        if (isBrave == true) // 용기의 보석 획득시
        {
            if (Input.GetKeyDown(KeyCode.Z)) // z 키를 누르고 땅에 있는 경우에만 점프하기
            {
                jumpCount--;
                if (jumpCount == 1)
                {
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // Rigidbody2D에 위쪽 방향으로 힘을 가해 캐릭터를 점프시키기
                    animator.SetBool("isJump", true);
                    isGrounded = false;
                }
                else if (jumpCount == 0)
                {
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // Rigidbody2D에 위쪽 방향으로 힘을 가해 캐릭터를 점프시키기
                    animator.SetBool("isDouble", true);

                    if (rigid.velocity.y > maxJump)//오른쪽
                    {
                        rigid.velocity = new Vector2(rigid.velocity.x, maxJump); // 점프 추가 가속도 방지
                    }
                }

            }
            else if (isGrounded == true)
            {
                animator.SetBool("isJump", false); // 1단점프시 초기화
                animator.SetBool("isDouble", false); // 2단점프시 초기화
            }
        }

        else if (isBrave == false) //용기의 보석 없는 경우
        {
            if (Input.GetKeyDown(KeyCode.Z) && isGrounded)
            {
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

        if (isRope == true && Input.GetKey(KeyCode.UpArrow)) // 로프에 닿아았을때
        {
            rb.gravityScale = 0; // 중력 제거

            rb.AddForce(Vector2.up * v, ForceMode2D.Impulse);
            if (rigid.velocity.y > maxUp)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, maxUp);
                Debug.Log("up");
            }
        }

        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            Debug.Log("off");
        }

        if (isRope == true && Input.GetKey(KeyCode.DownArrow))
        {
            rb.gravityScale = 0; // 중력 제거

            rb.AddForce(Vector2.up * v, ForceMode2D.Impulse);
            if (rigid.velocity.y < maxUp * (-1))
            {
                rigid.velocity = new Vector2(rigid.velocity.x, maxUp * (-1));
                Debug.Log("down");
            }
        }

        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            Debug.Log("off");
        }

        else if (isRope == false)
            rb.gravityScale = 1; //중력 복구
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // 방향키로 수평 방향 이동 입력 받기
        float moveVertical = Input.GetAxisRaw("Vertical"); // 방향키로 수직 방향 이동 입력 받기

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized; // 입력된 방향을 벡터로 저장하고 정규화

        rb.AddForce(movement * speed); // Rigidbody2D에 힘을 가해 캐릭터 이동시키기

        float h = Input.GetAxisRaw("Horizontal");
        

        if (h == 0) // 방향키를 떼면
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y); // 가해진 수평 방향 힘 제거
            animator.SetBool("isMove", false);
        }
        else // 방향키를 누르고 있는 동안
        {
            animator.SetBool("isMove", true);
            rb.AddForce(Vector2.right * h, ForceMode2D.Impulse);
            if (rigid.velocity.x > maxSpeed)//오른쪽
            {
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
                Debug.Log("Right");
            }
            else if (rigid.velocity.x < maxSpeed * (-1))//왼쪽
            {
                rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
                Debug.Log("Left");
            }

            if (rigid.velocity.x > 0.1) //방향전환
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
        if (collision.gameObject.CompareTag("Ground")) // 캐릭터가 땅에 닿은 경우
        {
            isGrounded = true; // 땅에 있음으로 상태 변경
            jumpCount = 2;
        }
    }
}
