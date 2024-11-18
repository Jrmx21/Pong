using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKinematic : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float limiteVertical = 4.1f;
    [SerializeField] private bool player1 = true;
    [SerializeField] private float inMovementTime;
    void Start()
    {
        Transform roof = GameObject.Find("Techo").transform;
        float limit = roof.position.y - roof.localScale.y / 2 - transform.localScale.y / 2;
        // arreglar el limite vertical
        // limiteVertical = limit;

    }


    void Update()
    {
        //mueve al player
        //player 1
        if (player1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                inMovementTime = Mathf.Clamp(inMovementTime, 0.3f, 1f);
                inMovementTime += Time.deltaTime;
                transform.position = new Vector2(transform.position.x, transform.position.y + _speed * inMovementTime * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                inMovementTime = Mathf.Clamp(inMovementTime, 0.3f, 1f);
                inMovementTime += Time.deltaTime;
                transform.position = new Vector2(transform.position.x, transform.position.y - _speed * inMovementTime * Time.deltaTime);
            }
            else
            {
                inMovementTime = 0;
            }
        }
        else
        //player 2

        {
            float dirMove = Input.GetAxisRaw("Vertical2");
            transform.position += dirMove * _speed * Time.deltaTime * Vector3.up;
        }
        //limita el movimiento del player
        if (transform.position.y > limiteVertical)
        {
            transform.position = new Vector2(transform.position.x, limiteVertical);
        }
        if (transform.position.y < -limiteVertical)
        {
            transform.position = new Vector2(transform.position.x, -limiteVertical);
        }
    }
}
