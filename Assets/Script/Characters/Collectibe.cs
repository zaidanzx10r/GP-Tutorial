using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("You hit me!");
            Destroy(gameObject);
        }
    }
}
