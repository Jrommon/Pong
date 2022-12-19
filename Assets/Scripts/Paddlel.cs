using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddlel : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            _rigidbody2D.velocity = speed * Vector3.up;
        else if (Input.GetKey(KeyCode.DownArrow))
            _rigidbody2D.velocity = speed * Vector3.down;
        else
            _rigidbody2D.velocity = Vector2.zero;
    }
}
