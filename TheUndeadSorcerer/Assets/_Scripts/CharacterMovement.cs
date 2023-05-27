using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    private float turnSmoothVelocity;
    private float gravity = 9.81f;

    [SerializeField] private float runSpeed = 5.0f;
    [SerializeField] private float turnSmoothTime = 0.1f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(hInput, 0f, vInput).normalized;

        if(direction.magnitude >= 0.1f)
        {
            Run();
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(direction * runSpeed * Time.deltaTime);
            
            if (Input.GetKey(KeyCode.Alpha1))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    JumpAttack();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    RunningJump();
                }
            }
        }
        else
        {
            Idle();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        controller.Move(Vector3.down * gravity * Time.deltaTime);
    }

    private void Idle()
    {
        animator.SetBool("Run", false);
    }

    private void Run()
    {
        animator.SetBool("Run", true);
    }

    private void Jump()
    {
        animator.SetBool("Jump", true);
    }

    private void FinishJump()
    {
        animator.SetBool("Jump", false);
    }

    private void RunningJump()
    {
        animator.SetBool("RunningJump", true);
    }

    private void FinishRunningJump()
    {
        animator.SetBool("RunningJump", false);
    }

    private void JumpAttack()
    {
        animator.SetBool("JumpAttack", true);
    }

    private void FinishJumpAttack()
    {
        animator.SetBool("JumpAttack", false);
    }
}
