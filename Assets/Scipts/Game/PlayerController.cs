using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private KeyCode W;
    [SerializeField] private KeyCode A;
    [SerializeField] private KeyCode D;
    private bool _isGrounded = false;
    private Rigidbody2D _rb;

    private void Awake() => _rb = gameObject.GetComponent<Rigidbody2D>();

    private void Update()
    {   
        if (!_isGrounded)
            return;
        Movement();
        Rotation();
    }

    private void Rotation()
    {
        float input = 0;
        if (Input.GetKey(A))
            input -= 1;
        if (Input.GetKey(D))
            input += 1;
        
        float angle = -input * rotationSpeed;
        _rb.AddTorque(angle, ForceMode2D.Force);
    }

    private void Movement()
    {
        if (Input.GetKeyDown(W))
        {
            _rb.AddForce(transform.up * jumpForce * 100, ForceMode2D.Force);
            _isGrounded = false;
        }
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     // Проверка на контакт с землёй
    //     if (other.gameObject.CompareTag("Ground"))
    //     {
    //         _isGrounded = true;
    //     }
    // }

    private void OnTriggerStay2D(Collider2D other)
    {
        _isGrounded = other.gameObject.CompareTag("Ground");
    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Ground"))
    //     {
    //         _isGrounded = false;
    //     }
    // }
}