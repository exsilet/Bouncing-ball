using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;

    private Rigidbody _rigidbody;

    public float horizontalInput;
    public bool isGrounded;
    public float checkRadius;
    public Transform groundCheck;
    public LayerMask layerMask;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        ChekinGround();
    }

    public void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveHorizontal = transform.right * horizontalInput * _speed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + moveHorizontal);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _tapForce);
        }
    }

    private void ChekinGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, layerMask);
    }
}
