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
        // TODO: arreglar el limite vertical
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

                transform.position = new Vector2(transform.position.x, transform.position.y + _speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - _speed * Time.deltaTime);
            }
            else
            {
                inMovementTime = 0;
            }
        }
        else
        //player 2

        {
            //player 2

            if (Input.GetKey(KeyCode.UpArrow))
            {

                transform.position = new Vector2(transform.position.x, transform.position.y + _speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - _speed * Time.deltaTime);
            }
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
