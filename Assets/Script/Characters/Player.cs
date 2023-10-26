using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;

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

    [Header("Player UI")]
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI shotsFired;

    [SerializeField] private float maxHealth;
    private float _health;

    private int maxShots = 10;
    public int shotsFiredCounter;

    private float Health
    {
        get => _health;
        set
        {
            _health = value;
            healthBar.fillAmount = _health / maxHealth;
        }
    }

    private Rigidbody rb;

    private bool isGrounded;
    private Vector3 _moveDirection;
    
    void Start()
    {
        InputManager.Init(this);
        InputManager.Gamemode();

        rb = GetComponent<Rigidbody>();

        Health = maxHealth;

        shotsFiredCounter = maxShots;
    }

     void Update()
    {
        transform.position +=  transform.rotation * (speed * Time.deltaTime * _moveDirection);
        checkGrounded();

        Health -= Time.deltaTime * 5;

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
        if (shotsFiredCounter <= 0)
        {
            return;
        }

        Rigidbody currentProjectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        currentProjectile.AddForce(followTarget.forward * bulletForce, ForceMode.Impulse);

        shotsFired.text = (shotsFiredCounter-1).ToString();
        
        shotsFiredCounter--;

        Destroy(currentProjectile.gameObject, 3);
    }

    public void Reload()
    {
        Debug.Log("Reloading");
        shotsFiredCounter = maxShots;

    }
}