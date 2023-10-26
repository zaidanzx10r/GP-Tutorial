using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;

    private Vector2 currentRotation;

    [Header("Camera")]
    [SerializeField, Range(1, 20)] private float mouseSensX;
    [SerializeField, Range(1, 20)] private float mouseSensY;

    [SerializeField, Range(-90, 0)] private float minViewAngle;
    [SerializeField, Range(0, 90)] private float maxViewAngle;

    [SerializeField] private Transform followTarget;
    
    private Vector2 currentAngle;

    [Header("Shooting")]
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private float bulletForce;

    private bool isGrounded;
    private Vector3 _moveDirection;

    private Rigidbody rb;

     void Start()
    {
        InputManager.Init(this);
        InputManager.Gamemode();

        rb = GetComponent<Rigidbody>();
    }

     void Update()
    {
        transform.position +=  transform.rotation * (speed * Time.deltaTime * _moveDirection);
        checkGrounded();
       
    }

    public void SetMovementDirection(Vector3 newDirection)
    {
        _moveDirection = newDirection;
    }

    public void SetJump()
    {
        Debug.Log("Jump Called");
        if (isGrounded)
        {
            Debug.Log("I jumped");
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
    }

    private void checkGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, GetComponent<Collider>().bounds.size.y);
        Debug.DrawRay(transform.position, Vector3.down * GetComponent<Collider>().bounds.size.y, Color.green, 0, false);
    }

    public void SetLookRotation(Vector2 readValue)
    {
        currentAngle.x += readValue.x * Time.deltaTime * mouseSensX;
        currentAngle.y += readValue.y * Time.deltaTime * mouseSensY;

        float clamp = Mathf.Clamp(currentAngle.y, minViewAngle, maxViewAngle);
        
        transform.rotation = Quaternion.AngleAxis(currentAngle.x, Vector3.up);
        followTarget.localRotation = Quaternion.AngleAxis(currentAngle.y, Vector3.right);

    }

    public void Shoot()
    {
        Rigidbody currentProjectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        currentProjectile.AddForce(followTarget.forward * bulletForce, ForceMode.Impulse);
        Destroy(currentProjectile.gameObject, 3);
    }
}