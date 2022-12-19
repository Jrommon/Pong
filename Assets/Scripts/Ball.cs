using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float velocity;

    [SerializeField]  private float _incrementVelocity = 1f;
    private Vector2 _velocityPrev;

    void Awake()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        GameManager.Instance.Ball = this;
    }

    private void Start()
    {
        Launch();

    }

    void Update()
    {
        
    }

    public void Launch() 
    {
        float v = Random.Range(0.4f, 1f);
        //(Random.Range(0, 2) == 0 ? -1 : 1) Sirve para decidir si la direccion es positiva o negativa. Su probabilidad es de 50/50
        float x = v * (Random.Range(0, 2) == 0 ? -1 : 1);
        float y = v * (Random.Range(0, 2) == 0 ? -1 : 1);
        transform.position = Vector2.zero;
        _rigidbody2D.velocity = velocity * (new Vector2(x, y)).normalized;
        //_velocityPrev = _rigidbody2D.velocity;
    }

    private void FixedUpdate()
    {
        _velocityPrev = _rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _rigidbody2D.velocity = _velocityPrev + Accelerate(_velocityPrev);
            _rigidbody2D.velocity = new Vector2(-_rigidbody2D.velocity.x, _rigidbody2D.velocity.y);

            switch (collision.collider.sharedMaterial.name)
            {
                case "PaddleMiddle":
                    break;
                case "PaddleTop":
                    break;
                case "PaddleBotton":
                    break;
            }
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            _rigidbody2D.velocity = _velocityPrev;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, -_rigidbody2D.velocity.y);
        }
    }

    private Vector2 Accelerate(Vector2 velocity)
    {
        return _incrementVelocity * velocity.normalized;
    }

    private void OnDrawGizmos()
    {
        //DEBUG
        Gizmos.color = Color.red;
        if (_rigidbody2D != null)
        {
            Gizmos.DrawLine(transform.position, (Vector2)transform.position + _rigidbody2D.velocity);
        }
    }
}
