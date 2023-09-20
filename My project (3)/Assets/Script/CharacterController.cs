using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public float speed = 5.0f; // 캐릭터 이동 속도
    public float jumpForce = 7.0f; // 캐릭터의 점프 힘
    public float dashSpeed;
    public float defaultTime;
    public static float dashTime;
    public static bool isDashStart; //대쉬 시작판별용
    private int jumpCount;
    public float maxSpeed;
    public float maxJump; //점프 최대 가속도 설정
    public float maxUp; //사다리 상승 속도
    Rigidbody2D rigid;
    private Rigidbody2D rb;
    private bool isGrounded; // 캐릭터가 땅에 있는지 여부
    public static bool isRope = false; //로프에 닿아있는지 확인
    public static bool isBrave = false; //용기의 보석을 먹었는지 체크
    public static bool isDash = false; //대쉬 기능 체크
    Animator animator; //애니메이터 조작을 위한 변수
    public GameManager gameManager; //게임매니저 스크립트
    bool isDamaged;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 캐릭터의 Rigidbody2D 컴포넌트 가져오기
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
        if (DropRope.isPlayer == true) // 떨어지는 밧줄과 위치 동기화
        {
            if (DropRope.DropCount <= 0.3)
            {
                Vector2 target = new Vector2(transform.position.x, transform.position.y - 0.1f);
                transform.position = Vector2.MoveTowards(transform.position, target, DropRope.speed * Time.deltaTime);
            }
        }

        if (isBrave == true) // 용기의 보석 획득시
        {
            if (Input.GetKeyDown(KeyCode.Z)) // z 키를 누르고 땅에 있는 경우에만 점프하기
            {
                jumpCount--;
                if (jumpCount == 1)
                {
                    rigid.velocity = new Vector2(rigid.velocity.x, 0); // 점프키 입력시 공중에서도 위로 힘을 받도록 설정
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // Rigidbody2D에 위쪽 방향으로 힘을 가해 캐릭터를 점프시키기
                    animator.SetBool("isJump", true);
                    isGrounded = false;
                }
                else if (jumpCount == 0)
                {
                    rigid.velocity = new Vector2(rigid.velocity.x + jumpForce, 0); //두번째 점프의 경우 공중에 뛴다는 느낌을 확실히 주기위해 + jumpForce를 작성
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
            if (Input.GetKey(KeyCode.UpArrow)) // 로프에 닿아았을때
            {
                //DropRope.isPlayer = true;
                rb.gravityScale = 0; // 중력 제거
                GetComponent<CapsuleCollider2D>().isTrigger = true;
                animator.SetBool("isClimb", true);
                rb.AddForce(Vector2.up * v, ForceMode2D.Impulse);
                if (rigid.velocity.y > maxUp)
                {
                    rigid.velocity = new Vector2(rigid.velocity.x, maxUp); //최대 상승 속도
                    Debug.Log("up");
                    transform.position = new Vector3(GameObject.FindGameObjectWithTag("Rope").transform.position.x, transform.position.y, transform.position.z);
                    isGrounded = true;
                }
            }

            else if (Input.GetKeyUp(KeyCode.UpArrow)) // 방향키 때면 정지
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                Debug.Log("off");
            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.gravityScale = 0; // 중력 제거
                GetComponent<CapsuleCollider2D>().isTrigger = true;
                animator.SetBool("isClimb", true);
                rb.AddForce(Vector2.up * v, ForceMode2D.Impulse);
                if (rigid.velocity.y < maxUp * (-1))
                {
                    rigid.velocity = new Vector2(rigid.velocity.x, maxUp * (-1)); //최대 하강 속도
                    Debug.Log("down");
                    transform.position = new Vector3(GameObject.FindGameObjectWithTag("Rope").transform.position.x, transform.position.y, transform.position.z);
                    isGrounded = true;
                }
            }

            else if (Input.GetKeyUp(KeyCode.DownArrow)) // 방향키 때면 정지
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                Debug.Log("off");
            }
        }

        else if (isRope == false)
        {
            rb.gravityScale = 1; //중력 복구}
            animator.SetBool("isClimb", false);
        }

        if (isDash == true)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                isDashStart = true;
                Debug.Log("대쉬");
            }

            if (dashTime <= 0)
            {
                if (isDashStart == true)
                    dashTime = defaultTime;
                maxSpeed = 6;
                animator.SetBool("isDash", false);
            }
            else
            {
                dashTime -= Time.deltaTime;
                maxSpeed += dashSpeed;
                speed = dashSpeed;
                animator.SetBool("isDash", true);
            }
            isDashStart = false;
        }

    }

        

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // 방향키로 수평 방향 이동 입력 받기

        Vector2 movement = new Vector2(moveHorizontal, 0).normalized; // 입력된 방향을 벡터로 저장하고 정규화

        rb.AddForce(movement * speed); // Rigidbody2D에 힘을 가해 캐릭터 이동시키기

        float h = Input.GetAxisRaw("Horizontal");




        if (isDamaged == true)
        {
            
        }

        else if (isDamaged == false)
        {
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


        

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box")) // 캐릭터가 땅에 닿은 경우
        {
            isGrounded = true; // 땅에 있음으로 상태 변경
            jumpCount = 2;
        }
        
        //적 또는 함정에 닿았을 때
        else if (collision.gameObject.tag == "Enemy")
        {
            OnDamaged(collision.transform.position);
            gameManager.HealthDown(); //대미지를 1 입음
            Debug.Log("대미지를 입었습니다");
        }

        if (collision.gameObject.tag == "FallingSpace")
        {
            gameManager.HealthDown(); //대미지를 1 입음
            Debug.Log("맵 밖으로 나가 대미지를 입었습니다.");

            if (gameManager.health >= 1)
                transform.position = new Vector3(0, 0, -1); // 캐릭터가 해당 스테이지 시작위치로 이동

        }

        if (collision.gameObject.tag == "2BossCamera")
        {
            gameManager.OnKill(); //대미지를 1 입음
            Debug.Log("즉사");

            if (gameManager.health >= 1)
                transform.position = new Vector3(0, 0, -1); // 캐릭터가 해당 스테이지 시작위치로 이동

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GetComponent<CapsuleCollider2D>().isTrigger = true;
        }
        else if (collision.gameObject.tag == "Finish") //깃발에 닿은 경우
        {
            //다음 스테이지로 넘어감
            gameManager.Nextstage();
        }
        else if (collision.gameObject.tag == "DropRope") //깃발에 닿은 경우
        {
            //다음 스테이지로 넘어감
            DropRope.isPlayer = true;
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

    void OnDamaged(Vector2 targetPos) //방향키 입력 없을시 속도를 0으로 만드는 기능 때문에 뒤로 튕겨나가기 구현을 위해 isDamaged 추가
    {
        isDamaged = true;
        //gameObject는 자기자신을 의미
        //충돌시 플레이어의 레이어가 PlayerDamaged 즉,11번 레이어로 변해야 
        gameObject.layer = 11;
        SpriteRenderer.color = new Color(1, 1, 1, 0.4f);
        //한대 맞으면 튕겨나가게
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        //오른쪽으로 맞으면 오른쪽으로 튕겨나가고 왼쪽으로 맞으면 왼쪽으로 튕겨나가고
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
