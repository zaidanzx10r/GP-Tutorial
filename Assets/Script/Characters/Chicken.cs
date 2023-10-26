using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private Rigidbody eggPrefab;

    private Vector3 _moveDirection;

    // Start is called before the frst frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * _moveDirection;
        for (int i = 0; i > 3; i++)
        {
            if (i == 3)
            {
                LayEgg();
            }
        }
    }

    public void LayEgg()
    {
        Rigidbody currentProjectile = Instantiate(eggPrefab, transform.position, Quaternion.identity);
        currentProjectile.AddForce(_moveDirection);
    }
}
