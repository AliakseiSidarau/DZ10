using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private Rigidbody2D _rb;
    //[SerializeField] private float _speed = 5;
    //private float moveH, moveV;
    //private Vector3 _input;
    [SerializeField] private float _speed = 5f;
    private Vector3 _forward;
    private Vector3 _right;

    void Start()
    {
        //_rb = GetComponent<Rigidbody2D>();
        _forward = Camera.main.transform.forward;
        _forward.y = 0;
        _forward = Vector3.Normalize(_forward);
        _right = Quaternion.Euler(new Vector3(0, 90, 0))* _forward;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
        //moveH = Input.GetAxis("Horizontal") * _speed;
        //moveV = Input.GetAxis("Vertical") * _speed;
        //_rb.velocity = new Vector2(moveH, moveV);
        //GatherInput();
    }
    void Move()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = _right * _speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = _forward * _speed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

    //void FixedUpdate()
    //{
    //    Move();
    //}

    //void GatherInput()
    //{
    //    _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0 , Input.GetAxisRaw("Vertical"));
    //}

    //void Move()
    //{
    //    _rb.MovePosition(transform.position + transform.forward * _speed * Time.deltaTime);
    //}
}
