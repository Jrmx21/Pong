using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed = 10f;


    void Start()
    {
        direccionAleatoria();
    }

    public void direccionAleatoria(){
        _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f)).normalized;
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _rigidBody2D.velocity = _direction * _speed;
    }
    void Update()
    {

    }
}
