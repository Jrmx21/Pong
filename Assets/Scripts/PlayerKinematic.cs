using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKinematic : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float limiteVertical = 4.1f;
    [SerializeField] private bool player1 = true;
    void Start()
    {

    }


    void Update()
    {
        //player 1
        if (player1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                //mueve al player
                transform.position = new Vector2(transform.position.x, transform.position.y + _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - _speed * Time.deltaTime);
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
