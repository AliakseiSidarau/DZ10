using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float moveH, moveV;

    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        //isoRederer = GetComponentInChildren<IsometricCharacterRendere>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        moveH = Input.GetAxis("Horizontal") * _speed;
        moveV = Input.GetAxis("Vertical") * _speed;

        _rb.velocity = new Vector2(moveH, moveV);

        Vector2 direction = new Vector2(moveH, moveV);
        FindObjectOfType<PlayerAnimation>().SetDirection(direction);

    }
}
