using UnityEngine;
using System.Collections;

public class CharacterControler : MonoBehaviour {

    public float speed = 3f;
    public float jumpPower = 5.0f;

    Rigidbody rigdbody;
    Animator animator;
    Vector3 movement;

    float horizontalMove;
    float verticalMove;
    bool isJumping;

	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        rigdbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
    //키 입력
	void Update () {

        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        AnimationUpdate();
	}

    //물리적 처리
    void FixedUpdate ()
    {
        //Run();
        Jump();
    }

    void AnimationUpdate()
    {
        if (isJumping == true) { 
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }








    void Run()
    {
        movement.Set(horizontalMove, 0, verticalMove);
        movement = movement.normalized * speed * Time.deltaTime;

        rigdbody.MovePosition(transform.position + movement);
    }

    void Jump()
    {
        if (!isJumping)
        {
            return;
        }

        //rigdbody.MovePosition(transform.position + Vector3.up);
        rigdbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        isJumping = false;

        
    }
}
