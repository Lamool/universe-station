using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController cc;
    private Animator animator;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float gravity = -9.81f;

    private Vector3 velocity;
    private Vector3 moveDirection;

    private int hashPosX = Animator.StringToHash("PosX");
    private int hashPosY = Animator.StringToHash("PosY");
    private int hashSpeed = Animator.StringToHash("Speed");

    float x;
    float z;

    //버튼으로 플레이어 움직임 조작
    bool isBtnMove = false;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.instance.ToggleUI(0);
        }
    }

    public void MoveForward()
    {
        isBtnMove = true;
        z = 1;
    }

    public void MoveBackward()
    {
        isBtnMove = true;
        z = -1;
    }

    public void MoveYReset()
    {
        z = 0;
        if (x == 0 && z == 0)
        {
            isBtnMove = false;
        }
    }

    public void MoveXReset()
    {
        x = 0;
        if (x == 0 && z == 0)
        {
            isBtnMove = false;
        }
    }


    public void MoveLeft()
    {
        isBtnMove = true;
        x = -1;
    }

    public void MoveRight()
    {
        isBtnMove = true;
        x = 1;
    }

    private void Move()
    {
        if (!isBtnMove)
        {
            // WASD �Է� �ޱ�
            x = Input.GetAxis("Horizontal"); // A, D
            z = Input.GetAxis("Vertical");   // W, S
            
            //animator.SetFloat(hashPosX, x);
            //animator.SetFloat(hashPosY, z);
        }

        bool IsRun = Input.GetKeyDown(KeyCode.LeftShift);
        float turnSpeed = 100f;
        transform.Rotate(Vector3.up * x * turnSpeed * Time.deltaTime);
        moveSpeed = (z == 0) ? 0 : (IsRun ? 5f : 3f);
        animator.SetFloat(hashSpeed, moveSpeed);

        // ���� ���
        moveDirection = transform.forward * z;

        // �߷� ����
        if (cc.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f; // ���� ���̴� �뵵
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // �̵� ����
        Vector3 finalMove = moveDirection * moveSpeed + velocity;
        cc.Move(finalMove * Time.deltaTime);
    }
}
