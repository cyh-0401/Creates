using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody rb; // 클래스 위에 선언
    [SerializeField] float movSpeed = 25f;
    void Start()
    {
        PrintInstructions();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void PrintInstructions()
    {
        Debug.Log("Welcome to the game");
        Debug.Log("Move your player with WASD or arrow keys.");
        Debug.Log("Don't hit the walls!");
    }

    void MovePlayer()
    {
        /* 지속으로 이동키를 누르면 통과하는 문제발생, 아래는 수정된거
        float xValue = Input.GetAxis("Vertical") * movSpeed * Time.deltaTime;
        float zValue = Input.GetAxis("Horizontal") * movSpeed * Time.deltaTime;

        transform.Translate(xValue, 0, -zValue, Space.World);
        */ 

        float xInput = Input.GetAxis("Vertical");
        float zInput = Input.GetAxis("Horizontal");

        Vector3 moveDir = new Vector3(xInput, 0, -zInput).normalized;
        Vector3 moveAmount = moveDir * movSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + moveAmount);
    }
}
