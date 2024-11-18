using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedIncrement = 0.1f;
    [SerializeField] private float _umbralX = 3f;

    private Vector2 _velocityPrev;
    void Start()
    {
        direccionAleatoria();
    }

    public void direccionAleatoria()
    {
        _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f)).normalized;
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _rigidBody2D.velocity = _direction * _speed;
        _velocityPrev = _rigidBody2D.velocity;
    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        _velocityPrev = _rigidBody2D.velocity;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("trigger with " + col.gameObject.name);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Vector2 v = _velocityPrev.normalized;
            _rigidBody2D.velocity = new Vector2(v.x * _speedIncrement, v.y * _speedIncrement);
            _rigidBody2D.velocity = new Vector2(-(_velocityPrev.x + v.x), _velocityPrev.y + v.y);
            Debug.Log(_rigidBody2D.velocity);
        }
        else if (col.gameObject.CompareTag("Wall"))
        {
            _rigidBody2D.velocity = new Vector2(_velocityPrev.x, -_velocityPrev.y);
        }
        // Verifica la velocidad en x > umbral
        if (Mathf.Abs(_rigidBody2D.velocity.x) < _umbralX && _umbralX > Mathf.Abs(_rigidBody2D.velocity.x))
        {
            _rigidBody2D.velocity = new Vector2(_umbralX, _rigidBody2D.velocity.y);
            Debug.Log("Velocidad en x menor al umbral");
        }
    }



}
