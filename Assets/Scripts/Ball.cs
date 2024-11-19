using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _speedIncrement = 0.1f;
    [SerializeField] private float _umbralX = 3f;
    [SerializeField] private Vector2 contactWithPlayer;
    [SerializeField] private Vector2 lastRelativePosition;

    private Vector2 _velocityPrev;
    void Start()
    {
        direccionAleatoria();
    }

    public void direccionAleatoria()
    {
        _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
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
            lastRelativePosition = this.transform.position - col.transform.position;
            contactWithPlayer = col.contacts[0].point;
            Vector2 newDirection = new Vector2(2, 0).normalized;
            //avisame cuando choca en la parte superior, en medio o inferior
            if (lastRelativePosition.y > 0.5f)
            {
                Debug.Log("Choca arriba");
                Vector2 v = _velocityPrev.normalized;
                Vector2 normal = col.contacts[0].normal;
                _rigidBody2D.velocity = new Vector2(_velocityPrev.x, _velocityPrev.y);
                _rigidBody2D.velocity = Vector2.Reflect(_velocityPrev, normal);

     
                var angle = Vector2.Angle( _rigidBody2D.velocity, normal) * 2;

                Debug.Log("original angle: " + Vector2.Angle(_rigidBody2D.velocity, normal));
                Debug.Log("angle: " + angle);
                // calcula el vector de reflexion con el angulo nuevo y establece la velocidad a la bola
                var newDirectionAngle = Quaternion.AngleAxis(angle, Vector3.forward) * _velocityPrev;

            }
            if (lastRelativePosition.y < -0.5f)
            {
                Debug.Log("Choca abajo");
                // Similar para el caso de impacto abajo
                Vector2 v = _velocityPrev.normalized;
                _rigidBody2D.velocity = new Vector2(_velocityPrev.x, _velocityPrev.y);

                Vector2 normal = col.contacts[0].normal;
                // angle dividido por 2
                var angle = Vector2.Angle(_velocityPrev, normal) / 2;
                // calcula el vector de reflexion con el angulo nuevo y establece la velocidad a la bola
                var newDirectionAngle = Quaternion.AngleAxis(angle, Vector3.forward) * _velocityPrev;
                _rigidBody2D.velocity = Vector2.Reflect(newDirectionAngle, normal);


            }
            if (lastRelativePosition.y > -0.5f && lastRelativePosition.y < 0.5f)
            {
                Debug.Log("choca en medio");
                Vector2 v = _velocityPrev.normalized;
                _rigidBody2D.velocity = new Vector2(v.x * _speedIncrement, v.y * _speedIncrement);
                _rigidBody2D.velocity = new Vector2(-(_velocityPrev.x + v.x), _velocityPrev.y + v.y);

            }
            Debug.DrawRay(col.contacts[0].point, col.contacts[0].normal, Color.yellow, 2f);
            Debug.DrawRay(col.contacts[0].point, -_velocityPrev, Color.red, 2f);
            Debug.DrawRay(col.contacts[0].point, _rigidBody2D.velocity, Color.blue, 2f);

        }
        else if (col.gameObject.CompareTag("Wall"))
        {
            _rigidBody2D.velocity = new Vector2(_velocityPrev.x, -_velocityPrev.y);
        }
        // Verifica la velocidad en x > umbral
        if (Mathf.Abs(_rigidBody2D.velocity.x) < _umbralX)
        {
            _rigidBody2D.velocity = new Vector2(_umbralX, _rigidBody2D.velocity.y);
            Debug.Log("Velocidad en x menor al umbral");
        }

    }
}
