using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 1.67f;
    Vector3 Notdir;
    private void Start()
    {
        Notdir = transform.position;
    }
    private void Update()
    {
        Move();
    }
    // 일정한 방향으로 이동
    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < Notdir.y +Speed *2-1)
        {
            transform.position += Vector3.up * Speed;
        }
        else if (Input.GetKeyDown(KeyCode.S) && transform.position.y > Notdir.y - Speed+1)
        {
            transform.position += Vector3.down * Speed;
        }
        else if (Input.GetKeyDown(KeyCode.A) && transform.position.x > Notdir.x - Speed* 5+ 1)
        {
            transform.position += Vector3.left * Speed;
        }
        else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < Notdir.x + Speed * 5 - 1)
        {
            transform.position += Vector3.right * Speed;
        }

    }
}
